using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Asunto
    {
        public bool PrecisaAbogado { get; set; }
        public bool PrecisaProcurador { get; set; }
        public string CodigoOrganoJudicial { get; set; }
        public string CodigoTipoOrganoJudicial { get; set; }
        public string Numero { get; set; }
        public string Anio { get; set; }
        public Abogado Abogado { get; set; }
        public Procurador Procurador { get; set; }
    }
}