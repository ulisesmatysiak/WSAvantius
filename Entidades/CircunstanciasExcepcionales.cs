using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class CircunstanciasExcepcionales
    {
        public List<SolicitudExcepcionalDelDerecho> solicitudesExcepcionalDelDerecho { get; set; }
        public string otrosMotivos { get; set; }
    }
}