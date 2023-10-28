using Empleados.Shared;
using System.Net.Http.Json;

namespace Empleados.Client.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly HttpClient _httpClient;

        public DepartamentoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<DepartamentoDTO>> ListaDepartamento()
        {
            //Obtengo el resultado de la api y valido que contenga el valor
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<List<DepartamentoDTO>>>("api/Departamento");
            if (result !.EsCorrecto)
            {
                return result.Valor!;

            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }



    }
}
