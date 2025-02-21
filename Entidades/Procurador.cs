using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Procurador
    {
        [Required][MinLength(6), MaxLength(6)] public string numeroColegio { get; set; }
        [Required][MinLength(1)] public string numeroColegiado { get; set; }
        [Required][MinLength(12), MaxLength(12)] public string codigoTarifa { get; set; }
    }
}