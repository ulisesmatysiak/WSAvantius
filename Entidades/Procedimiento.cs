using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Procedimiento
    {
        [MinLength(2), MaxLength(2)] public string CodigoProvincia { get; set; }
        [MinLength(5), MaxLength(5)] public string CodigoPoblacion { get; set; }
        [MinLength(2), MaxLength(2)] public string CodigoTipoOrgano { get; set; }
        [MinLength(10), MaxLength(10)] public string CodigoOrgano { get; set; }
        public string NumeroProcedimiento { get; set; }
        [MinLength(4), MaxLength(4)] public string AnoProcedimiento { get; set; }
        public string NumeroPieza { get; set; }
        [MinLength(3), MaxLength(3)] public string CodigoTipoProcedimiento { get; set; }
        public bool PrecisaAbogado { get; set; }
        public bool PrecisaProcurador { get; set; }
        public string Observaciones { get; set; }
        [Required][MinLength(5), MaxLength(5)] public string CodigoSituacionProceso { get; set; }
        [Required][MinLength(5), MaxLength(5)] public string CodigoTipoFacturacion { get; set; }
        public Abogado Abogado { get; set; }
        public Procurador Procurador { get; set; }
    }
}