using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Avantius.Entidades
{
    public class Asunto
    {
        public bool precisaAbogado { get; set; }
        public bool precisaProcurador { get; set; }
        public string codigoOrganoJudicial { get; set; }
        public string codigoTipoOrganoJudicial { get; set; }
        public string numero { get; set; }
        public string anio { get; set; }
        public Abogado abogado { get; set; }
        public Procurador procurador { get; set; }
    }
}