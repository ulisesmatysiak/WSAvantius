using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class AltaExpedienteJusticiaGratuita
    {
        [Required] public Solicitud Solicitud { get; set; }
        [Required][MinLength(1)] public string EntidadPresenta { get; set; }
    }
}