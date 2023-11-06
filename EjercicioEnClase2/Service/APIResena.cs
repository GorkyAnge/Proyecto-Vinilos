﻿using EjercicioEnClase2.Models;
using Newtonsoft.Json;
using System.Text;

namespace EjercicioEnClase2.Service
{
    public class APIResena : IAPIResena
    {
        public static string _baseUrl;
        public HttpClient _httpClient;
        public APIResena()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            _baseUrl = "http://localhost:5240/";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        
        
        
        public async Task<Resena> GetProducto(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Resena/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Resena resena = JsonConvert.DeserializeObject<Resena>(json_response);
                return resena;
            }
            return new Resena();
        }

        public async Task<List<Resena>> GetResenas(int ProductoId)
        {
            var response = await _httpClient.GetAsync($"Resena/{ProductoId}");

            Console.WriteLine(await response.Content.ReadAsStringAsync());

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrWhiteSpace(json_response))
                {
                    List<Resena> resenas = JsonConvert.DeserializeObject<List<Resena>>(json_response);
                    return resenas;
                }
            }

            return new List<Resena>();
        }

        public async Task<Resena> PostResena(Resena resena)
        {
            var content = new StringContent(JsonConvert.SerializeObject(resena), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Resena/", content);

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Resena resena2 = JsonConvert.DeserializeObject<Resena>(json_response);
                return resena2;
            }
            return new Resena();
        }





    }
}
