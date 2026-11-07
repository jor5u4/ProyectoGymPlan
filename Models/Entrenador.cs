using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGymPlan.Models
{

    public enum TipoEntrenador
    {
        Personal = 1,
        DeGimnasio = 2

    }

    public class Entrenador : Usuario

    {
        public TipoEntrenador Especialidad { get; set; }

        public Entrenador(String nombre, string nombreUsuario, string contrasena, int edad, double peso, double imc, TipoEntrenador especialidad)
            : base(nombre, nombreUsuario, contrasena, edad, peso, imc)
        {
            Especialidad = especialidad;

        }


    }
}
