using Empleados.Shared;

namespace Empleados.Client.Services
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoDTO>> GetAll();
        Task<EmpleadoDTO> Buscar(int id);

        Task<bool> Guardar(EmpleadoDTO empleadoDTO);
        Task<bool> Editar(EmpleadoDTO empleadoDTO);

        Task<bool> Delete(int id);


    }
}
