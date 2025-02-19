using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using WS_Avantius.Entidades;
using WS_Avantius.Negocio.Service.Interfaces;

namespace WS_Avantius.Negocio.Service.Implementaciones
{
    public class AltaExpedienteJusticiaGratuitaService : IAltaExpedienteJusticiaGratuitaService
    {
        private readonly HttpClient _httpClient;

        public AltaExpedienteJusticiaGratuitaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> apiSolicitudJusticiaGratuitaPost(string body)
        {
            var url = ConfigurationManager.AppSettings["apiBaseUrl"];
            var endpoint = $"{url}/api/solicitudJusticiaGratuita";
            var content = new StringContent(body);

            HttpResponseMessage httpResponse = await _httpClient.PostAsync(endpoint, content);
            httpResponse.EnsureSuccessStatusCode();
            string json = await httpResponse.Content.ReadAsStringAsync();

            Response response = new Response();
            response = JsonSerializer.Deserialize<Response>(json);
            return response;
        }
    }
}