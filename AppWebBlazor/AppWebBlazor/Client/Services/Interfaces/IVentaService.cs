using AppWebBlazor.Shared;

namespace AppWebBlazor.Client.Services.Interfaces
{
    public interface IVentaService
    {
        Task<bool> Registrar(VentaDTO ventaDTO);
    }
}
