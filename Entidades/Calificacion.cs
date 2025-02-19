using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Calificacion
    {
        [Required][MinLength(5), MaxLength(5)] public string CodigoTipoCalificacion { get; set; }
        [Required][MinLength(1)] public string CodigoTipoResolucionEconomica { get; set; }
        [Required][MinLength(1)] public string FechaCalificacion { get; set; }
        public string Observaciones { get; set; }
    }
}