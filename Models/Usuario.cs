using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGymPlan.Models
{
    public abstract class Usuario
    {

        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; } // Necesaria para el login
        public int Edad { get; set; }
        public double Peso { get; set; }
        public double Imc { get; set; }

        // Constructor vacío (útil para cargar archivos JSON/CSV luego)
        public Usuario() { }

        // Constructor con parámetros
        public Usuario(string nombre, string nombreUsuario, string contrasena, int edad, double peso, double imc)
        {
            Nombre = nombre;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            Edad = edad;
            Peso = peso;
            Imc = imc;
        }

        // Método que podrían compartir o sobrescribir las clases hijas
        public virtual string ObtenerPerfil()
        {
            return $"Perfil de: {Nombre} | IMC: {Imc}";
        }
    }
}
