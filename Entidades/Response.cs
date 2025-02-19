using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Response
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public List<Warning> Warnings { get; set; }
        public string LocalizadorExpediente { get; set; }
        public string UnidadFuncional { get; set; }
        public string NumeroExpedienteJusticiaGratuita { get; set; }
        public string AnoExpedienteJusticiaGratuita { get; set; }
    }

    public class Warning
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
    }
}