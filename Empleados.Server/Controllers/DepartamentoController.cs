using Empleados.Server.Db;
using Empleados.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Empleados.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        //get
        [HttpGet]
        public async Task<ActionResult> GetDepartamento()
        {
            //inicializa la respuesta para mandarla al shared
            var responseApi= new ResponseAPI<List<DepartamentoDTO>>();
            
            try
            {

                var sql = $@"SELECT * FROM Departamento;";
                var datos = await Conexion.GetAll<DepartamentoDTO>(sql);
                
                responseApi.EsCorrecto = true;
                responseApi.Valor = (List<DepartamentoDTO>?)datos;
                return Ok(responseApi);

            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje=ex.Message;
                return BadRequest(responseApi);
            }

        }
    }
}
