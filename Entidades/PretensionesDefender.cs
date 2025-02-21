using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class PretensionesDefender
    {
        public string observaciones { get; set; }
        [Required][MinLength(3), MaxLength(3)] public string codigoTipoIntervinienteSolicitante { get; set; }
        [Required][MinLength(1)] public string codigoSituacionProceso { get; set; }
        [Required][MinLength(1)] public string codigoOrdenJurisdiccional { get; set; }
        public List<Procedimiento> procedimientos { get; set; }
        public Asunto asunto { get; set; }
    }
}