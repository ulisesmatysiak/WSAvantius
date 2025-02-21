using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Persona
    {
        [MinLength(3), MaxLength(3)] public string CodigoNacionalidad { get; set; }
        [Required] public IdentificacionPersona IdentificacionPersona { get; set; }
        [Required][MinLength(1)] public string CodigoPais { get; set; }
        public PersonaJuridica PersonaJuridica { get; set; }
        public PersonaFisica PersonaFisica { get; set; }
    }
}