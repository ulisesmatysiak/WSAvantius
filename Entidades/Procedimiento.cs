using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Procedimiento
    {
        [MinLength(2), MaxLength(2)] public string codigoProvincia { get; set; }
        [MinLength(5), MaxLength(5)] public string codigoPoblacion { get; set; }
        [MinLength(2), MaxLength(2)] public string codigoTipoOrgano { get; set; }
        [MinLength(10), MaxLength(10)] public string codigoOrgano { get; set; }
        public string numeroProcedimiento { get; set; }
        [MinLength(4), MaxLength(4)] public string anoProcedimiento { get; set; }
        public string numeroPieza { get; set; }
        [MinLength(3), MaxLength(3)] public string codigoTipoProcedimiento { get; set; }
        public bool precisaAbogado { get; set; }
        public bool precisaProcurador { get; set; }
        public string observaciones { get; set; }
        [Required][MinLength(5), MaxLength(5)] public string codigoSituacionProceso { get; set; }
        [Required][MinLength(5), MaxLength(5)] public string codigoTipoFacturacion { get; set; }
        public Abogado abogado { get; set; }
        public Procurador procurador { get; set; }
    }
}