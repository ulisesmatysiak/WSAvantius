using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WS_Avantius.Negocio;

namespace WS_Avantius.Presentacion
{
    public partial class AltaExpedienteJusticiaGratuita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var asd = "2025-01-09";
            DateTime fecha = DateTime.Parse(asd);
            int idExpediente = 105272;
            AltaExpedienteJusticiaGratuitaDTO.srvAltaExpedienteJusticiaGratuita(fecha, idExpediente);
        }
    }
}