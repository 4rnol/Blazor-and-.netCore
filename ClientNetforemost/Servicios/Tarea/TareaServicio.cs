using System.Text;
using Newtonsoft.Json;

namespace ClientNetforemost.Servicios.Tarea
{
    public class TareaServicio : ITareaServicio
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public TareaServicio(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            _httpClient.BaseAddress = new Uri("http://localhost:5043/api/");
        }

        public async Task EditarTarea(Entidad.Tarea tarea)
        {
            var apiKey = _config["ApiSettings:ApiKey"];

            if (!_httpClient.DefaultRequestHeaders.Contains("x-api-key"))
            {
                _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
            }

            var json = JsonConvert.SerializeObject(tarea);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("Tarea", data);

        }

        public async Task CrearTarea(Entidad.Tarea tarea)
        {
            var apiKey = _config["ApiSettings:ApiKey"];

            if (!_httpClient.DefaultRequestHeaders.Contains("x-api-key"))
            {
                _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
            }

            var json = JsonConvert.SerializeObject(tarea);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync("Tarea", data);
        }
    }
}
