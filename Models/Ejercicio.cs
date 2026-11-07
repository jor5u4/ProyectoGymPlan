using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGymPlan.Models
{
    public class Ejercicio
    {
        public string Nombre { get; set; }
        public int Series { get; set; }
        public int Repeticiones { get; set; }
        public double Peso { get; set; } // Fundamental para la estadística de "aumento de pesos"
        public int DuracionMinutos { get; set; } // en caso de cardio

        public Ejercicio(string nombre, int series, int repeticiones, double peso, int duracionMinutos = 0)
        {
            Nombre = nombre;
            Series = series;
            Repeticiones = repeticiones;
            Peso = peso;
            DuracionMinutos = duracionMinutos;
        }
    }
}
