using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Domicilio
    {
        public string Numero { get; set; }
        public string Piso { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        [Required][MinLength(3), MaxLength(3)] public string CodigoPais { get; set; }
        [Required][MinLength(2), MaxLength(2)] public string CodigoProvincia { get; set; }
        [Required][MinLength(5), MaxLength(5)] public string CodigoMunicipio { get; set; }
        [Required][MinLength(2), MaxLength(2)] public string CodigoTipoVia { get; set; }
        [Required][MinLength(1)] public string NombreVia { get; set; }
        [Required][MinLength(1)] public string CodigoPostal { get; set; }
    }
}