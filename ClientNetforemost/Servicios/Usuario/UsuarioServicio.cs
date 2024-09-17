using System.Text;
using Entidad;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;

namespace ClientNetforemost.Servicios.Usuario
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public UsuarioServicio(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            _httpClient.BaseAddress = new Uri("http://localhost:5043/api/");
        }

        public async Task<List<Entidad.Usuario>> ObtenerUsuariosAsync()
        {

            var apiKey = _config
                ["ApiSettings:ApiKey"];

            if (!_httpClient.DefaultRequestHeaders.Contains("x-api-key"))
            {
                _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);

            }
            var response = await _httpClient.GetAsync("Usuarios");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Entidad.Usuario>>(content) ?? new List<Entidad.Usuario>();


        }

        public async Task<Entidad.Usuario> ObtenerUsuarioAsync(int id)
        {

            var apiKey = _config
                ["ApiSettings:ApiKey"];

            if (!_httpClient.DefaultRequestHeaders.Contains("x-api-key"))
            {
                _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);

            }
            var response = await _httpClient.GetAsync($"Usuarios/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Entidad.Usuario>(content) ?? new Entidad.Usuario();

        }

        public Task EditarUsuario(Entidad.Usuario usuario)
        {
            var apiKey = _config["ApiSettings:ApiKey"];

            if (!_httpClient.DefaultRequestHeaders.Contains("x-api-key"))
            {
                _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
            }

            usuario.Tareas = [];

            var json = JsonConvert.SerializeObject(usuario);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.PutAsync($"Usuarios/{usuario.Id}", data);

            return Task.CompletedTask;
        }

        public Task CrearUsuario(Entidad.Usuario usuario)
        {
            var apiKey = _config
                ["ApiSettings:ApiKey"];

            if (!_httpClient.DefaultRequestHeaders.Contains("x-api-key"))
            {
                _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);

            }

            usuario.Tareas = [];

            var json = JsonConvert.SerializeObject(usuario);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.PostAsync("Usuarios", data);

            return Task.CompletedTask;
        }
    }
}