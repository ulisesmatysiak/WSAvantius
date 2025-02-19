using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class PersonaJuridica
    {
        public string CargoResponsable { get; set; }
        [Required][MinLength(1)] public string NombreComercial { get; set; }
        [Required][MinLength(1)] public string RazonSocial { get; set; }
    }
}