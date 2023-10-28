using Empleados.Shared;

namespace Empleados.Client.Services
{
    public interface IDepartamentoService
    {
        Task<List<DepartamentoDTO>> ListaDepartamento();
    }
}
