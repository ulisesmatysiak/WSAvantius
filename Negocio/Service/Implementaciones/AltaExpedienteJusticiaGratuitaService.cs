using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
            ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            var certCollection = store.Certificates.Find(X509FindType.FindByThumbprint, "01cafa8334bd89d7c42ee9394514b7c061a358f5", false);
            if (certCollection.Count > 0)
            {
                var certificate = certCollection[0];
                var handler = new HttpClientHandler();
                handler.ClientCertificates.Add(certificate);
                _httpClient = new HttpClient(handler);
            }
            else
            {
                throw new Exception("Certificado no encontrado.");
            }

            store.Close();
        }

        public Response apiSolicitudJusticiaGratuitaPost(string body)
        {
            var url = ConfigurationManager.AppSettings["apiBaseUrl"];
            var endpoint = $"{url}/api/solicitudJusticiaGratuita";
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            Response response = new Response();
            _httpClient.DefaultRequestHeaders.Add("x-api-version", "3.0");
            _httpClient.DefaultRequestHeaders.Add("entidadPresenta", "A01059");

            try
            {
                HttpResponseMessage httpResponse = _httpClient.PostAsync(endpoint, content).GetAwaiter().GetResult();
                httpResponse.EnsureSuccessStatusCode();

                string json = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                response = JsonSerializer.Deserialize<Response>(json);
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Error de solicitud HTTP: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
            }
            return response;
        }
    }
}