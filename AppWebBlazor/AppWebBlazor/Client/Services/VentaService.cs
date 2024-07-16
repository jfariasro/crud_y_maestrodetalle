using AppWebBlazor.Client.Services.Interfaces;
using AppWebBlazor.Shared;
using System.Net.Http.Json;

namespace AppWebBlazor.Client.Services
{
    public class VentaService : IVentaService
    {
        private readonly HttpClient _httpClient;

        public VentaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Registrar(VentaDTO ventaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Venta/Registrar", ventaDTO);

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }
    }
}
