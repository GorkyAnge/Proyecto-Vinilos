using EjercicioEnClase2.Models;
using Newtonsoft.Json;
using System.Text;

namespace EjercicioEnClase2.Service
{
    public class APICompra : IAPICompra
    {
        public static string _baseUrl;
        public HttpClient _httpClient;
        public APICompra()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build(); 
            _baseUrl = "http://localhost:5240/";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<Compra> GetCarrito(int IdCarrito)
        {
            var response = await _httpClient.GetAsync($"/api/Compra/{IdCarrito}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Compra carrito = JsonConvert.DeserializeObject<Compra>(json_response);
                return carrito;
            }
            return new Compra();
        }

        public async Task<bool> AddProducto(int IdCarrito, Producto producto, int Cantidad)
        {
            var item = new { Id = producto.Id, Cantidad = Cantidad };
            var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/Compra/{IdCarrito}/items", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PostCarrito(Compra carrito)
        {
            var content = new StringContent(JsonConvert.SerializeObject(carrito), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/Compra", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCarrito(int IdCarrito)
        {
            var response = await _httpClient.DeleteAsync($"api/Compra/{IdCarrito}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveProducto(int IdCarrito, int Id)
        {
            var response = await _httpClient.DeleteAsync($"api/Compra/{IdCarrito}/items/{Id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCarrito(int IdCarrito, Compra carrito)
        {
            var content = new StringContent(JsonConvert.SerializeObject(carrito), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/Compra/{IdCarrito}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProducto(int IdCarrito, int Id, int Cantidad)
        {
            var item = new { Id = Id, Cantidad = Cantidad };
            var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/Compra/{IdCarrito}/items/{Id}", content);
            return response.IsSuccessStatusCode;
        }
    }
}
