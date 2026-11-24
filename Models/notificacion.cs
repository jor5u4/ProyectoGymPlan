///Estudiantes: Nathaly Bejarano Rodriguez / Jorsua Redondo Jimenez
///Profesor: Luis Felipe Mora
///Proyecto 1 Tecnicas de programacion
///Universidad Politecnica Internacional

using System;

namespace ProyectoGymPlan.Models
{
    public class Notificacion
    {
        public string Mensaje { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = "Informativa";

        public Notificacion()
        {
        }

        public Notificacion(string mensaje, DateTime fecha, string estado = "Informativa")
        {
            Mensaje = mensaje;
            Fecha = fecha;
            Estado = estado;
        }
    }
}


