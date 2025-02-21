using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class IdentificacionPersona
    {
        [Required][MinLength(1)] public string tipoIdentificacion { get; set; }
        [Required][MinLength(1)] public string identificacion { get; set; }
        [Required][MinLength(1)] public string codigoPaisExpedicion { get; set; }
    }
}