///Estudiantes: Nathaly Bejarano Rodriguez / Jorsua Redondo Jimenez
///Profesor: Luis Felipe Mora
///Proyecto 1 Tecnicas de programacion
///Universidad Politecnica Internacional

namespace ProyectoGymPlan.Models
{
    public enum TipoInsignia
    {
        Logro,
        Verguenza
    }

    public class Insignias
    {
        public string Nombre { get; set; } = string.Empty;
        public TipoInsignia TipoInsignia { get; set; }

        public Insignias()
        {
        }

        public Insignias(string nombre, TipoInsignia tipoInsignia)
        {
            Nombre = nombre;
            TipoInsignia = tipoInsignia;
        }
    }
}

