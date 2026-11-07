using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGymPlan.Models
{
    public class medicion
    {
        public DateTime Fecha { get; set; }
        public double Peso { get; set; }
        public double Imc { get; set; }

        public double Brazo { get; set; }
        public double Pecho { get; set; }
        public double Cintura { get; set; }
        public double Cadera { get; set; }
        public double Pierna { get; set; }

        public medicion() { }

        public medicion(DateTime fecha, double peso, double imc,
                          double brazo = 0, double pecho = 0, double cintura = 0,
                          double cadera = 0, double pierna = 0)
        {
            Fecha = fecha;
            Peso = peso;
            Imc = imc;
            Brazo = brazo;
            Pecho = pecho;
            Cintura = cintura;
            Cadera = cadera;
            Pierna = pierna;
        }
    }
}
