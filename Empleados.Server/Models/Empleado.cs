namespace Empleados.Server.Models
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }

        public string NombreEmpleado { get; set; } = null!;

        public int IdDepartamento { get; set; }

        public int Sueldo { get; set; }

        public DateTime FechaContrato { get; set; }
    }
}
