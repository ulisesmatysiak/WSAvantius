using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class RepresentanteSolicitante
    {
        [MinLength(5), MaxLength(5)]
        public string codigoCargoRepresentante { get; set; }

        public Persona persona { get; set; }
    }
}