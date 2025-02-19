using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class CircunstanciasExcepcionales
    {
        public List<SolicitudExcepcionalDelDerecho> SolicitudesExcepcionalDelDerecho { get; set; }
        public string OtrosMotivos { get; set; }
    }
}