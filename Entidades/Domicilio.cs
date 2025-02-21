using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Domicilio
    {
        public string numero { get; set; }
        public string piso { get; set; }
        public string telefono { get; set; }
        public string fax { get; set; }
        [Required][MinLength(3), MaxLength(3)] public string codigoPais { get; set; }
        [Required][MinLength(2), MaxLength(2)] public string codigoProvincia { get; set; }
        [Required][MinLength(5), MaxLength(5)] public string codigoMunicipio { get; set; }
        [Required][MinLength(2), MaxLength(2)] public string codigoTipoVia { get; set; }
        [Required][MinLength(1)] public string nombreVia { get; set; }
        [Required][MinLength(1)] public string codigoPostal { get; set; }
    }
}