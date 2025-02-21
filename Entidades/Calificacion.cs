using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Calificacion
    {
        [Required][MinLength(5), MaxLength(5)] public string codigoTipoCalificacion { get; set; }
        [Required][MinLength(1)] public string codigoTipoResolucionEconomica { get; set; }
        [Required][MinLength(1)] public string fechaCalificacion { get; set; }
        public string observaciones { get; set; }
    }
}