
namespace ProyectoGymPlan.Models
{    public enum TipoEntrenador
    {
        Personal = 1,
        DeGimnasio = 2
    }
    public class Entrenador : Usuario
    {
        public TipoEntrenador Especialidad { get; set; }

        public Entrenador()
        {
        }
        public Entrenador(
            string nombre,
            string nombreUsuario,
            string contrasena,
            int edad,
            double peso,
            double imc,
            TipoEntrenador especialidad)
            : base(nombre, nombreUsuario, contrasena, edad, peso, imc)
        {
            Especialidad = especialidad;
        }
    }
}
