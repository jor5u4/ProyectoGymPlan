using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGymPlan.Models
{
    public abstract class Usuario
    {

        public string Nombre { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;

        public int Edad { get; set; }
        public double Peso { get; set; }
        public double Imc { get; set; }
        public Usuario() { }

        public Usuario(string nombre, string nombreUsuario, string contrasena, int edad, double peso, double imc)
        {
            Nombre = nombre;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            Edad = edad;
            Peso = peso;
            Imc = imc;
        }
        public virtual string ObtenerPerfil()
        {
            return $"Perfil de: {Nombre} | IMC: {Imc}";
        }
    }
}
