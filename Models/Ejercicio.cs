///Estudiantes: Nathaly Bejarano Rodriguez / Jorsua Redondo Jimenez
///Profesor: Luis Felipe Mora
///Proyecto 1 Tecnicas de programacion
///Universidad Politecnica Internacional

using System;

namespace ProyectoGymPlan.Models
{
    public class Ejercicio
    {
        public string Nombre { get; set; } = string.Empty;
        public int Series { get; set; }
        public int Repeticiones { get; set; }
        public double Peso { get; set; }
        public int DuracionMinutos { get; set; }

        public Ejercicio()
        {
        }

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
