using Empleados.Server.Db;
using Empleados.Server.Models;
using Empleados.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empleados.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    { 
        //get
        [HttpGet]
        public async Task<ActionResult> GetEmpleado()
        {
            //inicializa la respuesta para mandarla al shared
            var responseApi = new ResponseAPI<List<EmpleadoDTO>>();

            try
            {

                var sql = $@"SELECT * FROM Empleado;";
                var datos = await Conexion.GetAll<EmpleadoDTO>(sql);

                responseApi.EsCorrecto = true;
                responseApi.Valor = (List<EmpleadoDTO>?)datos;
                return Ok(responseApi);

            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
                return BadRequest(responseApi);
            }

        }

        //Buscar
        [HttpGet]
        [Route("Buscar/{ID}")]
        public async Task<ActionResult> Buscar(int ID)
        {
            var responseApi = new ResponseAPI<EmpleadoDTO>();

            try
            {
                var sql = $@"Select * FROM Empleado WHERE IdEmpleado= {ID};" ;
                var datos = await Conexion.GetById<EmpleadoDTO>(sql);

                responseApi.EsCorrecto = true;
                responseApi.Valor = datos;
                return Ok(responseApi);
            }
            catch (Exception)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = "No encontro";
                return BadRequest(responseApi);

            }
        }

        //insert
        [HttpPost]
        public async Task<ActionResult> Post(IEmpleadoDTO empleado)
        {
            var responseApi = new ResponseAPI<bool>();

            try
            {
                var dbEmpleado = new Empleado
                {
                    NombreEmpleado=empleado.NombreEmpleado,
                    IdDepartamento=empleado.IdDepartamento,
                    Sueldo=empleado.Sueldo,
                    FechaContrato=empleado.FechaContrato,
                };
                var sql = $@"INSERT INTO 
                            Empleado(NombreEmpleado,IdDepartamento,
                            Sueldo,FechaContrato) VALUES 
                            (@NombreEmpleado,@IdDepartamento,@Sueldo,@FechaContrato); ";
                var datos = await Conexion.InsertUpdateParam(sql, dbEmpleado);
                if (datos != false){
                    responseApi.EsCorrecto = datos;
                    responseApi.Mensaje = "El empleado se guardo correctamente";
                    return Ok(responseApi);
                }
                else
                    responseApi.EsCorrecto = false;
                responseApi.Mensaje = "No se pudo guardar empleado";
                return BadRequest(responseApi);
            }
            catch (Exception)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = "No se pudo guardar empleado";
                return BadRequest(responseApi);

            }
        }

        //update
        [HttpPut]
        public async Task<ActionResult> Put(EmpleadoDTO empleado)
        {
            var responseApi = new ResponseAPI<bool>();

            try
            {
               
                var sql = $@"UPDATE Empleado SET NombreEmpleado=@NombreEmpleado,
                                    IdDepartamento=@IdDepartamento,
                                    Sueldo=@Sueldo,
                                    FechaContrato=@FechaContrato
                                    WHERE IdEmpleado=@IdEmpleado; ";
                var datos = await Conexion.InsertUpdateParam(sql, empleado);

                responseApi.EsCorrecto = datos;
                responseApi.Mensaje = "El empleado se actualizo correctamente";
                return Ok(responseApi);
            }
            catch (Exception)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = "No se pudo actualizar el empleado";
                return BadRequest(responseApi);

            }
        }

        //delete
        [HttpDelete("Delete/{ID}")]
        public async Task<ActionResult> delete(int ID)
        {
            var responseApi = new ResponseAPI<bool>();
            try
            {
                var sql = $@"DELETE Empleado WHERE IdEmpleado= {ID}; ";
                var datos = await Conexion.InsertUpdate(sql);

                responseApi.EsCorrecto = datos;
                responseApi.Mensaje = "el empleado se elimino correctamente.";
                return Ok(responseApi);
            }
            catch (Exception)
            {
                responseApi.EsCorrecto=false;
                responseApi.Mensaje = "Error al eliminar empleado";
                return BadRequest(responseApi);

            }
        }
    }
}

    

