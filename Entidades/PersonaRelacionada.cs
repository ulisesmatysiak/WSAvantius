using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class PersonaRelacionada
    {
        [Required] public Persona persona { get; set; }
        [MinLength(5),MaxLength(5)] public string codigoTipoRelacion { get; set; }
        [Required] public bool esContrario { get; set; }
        public Domicilio domicilio { get; set; }
    }
}