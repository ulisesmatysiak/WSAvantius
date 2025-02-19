using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Solicitud
    {
        [Required][MinLength(1)] public string CodigoTipoSolicitud { get; set; }
        [Required][MinLength(1)] public string LugarPresentacion { get; set; }
        [Required][MinLength(1)] public string FechaPresentacion { get; set; }
        public string ObservacionesRegistro { get; set; }
        public string CodigoIdiomaAsistenciaLetrada { get; set; }
        [Required] public Calificacion Calificacion { get; set; }
        [Required] public Solicitante Solicitante { get; set; }
        [Required] public DatosEconomicos DatosEconomicosSolicitante { get; set; }
        public DatosEconomicos DatosEconomicosConyuge { get; set; }
        public List<PersonaRelacionada> PersonasRelacionadasSolicitante { get; set; }
        [Required] public PretensionesDefender PretensionesDefender { get; set; }
        [Required] public List<PrestacionRegistro> PrestacionesRegistro { get; set; }
        public List<SupuestoEspecial> SupuestosEspeciales { get; set; }
        public CircunstanciasExcepcionales CircunstanciasExcepcionales { get; set; }
        [Required] public List<DocumentoAnexo> DocumentosAnexos { get; set; }
    }
}