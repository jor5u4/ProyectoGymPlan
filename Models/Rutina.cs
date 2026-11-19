
using System;
using System.Collections.Generic;

namespace ProyectoGymPlan.Models
{
    public class Rutina
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public List<Ejercicio> Ejercicios { get; set; } = new List<Ejercicio>();

        public Rutina()
        {
        }

        public Rutina(string nombre, string descripcion, DateTime fechaInicio, DateTime fechaVencimiento)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaVencimiento = fechaVencimiento;
        }
    }
}
