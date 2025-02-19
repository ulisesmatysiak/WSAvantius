using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class DatosEconomicos
    {
        public OtrasPrestaciones OtrasPrestaciones { get; set; }
        public OtrosIngresosBienes OtrosIngresosBienes { get; set; }
        [Required] public decimal IngresosAnualesBrutos { get; set; }
    }
}