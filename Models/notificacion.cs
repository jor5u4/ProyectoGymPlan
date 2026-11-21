
using System;

namespace ProyectoGymPlan.Models
{
    public class Notificacion
    {
        public string Mensaje { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }

        public Notificacion()
        {
        }

        public Notificacion(string mensaje, DateTime fecha)
        {
            Mensaje = mensaje;
            Fecha = fecha;
        }
    }
}
