using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class PersonaFisica
    {
        public string Apellido2 { get; set; }
        [Required][MinLength(1)] public string Nombre { get; set; }
        [Required][MinLength(1)] public string Apellido1 { get; set; }
        [Required][MinLength(1)] public string FechaNacimiento { get; set; }
        [Required][MinLength(1), MaxLength(1)] public string CodigoSexo { get; set; }
    }
}