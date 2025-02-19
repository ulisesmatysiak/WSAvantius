using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_Avantius.Entidades;

namespace WS_Avantius.Negocio.Service.Interfaces
{
    public interface IAltaExpedienteJusticiaGratuitaService
    {
        Task<Response> apiSolicitudJusticiaGratuitaPost(string body);
    }
}
