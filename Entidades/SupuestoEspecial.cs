using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class SupuestoEspecial
    {
        [Required][MinLength(5), MaxLength(5)] public string codigoSupuestoEspecial { get; set; }
    }
}