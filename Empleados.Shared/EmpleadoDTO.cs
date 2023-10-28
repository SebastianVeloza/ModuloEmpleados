using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Shared
{
    public class EmpleadoDTO
    {
        public int IdEmpleado { get; set; }

        //Utilizo el required para obligar a llenar el campo en el cliente
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string NombreEmpleado { get; set; } = null!;

        [Required]
        [Range(1,int.MaxValue,ErrorMessage = "El campo {0} es requerido")]
        public int IdDepartamento { get; set; }

        [Required]
        [Range(1000000, int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public int Sueldo { get; set; }

        public DateTime FechaContrato { get; set; }

        //La uso para obtener el nombre del departamento al que esta afiliado el empleado
        public DepartamentoDTO? Departamento { get; set; }

        
    }
    public class IEmpleadoDTO
    {
        

        //Utilizo el required para obligar a llenar el campo en el cliente
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string NombreEmpleado { get; set; } = null!;

        [Required]
        [Range(1,int.MaxValue,ErrorMessage = "El campo {0} es requerido")]
        public int IdDepartamento { get; set; }

        [Required]
        [Range(1000000, int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public int Sueldo { get; set; }

        public DateTime FechaContrato { get; set; }

       

        
    }
}
