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
                        solicitud.codigoTipoSolicitud = conn.Lector["CodigoTipoSolicitud"]?.ToString();
                        solicitud.lugarPresentacion = conn.Lector["LugarPresentacion"]?.ToString();
                        solicitud.fechaPresentacion = conn.Lector["FechaPresentacion"]?.ToString();
                        solicitud.observacionesRegistro = conn.Lector["ObservacionesRegistro"]?.ToString();
                        solicitud.codigoIdiomaAsistenciaLetrada = conn.Lector["CodigoIdiomaAsistenciaLetrada"]?.ToString();
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
                        solicitud.calificacion = new Calificacion
                        {
                            observaciones = conn.Lector["Observaciones"]?.ToString(),
                            codigoTipoResolucionEconomica = conn.Lector["CodigoTipoResolucionEconomica"]?.ToString(),
                            codigoTipoCalificacion = conn.Lector["CodigoTipoCalificacion"]?.ToString(),
                            fechaCalificacion = conn.Lector["FechaCalificacion"]?.ToString()
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
                        solicitud.solicitante = new Solicitante
                        {
                            profesion = conn.Lector["Profesion"]?.ToString(),
                            codigoEstadoCivil = conn.Lector["CodigoEstadoCivil"]?.ToString(),
                            codigoRegimenEconomicoMatrimonial = conn.Lector["CodigoRegimenEconomicoMatrimonial"]?.ToString(),
                            codigoIntegracionFamilia = conn.Lector["CodigoIntegracionFamilia"]?.ToString(),
                            personaSolicitante = new Persona
                            {
                                codigoNacionalidad = conn.Lector["CodigoNacionalidad"]?.ToString(),
                                codigoPais = conn.Lector["CodigoPais"]?.ToString(),
                                identificacionPersona = new IdentificacionPersona
                                {
                                    tipoIdentificacion = conn.Lector["TipoIdentificacion"]?.ToString(),
                                    identificacion = conn.Lector["Identificacion"]?.ToString(),
                                    codigoPaisExpedicion = conn.Lector["CodigoPaisExpedicion"]?.ToString()
                                },
                                personaJuridica = new PersonaJuridica
                                {
                                    cargoResponsable = conn.Lector["CargoResponsable"]?.ToString(),
                                    nombreComercial = conn.Lector["NombreComercial"]?.ToString(),
                                    razonSocial = conn.Lector["RazonSocial"]?.ToString()
                                },
                                personaFisica = new PersonaFisica
                                {
                                    nombre = conn.Lector["Nombre"]?.ToString(),
                                    apellido1 = conn.Lector["Apellido1"]?.ToString(),
                                    apellido2 = conn.Lector["Apellido2"]?.ToString(),
                                    fechaNacimiento = conn.Lector["FechaNacimiento"]?.ToString(),
                                    codigoSexo = conn.Lector["CodigoSexo"]?.ToString()
                                }
                            },
                            domicilio = new Domicilio
                            {
                                numero = conn.Lector["Numero"]?.ToString(),
                                piso = conn.Lector["Piso"]?.ToString(),
                                telefono = conn.Lector["Telefono"]?.ToString(),
                                fax = conn.Lector["Fax"]?.ToString(),
                                codigoPais = conn.Lector["CodigoPaisDomicilio"]?.ToString(),
                                codigoProvincia = conn.Lector["CodigoProvincia"]?.ToString(),
                                codigoMunicipio = conn.Lector["CodigoMunicipio"]?.ToString(),
                                codigoTipoVia = conn.Lector["CodigoTipoVia"]?.ToString(),
                                nombreVia = conn.Lector["NombreVia"]?.ToString(),
                                codigoPostal = conn.Lector["CodigoPostal"]?.ToString()
                            },
                            representanteSolicitante = new RepresentanteSolicitante()
                            {
                                codigoCargoRepresentante = conn.Lector["CodigoCargoRepresentante"]?.ToString(),
                                persona = new Persona()
                                {
                                    codigoNacionalidad = conn.Lector["CodigoNacionalidad"]?.ToString(),
                                    codigoPais = conn.Lector["CodigoPais"]?.ToString(),
                                    identificacionPersona = new IdentificacionPersona
                                    {
                                        tipoIdentificacion = conn.Lector["TipoIdentificacion"]?.ToString(),
                                        identificacion = conn.Lector["Identificacion"]?.ToString(),
                                        codigoPaisExpedicion = conn.Lector["CodigoPaisExpedicion"]?.ToString()
                                    },
                                    personaJuridica = new PersonaJuridica
                                    {
                                        cargoResponsable = conn.Lector["CargoResponsable"]?.ToString(),
                                        nombreComercial = conn.Lector["NombreComercial"]?.ToString(),
                                        razonSocial = conn.Lector["RazonSocial"]?.ToString()
                                    },
                                    personaFisica = new PersonaFisica
                                    {
                                        nombre = conn.Lector["Nombre"]?.ToString(),
                                        apellido1 = conn.Lector["Apellido1"]?.ToString(),
                                        apellido2 = conn.Lector["Apellido2"]?.ToString(),
                                        fechaNacimiento = conn.Lector["FechaNacimiento"]?.ToString(),
                                        codigoSexo = conn.Lector["CodigoSexo"]?.ToString()
                                    }
                                }
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
                            ingresosAnualesBrutos = Convert.ToDecimal(conn.Lector["IngresosAnualesBrutos"]),
                            otrasPrestaciones = new OtrasPrestaciones
                            {
                                totalOtrasPrestaciones = Convert.ToDecimal(conn.Lector["TotalOtrasPrestaciones"]),
                                codigoOtraPrestacion = new List<OtraPrestacion>()
                            },
                            otrosIngresosBienes = new OtrosIngresosBienes
                            {
                                totalOtrosIngresosBienes = Convert.ToDecimal(conn.Lector["TotalOtrosIngresosBienes"]),
                                codigoIngresoBien = new List<OtroIngresoBien>()
                            }
                        };

                        string tipoPersona = conn.Lector["TipoPersona"]?.ToString();
                        if (tipoPersona == "SOLICITANTE")
                            solicitud.datosEconomicosSolicitante = datosEconomicos;
                        else if (tipoPersona == "CONYUGE")
                            solicitud.datosEconomicosConyuge = datosEconomicos;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                #region Personas Relacionadas
                solicitud.personasRelacionadasSolicitante = new List<PersonaRelacionada>();
                conn.siguienteResultado();
                while (conn.Lector.Read())
                {
                    try
                    {
                        solicitud.personasRelacionadasSolicitante.Add(new PersonaRelacionada
                        {
                            codigoTipoRelacion = conn.Lector["CodigoTipoRelacion"]?.ToString(),
                            esContrario = Convert.ToBoolean(conn.Lector["EsContrario"]),
                            persona = new Persona
                            {
                                codigoNacionalidad = conn.Lector["CodigoNacionalidad"]?.ToString(),
                                codigoPais = conn.Lector["CodigoPais"]?.ToString(),
                                identificacionPersona = new IdentificacionPersona
                                {
                                    tipoIdentificacion = conn.Lector["TipoIdentificacion"]?.ToString(),
                                    identificacion = conn.Lector["Identificacion"]?.ToString(),
                                    codigoPaisExpedicion = conn.Lector["CodigoPaisExpedicion"]?.ToString()
                                },
                                personaJuridica = new PersonaJuridica
                                {
                                    cargoResponsable = conn.Lector["CargoResponsable"]?.ToString(),
                                    nombreComercial = conn.Lector["NombreComercial"]?.ToString(),
                                    razonSocial = conn.Lector["RazonSocial"]?.ToString()
                                },
                                personaFisica = new PersonaFisica
                                {
                                    nombre = conn.Lector["Nombre"]?.ToString(),
                                    apellido1 = conn.Lector["Apellido1"]?.ToString(),
                                    apellido2 = conn.Lector["Apellido2"]?.ToString(),
                                    fechaNacimiento = conn.Lector["FechaNacimiento"]?.ToString(),
                                    codigoSexo = conn.Lector["CodigoSexo"]?.ToString()
                                }
                            },
                            domicilio = new Domicilio
                            {
                                numero = conn.Lector["Numero"]?.ToString(),
                                piso = conn.Lector["Piso"]?.ToString(),
                                telefono = conn.Lector["Telefono"]?.ToString(),
                                fax = conn.Lector["Fax"]?.ToString(),
                                codigoPais = conn.Lector["CodigoPaisDomicilio"]?.ToString(),
                                codigoProvincia = conn.Lector["CodigoProvincia"]?.ToString(),
                                codigoMunicipio = conn.Lector["CodigoMunicipio"]?.ToString(),
                                codigoTipoVia = conn.Lector["CodigoTipoVia"]?.ToString(),
                                nombreVia = conn.Lector["NombreVia"]?.ToString(),
                                codigoPostal = conn.Lector["CodigoPostal"]?.ToString()
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
                solicitud.pretensionesDefender = new PretensionesDefender();
                conn.siguienteResultado();
                while (conn.Lector.Read())
                {
                    try
                    {

                        var pretensionesDefender = new PretensionesDefender
                        {
                            observaciones = conn.Lector["Observaciones"]?.ToString(),
                            codigoTipoIntervinienteSolicitante = conn.Lector["CodigoTipoIntervinienteSolicitante"]?.ToString(),
                            codigoSituacionProceso = conn.Lector["CodigoSituacionProceso"]?.ToString(),
                            codigoOrdenJurisdiccional = conn.Lector["CodigoOrdenJurisdiccional"]?.ToString(),

                            procedimientos = new List<Procedimiento>
                            {
                                new Procedimiento
                                {
                                    codigoProvincia = conn.Lector["CodigoProvincia"]?.ToString(),
                                    codigoPoblacion = conn.Lector["CodigoPoblacion"]?.ToString(),
                                    codigoTipoOrgano = conn.Lector["CodigoTipoOrgano"]?.ToString(),
                                    codigoOrgano = conn.Lector["CodigoOrgano"]?.ToString(),
                                    numeroProcedimiento = conn.Lector["NumeroProcedimiento"]?.ToString(),
                                    anoProcedimiento = conn.Lector["AnoProcedimiento"]?.ToString(),
                                    numeroPieza = conn.Lector["NumeroPieza"]?.ToString(),
                                    codigoTipoProcedimiento = conn.Lector["CodigoTipoProcedimiento"]?.ToString(),
                                    precisaAbogado = Convert.ToBoolean(conn.Lector["PrecisaAbogado_Procedimiento"]),
                                    precisaProcurador = Convert.ToBoolean(conn.Lector["PrecisaProcurador_Procedimiento"]),
                                    observaciones = conn.Lector["Observaciones_Procedimiento"]?.ToString(),
                                    codigoSituacionProceso = conn.Lector["CodigoSituacionProceso_Procedimiento"]?.ToString(),
                                    codigoTipoFacturacion = conn.Lector["CodigoTipoFacturacion"]?.ToString(),
                                    abogado = new Abogado
                                        {
                                            numeroColegiado = conn.Lector["NumeroColegio_Abogado_Procedimiento"]?.ToString(),
                                            numeroColegio = conn.Lector["NumeroColegiado_Abogado_Procedimiento"]?.ToString(),
                                            codigoTarifa = conn.Lector["CodigoTarifa_Abogado_Procedimiento"]?.ToString()
                                        },
                                    procurador = new Procurador
                                        {
                                            numeroColegio = conn.Lector["NumeroColegio_Procurador_Procedimiento"]?.ToString(),
                                            numeroColegiado = conn.Lector["NumeroColegiado_Procurador_Procedimiento"]?.ToString(),
                                            codigoTarifa = conn.Lector["CodigoTarifa_Procurador_Procedimiento"]?.ToString()
                                        }
                                }
                            },

                            asunto = new Asunto
                            {
                                precisaAbogado = Convert.ToBoolean(conn.Lector["PrecisaAbogado_Asunto"]),
                                precisaProcurador = Convert.ToBoolean(conn.Lector["PrecisaProcurador_Asunto"]),
                                codigoOrganoJudicial = conn.Lector["CodigoOrganoJudicial"]?.ToString(),
                                codigoTipoOrganoJudicial = conn.Lector["CodigoTipoOrganoJudicial"]?.ToString(),
                                numero = conn.Lector["Numero"]?.ToString(),
                                anio = conn.Lector["Anio"]?.ToString(),
                                abogado = new Abogado
                                {
                                    numeroColegio = conn.Lector["NumeroColegio_Abogado_Asunto"]?.ToString(),
                                    numeroColegiado = conn.Lector["NumeroColegiado_Abogado_Asunto"]?.ToString(),
                                    codigoTarifa = conn.Lector["CodigoTarifa_Abogado_Asunto"]?.ToString()
                                },
                                procurador = new Procurador
                                {
                                    numeroColegio = conn.Lector["NumeroColegio_Procurador_Asunto"]?.ToString(),
                                    numeroColegiado = conn.Lector["NumeroColegiado_Procurador_Asunto"]?.ToString(),
                                    codigoTarifa = conn.Lector["CodigoTarifa_Procurador_Asunto"]?.ToString()
                                }
                            }
                        };

                        solicitud.pretensionesDefender = pretensionesDefender;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                #region PrestacionesRegistro
                solicitud.prestacionesRegistro = new List<PrestacionRegistro>();
                conn.siguienteResultado();
                while (conn.Lector.Read())
                {
                    try
                    {
                        solicitud.prestacionesRegistro.Add(new PrestacionRegistro
                        {
                            codigoPrestacion = conn.Lector["CodigoPrestacion"]?.ToString()
                        });
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                #region SupuestosEspeciales
                solicitud.supuestosEspeciales = new List<SupuestoEspecial>();
                conn.siguienteResultado();
                while (conn.Lector.Read())
                {
                    try
                    {
                        solicitud.supuestosEspeciales.Add(new SupuestoEspecial
                        {
                            codigoSupuestoEspecial = conn.Lector["CodigoSupuestoEspecial"]?.ToString()
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
                        solicitud.circunstanciasExcepcionales = new CircunstanciasExcepcionales
                        {
                            otrosMotivos = conn.Lector["OtrosMotivos"]?.ToString(),
                            solicitudesExcepcionalDelDerecho = new List<SolicitudExcepcionalDelDerecho>()
                            {
                             new SolicitudExcepcionalDelDerecho
                             {
                                 codigoCircunstanciaExcepcional = conn.Lector["CodigoCircunstanciaExcepcional"]?.ToString()
                             }
                            }
                        };
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                #region Documentos Anexos
                solicitud.documentos = new List<DocumentoAnexo>();
                conn.siguienteResultado();
                while (conn.Lector.Read())
                {
                    try
                    {
                        solicitud.documentos.Add(new DocumentoAnexo
                        {
                            localizadorArchivo = conn.Lector["LocalizadorArchivo"]?.ToString(),
                            titulo = conn.Lector["Titulo"]?.ToString(),
                            principal = Convert.ToBoolean(conn.Lector["Principal"]),
                            codigoCategoriaDocumento = conn.Lector["CodigoCategoriaDocumento"]?.ToString(),
                            descripcion = conn.Lector["Descripcion"]?.ToString()
                        });
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                solicitud.asuntoViolenciaMujer = true;
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