using Empleados.Shared;
using System.Net.Http.Json;

namespace Empleados.Client.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly HttpClient _httpClient;

        public EmpleadoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //get
        public async Task<List<EmpleadoDTO>> GetAll()
        {
            //Obtengo el resultado de la api y valido que contenga el valor
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<List<EmpleadoDTO>>>("api/Empleado");
            if (result!.EsCorrecto)
            {
                return result.Valor!;

            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }

        //get by id
        public async Task<EmpleadoDTO> Buscar(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<EmpleadoDTO>>($"api/Empleado/Buscar/{id}");
            if (result!.EsCorrecto)
            {
                return result.Valor!;

            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }

        //POST
        public async Task<bool> Guardar(EmpleadoDTO empleadoDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Empleado",empleadoDTO);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<bool>>();
            if (response!.EsCorrecto)
            {
                return response.EsCorrecto!;

            }
            else
            {
                throw new Exception(response.Mensaje);
            }
        }

        //PUT
        public async Task<bool> Editar(EmpleadoDTO empleadoDTO)
        {
            var result = await _httpClient.PutAsJsonAsync("api/Empleado", empleadoDTO);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<bool>>();
            if (response!.EsCorrecto)
            {
                return response.EsCorrecto!;

            }
            else
            {
                throw new Exception(response.Mensaje);
            }
        }

        //DELETE
        public async Task<bool> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Empleado/Delete/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<bool>>();
            if (response!.EsCorrecto)
            {
                return response.EsCorrecto!;

            }
            else
            {
                throw new Exception(response.Mensaje);
            }
        }
    }
}
