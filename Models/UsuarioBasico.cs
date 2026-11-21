
using System;
using System.Collections.Generic;

namespace ProyectoGymPlan.Models
{
    public class UsuarioBasico : Usuario
    {
        public List<Rutina> Rutinas { get; set; } = new List<Rutina>();

        public List<Insignias> Insignias { get; set; } = new List<Insignias>();

        public List<DateTime> HistorialVisitas { get; set; } = new List<DateTime>();

        public List<Medicion> HistorialMediciones { get; set; } = new List<Medicion>();

        public UsuarioBasico()
        {
        }

        public UsuarioBasico(
            string nombre,
            string nombreUsuario,
            string contrasena,
            int edad,
            double peso,
            double imc)
            : base(nombre, nombreUsuario, contrasena, edad, peso, imc)
        {
            HistorialMediciones.Add(
                new Medicion(DateTime.Now, peso, Altura, imc)
            );
        }
    }
}
