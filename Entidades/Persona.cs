using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Persona
    {
        [MinLength(3), MaxLength(3)] public string codigoNacionalidad { get; set; }
        [Required] public IdentificacionPersona identificacionPersona { get; set; }
        [Required][MinLength(1)] public string codigoPais { get; set; }
        public PersonaJuridica personaJuridica { get; set; }
        public PersonaFisica personaFisica { get; set; }
    }
}