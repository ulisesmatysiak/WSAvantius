using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS_Avantius.Entidades;

namespace WS_Avantius.Datos
{
    public class AltaExpedienteJusticiaGratuitaDAO
    {
        public Solicitud obtenerSolicitud(DateTime fecha, int idExpediente)
        {
            Conn conn = new Conn();
            Solicitud solicitud = new Solicitud();
            try
            {
                conn.setearProcedimiento("usp_WSAvantius_obtenerSolicitud");
                conn.setearParametro("@Fecha", fecha);
                conn.setearParametro("@Id_Expediente", idExpediente);
                conn.ejecutarLectura();

                #region Solicitud
                while (conn.Lector.Read())
                {
                    try
                    {
                        solicitud.CodigoTipoSolicitud = conn.Lector["CodigoTipoSolicitud"]?.ToString();
                        solicitud.LugarPresentacion = conn.Lector["LugarPresentacion"]?.ToString();
                        solicitud.FechaPresentacion = conn.Lector["FechaPresentacion"]?.ToString();
                        solicitud.ObservacionesRegistro = conn.Lector["ObservacionesRegistro"]?.ToString();
                        solicitud.CodigoIdiomaAsistenciaLetrada = conn.Lector["CodigoIdiomaAsistenciaLetrada"]?.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                #region Calificacion
                conn.siguienteResultado();
                while (conn.Lector.Read())
                {
                    try
                    {
                        solicitud.Calificacion = new Calificacion
                        {
                            Observaciones = conn.Lector["Observaciones"]?.ToString(),
                            CodigoTipoResolucionEconomica = conn.Lector["CodigoTipoResolucionEconomica"]?.ToString(),
                            CodigoTipoCalificacion = conn.Lector["CodigoTipoCalificacion"]?.ToString(),
                            FechaCalificacion = conn.Lector["FechaCalificacion"]?.ToString()
                        };
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                #region Solicitante
                conn.siguienteResultado();
                while (conn.Lector.Read())
                {
                    try
                    {

                        solicitud.Solicitante = new Solicitante
                        {
                            Profesion = conn.Lector["Profesion"]?.ToString(),
                            CodigoEstadoCivil = conn.Lector["CodigoEstadoCivil"]?.ToString(),
                            CodigoRegimenEconomicoMatrimonial = conn.Lector["CodigoRegimenEconomicoMatrimonial"]?.ToString(),
                            CodigoIntegracionFamilia = conn.Lector["CodigoIntegracionFamilia"]?.ToString(),
                            PersonaSolicitante = new PersonaSolicitante
                            {
                                CodigoNacionalidad = conn.Lector["CodigoNacionalidad"]?.ToString(),
                                CodigoPais = conn.Lector["CodigoPais"]?.ToString(),
                                IdentificacionPersona = new IdentificacionPersona
                                {
                                    TipoIdentificacion = conn.Lector["TipoIdentificacion"]?.ToString(),
                                    Identificacion = conn.Lector["Identificacion"]?.ToString(),
                                    CodigoPaisExpedicion = conn.Lector["CodigoPaisExpedicion"]?.ToString()
                                },
                                PersonaFisica = new PersonaFisica
                                {
                                    Nombre = conn.Lector["Nombre"]?.ToString(),
                                    Apellido1 = conn.Lector["Apellido1"]?.ToString(),
                                    Apellido2 = conn.Lector["Apellido2"]?.ToString(),
                                    FechaNacimiento = conn.Lector["FechaNacimiento"]?.ToString(),
                                    CodigoSexo = conn.Lector["CodigoSexo"]?.ToString()
                                }
                            },
                            Domicilio = new Domicilio
                            {
                                Numero = conn.Lector["Numero"]?.ToString(),
                                Piso = conn.Lector["Piso"]?.ToString(),
                                Telefono = conn.Lector["Telefono"]?.ToString(),
                                Fax = conn.Lector["Fax"]?.ToString(),
                                CodigoPais = conn.Lector["CodigoPaisDomicilio"]?.ToString(),
                                CodigoProvincia = conn.Lector["CodigoProvincia"]?.ToString(),
                                CodigoMunicipio = conn.Lector["CodigoMunicipio"]?.ToString(),
                                CodigoTipoVia = conn.Lector["CodigoTipoVia"]?.ToString(),
                                NombreVia = conn.Lector["NombreVia"]?.ToString(),
                                CodigoPostal = conn.Lector["CodigoPostal"]?.ToString()
                            }
                        };
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                #region Datos Economicos
                conn.siguienteResultado();
                while (conn.Lector.Read())
                {
                    try
                    {
                        var datosEconomicos = new DatosEconomicos
                        {
                            IngresosAnualesBrutos = Convert.ToDecimal(conn.Lector["IngresosAnualesBrutos"]),
                            OtrasPrestaciones = new OtrasPrestaciones
                            {
                                TotalOtrasPrestaciones = Convert.ToDecimal(conn.Lector["TotalOtrasPrestaciones"]),
                                CodigoOtraPrestacion = new List<OtraPrestacion>()
                            },
                            OtrosIngresosBienes = new OtrosIngresosBienes
                            {
                                TotalOtrosIngresosBienes = Convert.ToDecimal(conn.Lector["TotalOtrosIngresosBienes"]),
                                CodigoIngresoBien = new List<OtroIngresoBien>()
                            }
                        };

                        string tipoPersona = conn.Lector["TipoPersona"]?.ToString();
                        if (tipoPersona == "SOLICITANTE")
                            solicitud.DatosEconomicosSolicitante = datosEconomicos;
                        else if (tipoPersona == "CONYUGE")
                            solicitud.DatosEconomicosConyuge = datosEconomicos;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                #region Personas Relacionadas
                solicitud.PersonasRelacionadasSolicitante = new List<PersonaRelacionada>();
                conn.siguienteResultado();
                while (conn.Lector.Read())
                {
                    try
                    {
                        solicitud.PersonasRelacionadasSolicitante.Add(new PersonaRelacionada
                        {
                            CodigoTipoRelacion = conn.Lector["CodigoTipoRelacion"]?.ToString(),
                            EsContrario = Convert.ToBoolean(conn.Lector["EsContrario"]),
                            Persona = new Persona
                            {
                                CodigoNacionalidad = conn.Lector["CodigoNacionalidad"]?.ToString(),
                                CodigoPais = conn.Lector["CodigoPais"]?.ToString(),
                                IdentificacionPersona = new IdentificacionPersona
                                {
                                    TipoIdentificacion = conn.Lector["TipoIdentificacion"]?.ToString(),
                                    Identificacion = conn.Lector["Identificacion"]?.ToString(),
                                    CodigoPaisExpedicion = conn.Lector["CodigoPaisExpedicion"]?.ToString()
                                }
                            },
                            Domicilio = new Domicilio
                            {
                                Numero = conn.Lector["Numero"]?.ToString(),
                                Piso = conn.Lector["Piso"]?.ToString(),
                                Telefono = conn.Lector["Telefono"]?.ToString(),
                                Fax = conn.Lector["Fax"]?.ToString(),
                                CodigoPais = conn.Lector["CodigoPaisDomicilio"]?.ToString(),
                                CodigoProvincia = conn.Lector["CodigoProvincia"]?.ToString(),
                                CodigoMunicipio = conn.Lector["CodigoMunicipio"]?.ToString(),
                                CodigoTipoVia = conn.Lector["CodigoTipoVia"]?.ToString(),
                                NombreVia = conn.Lector["NombreVia"]?.ToString(),
                                CodigoPostal = conn.Lector["CodigoPostal"]?.ToString()
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                #region Pretensiones Defender
                solicitud.PretensionesDefender = new PretensionesDefender();
                conn.siguienteResultado();
                while (conn.Lector.Read())
                {
                    try
                    {

                        var pretensionesDefender = new PretensionesDefender
                        {
                            Observaciones = conn.Lector["Observaciones"]?.ToString(),
                            CodigoTipoIntervinienteSolicitante = conn.Lector["CodigoTipoIntervinienteSolicitante"]?.ToString(),
                            CodigoSituacionProceso = conn.Lector["CodigoSituacionProceso"]?.ToString(),
                            CodigoOrdenJurisdiccional = conn.Lector["CodigoOrdenJurisdiccional"]?.ToString(),

                            Procedimientos = new List<Procedimiento>
                        {
                            new Procedimiento
                            {
                                CodigoProvincia = conn.Lector["CodigoProvincia"]?.ToString(),
                                CodigoPoblacion = conn.Lector["CodigoPoblacion"]?.ToString(),
                                CodigoTipoOrgano = conn.Lector["CodigoTipoOrgano"]?.ToString(),
                                CodigoOrgano = conn.Lector["CodigoOrgano"]?.ToString(),
                                NumeroProcedimiento = conn.Lector["NumeroProcedimiento"]?.ToString(),
                                AnoProcedimiento = conn.Lector["AnoProcedimiento"]?.ToString(),
                                NumeroPieza = conn.Lector["NumeroPieza"]?.ToString(),
                                CodigoTipoProcedimiento = conn.Lector["CodigoTipoProcedimiento"]?.ToString(),
                                PrecisaAbogado = Convert.ToBoolean(conn.Lector["PrecisaAbogado_Procedimiento"]),
                                PrecisaProcurador = Convert.ToBoolean(conn.Lector["PrecisaProcurador_Procedimiento"]),
                                Observaciones = conn.Lector["Observaciones_Procedimiento"]?.ToString(),
                                CodigoSituacionProceso = conn.Lector["CodigoSituacionProceso_Procedimiento"]?.ToString(),
                                CodigoTipoFacturacion = conn.Lector["CodigoTipoFacturacion"]?.ToString(),
                                Abogado = new Abogado
                                {
                                    NumeroColegio = conn.Lector["NumeroColegio_Abogado_Procedimiento"]?.ToString(),
                                    NumeroColegiado = conn.Lector["NumeroColegiado_Abogado_Procedimiento"]?.ToString(),
                                    CodigoTarifa = conn.Lector["CodigoTarifa_Abogado_Procedimiento"]?.ToString()
                                },
                                Procurador = new Procurador
                                {
                                    NumeroColegio = conn.Lector["NumeroColegio_Procurador_Procedimiento"]?.ToString(),
                                    NumeroColegiado = conn.Lector["NumeroColegiado_Procurador_Procedimiento"]?.ToString(),
                                    CodigoTarifa = conn.Lector["CodigoTarifa_Procurador_Procedimiento"]?.ToString()
                                }
                            }
                        },

                            Asunto = new Asunto
                            {
                                PrecisaAbogado = Convert.ToBoolean(conn.Lector["PrecisaAbogado_Asunto"]),
                                PrecisaProcurador = Convert.ToBoolean(conn.Lector["PrecisaProcurador_Asunto"]),
                                CodigoOrganoJudicial = conn.Lector["CodigoOrganoJudicial"]?.ToString(),
                                CodigoTipoOrganoJudicial = conn.Lector["CodigoTipoOrganoJudicial"]?.ToString(),
                                Numero = conn.Lector["Numero"]?.ToString(),
                                Anio = conn.Lector["Anio"]?.ToString(),
                                Abogado = new Abogado
                                {
                                    NumeroColegio = conn.Lector["NumeroColegio_Abogado_Asunto"]?.ToString(),
                                    NumeroColegiado = conn.Lector["NumeroColegiado_Abogado_Asunto"]?.ToString(),
                                    CodigoTarifa = conn.Lector["CodigoTarifa_Abogado_Asunto"]?.ToString()
                                },
                                Procurador = new Procurador
                                {
                                    NumeroColegio = conn.Lector["NumeroColegio_Procurador_Asunto"]?.ToString(),
                                    NumeroColegiado = conn.Lector["NumeroColegiado_Procurador_Asunto"]?.ToString(),
                                    CodigoTarifa = conn.Lector["CodigoTarifa_Procurador_Asunto"]?.ToString()
                                }
                            }
                        };

                        solicitud.PretensionesDefender = pretensionesDefender;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                #region PrestacionesRegistro
                solicitud.PrestacionesRegistro = new List<PrestacionRegistro>();
                conn.siguienteResultado();
                while (conn.Lector.Read())
                {
                    try
                    {
                        solicitud.PrestacionesRegistro.Add(new PrestacionRegistro
                        {
                            CodigoPrestacion = conn.Lector["CodigoPrestacion"]?.ToString()
                        });
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                #region SupuestosEspeciales
                solicitud.SupuestosEspeciales = new List<SupuestoEspecial>();
                conn.siguienteResultado();
                while (conn.Lector.Read())
                {
                    try
                    {
                        solicitud.SupuestosEspeciales.Add(new SupuestoEspecial
                        {
                            CodigoSupuestoEspecial = conn.Lector["CodigoSupuestoEspecial"]?.ToString()
                        });
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                #region Circunstancias Excepcionales
                conn.siguienteResultado();
                while (conn.Lector.Read())
                {
                    try
                    {
                        solicitud.CircunstanciasExcepcionales = new CircunstanciasExcepcionales
                        {
                            OtrosMotivos = conn.Lector["OtrosMotivos"]?.ToString(),
                            SolicitudesExcepcionalDelDerecho = new List<SolicitudExcepcionalDelDerecho>()
                        };
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                #region Documentos Anexos
                solicitud.DocumentosAnexos = new List<DocumentoAnexo>();
                conn.siguienteResultado();
                while (conn.Lector.Read())
                {
                    try
                    {
                        solicitud.DocumentosAnexos.Add(new DocumentoAnexo
                        {
                            LocalizadorArchivo = conn.Lector["LocalizadorArchivo"]?.ToString(),
                            Titulo = conn.Lector["Titulo"]?.ToString(),
                            Principal = Convert.ToBoolean(conn.Lector["Principal"]),
                            CodigoCategoriaDocumento = conn.Lector["CodigoCategoriaDocumento"]?.ToString(),
                            Descripcion = conn.Lector["Descripcion"]?.ToString()
                        });
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                return solicitud;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.cerrarConexion();
            }
        }
    }
}