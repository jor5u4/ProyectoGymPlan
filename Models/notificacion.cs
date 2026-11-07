using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGymPlan.Models
{
    public class notificacion
    {
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }

        public notificacion(string mensaje, DateTime fecha)
        {
            Mensaje = mensaje;
            Fecha = fecha;
        }
    }
}
