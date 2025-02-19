using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class PretensionesDefender
    {
        public string Observaciones { get; set; }
        [Required][MinLength(3), MaxLength(3)] public string CodigoTipoIntervinienteSolicitante { get; set; }
        [Required][MinLength(1)] public string CodigoSituacionProceso { get; set; }
        [Required][MinLength(1)] public string CodigoOrdenJurisdiccional { get; set; }
        public List<Procedimiento> Procedimientos { get; set; }
        public Asunto Asunto { get; set; }
    }
}