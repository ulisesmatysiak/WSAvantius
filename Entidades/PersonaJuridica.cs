using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class PersonaJuridica
    {
        public string cargoResponsable { get; set; }
        [Required][MinLength(1)] public string nombreComercial { get; set; }
        [Required][MinLength(1)] public string razonSocial { get; set; }
    }
}