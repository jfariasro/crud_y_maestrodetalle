using AppWebBlazor.Client.Services.Interfaces;
using AppWebBlazor.Shared;
using System.Net.Http.Json;

namespace AppWebBlazor.Client.Services
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _httpClient;

        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Editar(int id, ProductoDTO productoDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Producto/Editar/{id}", productoDTO);

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }

        public async Task<bool> Eliminar(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Producto/Eliminar/{id}");

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }

        public async Task<List<ProductoDTO>> Listar()
        {
            var lista = new List<ProductoDTO>();

            lista = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("api/Producto/Listar");

            return lista!;
        }

        public async Task<bool> Registrar(ProductoDTO productoDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Producto/Registrar", productoDTO);

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }
    }
}
