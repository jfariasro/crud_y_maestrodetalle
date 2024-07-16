using AppWebBlazor.Shared;

namespace AppWebBlazor.Client.Services.Interfaces
{
    public interface IProductoService
    {
        Task<List<ProductoDTO>> Listar();

        Task<bool> Registrar(ProductoDTO productoDTO);

        Task<bool> Editar(int id, ProductoDTO productoDTO);

        Task<bool> Eliminar(int id);
    }
}
