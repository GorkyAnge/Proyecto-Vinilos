using EjercicioEnClase2.Models;
using Newtonsoft.Json;
using System.Text;

namespace EjercicioEnClase2.Service
{
    public class APIServiceUsuario : IAPIServiceUsuario
    {
        public static string _baseUrl;
        public HttpClient _httpClient;
        public APIServiceUsuario()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings: BaseUrl").Value;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5240");
        }
        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            var response = await _httpClient.GetAsync($"/api/Usuario/{correo}/{clave}");
            if(response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(json_response);
                return usuario;
            }
            return new Usuario();
        }

        public async Task<Usuario> SaveUsuario(Usuario usuario)
        {
            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Usuario/", content);

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Usuario nuevo_usuario = JsonConvert.DeserializeObject<Usuario>(json_response);
                return nuevo_usuario;
            }
            return new Usuario();
        }
    }
}
