using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class DatosEconomicos
    {
        public OtrasPrestaciones otrasPrestaciones { get; set; }
        public OtrosIngresosBienes otrosIngresosBienes { get; set; }
        [Required] public decimal ingresosAnualesBrutos { get; set; }
    }
}