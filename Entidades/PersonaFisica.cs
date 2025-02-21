using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class PersonaFisica
    {
        public string apellido2 { get; set; }
        [Required][MinLength(1)] public string nombre { get; set; }
        [Required][MinLength(1)] public string apellido1 { get; set; }
        [Required][MinLength(1)] public string fechaNacimiento { get; set; }
        [Required][MinLength(1), MaxLength(1)] public string codigoSexo { get; set; }
    }
}