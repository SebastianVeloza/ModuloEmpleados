using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Shared
{
    //Para recibir las respuestas del servidor al cliente
    public class ResponseAPI<T>
    {
    //indico si la operacion del api es correcta o no
        public bool EsCorrecto { get; set; }

        //Devuelve los datos generados del api
        public T? Valor { get; set; }

        //Devuelve si existe algun mensaje
        public String? Mensaje { get; set; }
    }
}
