using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using WS_Avantius.Entidades;

namespace WS_Avantius.Negocio.Utils.Mappers
{
    public class AltaExpedienteJusticiaGratuitaMapper
    {
        public static string MapearAltaExpedienteJusticiaGrauita(AltaExpedienteJusticiaGratuita data)
        {
            string json = JsonSerializer.Serialize(data);
            return json;
        }
    }
}