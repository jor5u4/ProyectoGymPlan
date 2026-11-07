using ProyectoGymPlan.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGymPlan.Models
{
    public class UsuarioBasico:Usuario
    {
        //ahora aqui le damos la lsita de los elementos que tiene que tener un usuario
        public List<Rutina> Rutinas { get; set; }
        public List<Insignias> Insignias { get; set; }
        public List<DateTime> HistorialVisitas { get; set; }
        public List<medicion> HistorialMediciones { get; set; }


        // Constructor vacío obligatorio para la lectura del JSON
        public UsuarioBasico()
        {
            Rutinas = new List<Rutina>();
            Insignias = new List<Insignias>();
            HistorialVisitas = new List<DateTime>();
            HistorialMediciones = new List<medicion>();
        }


        public UsuarioBasico(string nombre, string nombreUsuario, string contrasena, int edad, double peso, double imc)
             : base(nombre, nombreUsuario, contrasena, edad, peso, imc)
        {
            Rutinas = new List<Rutina>();
            Insignias = new List<Insignias>();
            HistorialVisitas = new List<DateTime>();
            HistorialMediciones = new List<medicion>();

            // Registra la medición inicial de ingreso usando peso e IMC
            HistorialMediciones.Add(new medicion(DateTime.Now, peso, imc));
        }


    }
}
