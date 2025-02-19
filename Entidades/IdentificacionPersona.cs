using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class IdentificacionPersona
    {
        [Required][MinLength(1)] public string TipoIdentificacion { get; set; }
        [Required][MinLength(1)] public string Identificacion { get; set; }
        [Required][MinLength(1)] public string CodigoPaisExpedicion { get; set; }
    }
}