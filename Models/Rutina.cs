using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGymPlan.Models
{
    public class Rutina
    {

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public List<Ejercicio> Ejercicios { get; set; }


        public Rutina(String nombre, string descripcion, DateTime fechainicio, DateTime fechavencimiento)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            FechaInicio = fechainicio;
            FechaVencimiento = fechavencimiento;
            Ejercicios= new List<Ejercicio>();
        }


    }
}
