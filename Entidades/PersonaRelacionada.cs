using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class PersonaRelacionada
    {
        [Required] public Persona Persona { get; set; }
        [MinLength(5),MaxLength(5)] public string CodigoTipoRelacion { get; set; }
        [Required] public bool EsContrario { get; set; }
        public Domicilio Domicilio { get; set; }
    }
}