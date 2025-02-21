using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Solicitud
    {
        [Required][MinLength(1)] public string codigoTipoSolicitud { get; set; }
        [Required][MinLength(1)] public string lugarPresentacion { get; set; }
        [Required][MinLength(1)] public string fechaPresentacion { get; set; }
        public string observacionesRegistro { get; set; }
        public string codigoIdiomaAsistenciaLetrada { get; set; }
        [Required] public Calificacion calificacion { get; set; }
        [Required] public Solicitante solicitante { get; set; }
        [Required] public DatosEconomicos datosEconomicosSolicitante { get; set; }
        public DatosEconomicos datosEconomicosConyuge { get; set; }
        public List<PersonaRelacionada> personasRelacionadasSolicitante { get; set; }
        [Required] public PretensionesDefender pretensionesDefender { get; set; }
        [Required] public List<PrestacionRegistro> prestacionesRegistro { get; set; }
        public List<SupuestoEspecial> supuestosEspeciales { get; set; }
        public CircunstanciasExcepcionales circunstanciasExcepcionales { get; set; }
        [Required] public List<DocumentoAnexo> documentosAnexos { get; set; }
        public bool asuntoViolenciaMujer { get; set; }
    }
}