///Estudiantes: Nathaly Bejarano Rodriguez / Jorsua Redondo Jimenez
///Profesor: Luis Felipe Mora
///Proyecto 1 Tecnicas de programacion
///Universidad Politecnica Internacional

namespace ProyectoGymPlan.Models
{
    public abstract class ClaseGimnasio
    {
        public string Nombre { get; protected set; } = string.Empty;
        public int DuracionMinutos { get; protected set; }
        public int CupoMaximo { get; protected set; }

        public abstract string ObtenerDescripcion();

        public override string ToString()
        {
            return $"{Nombre} ({DuracionMinutos} min, cupo {CupoMaximo})";
        }
    }

    public class Yoga : ClaseGimnasio
    {
        public Yoga()
        {
            Nombre = "Yoga";
            DuracionMinutos = 60;
            CupoMaximo = 20;
        }

        public override string ObtenerDescripcion()
        {
            return "Flexibilidad, respiración y relajación.";
        }
    }

    public class Crossfit : ClaseGimnasio
    {
        public Crossfit()
        {
            Nombre = "Crossfit";
            DuracionMinutos = 45;
            CupoMaximo = 15;
        }

        public override string ObtenerDescripcion()
        {
            return "Entrenamiento funcional de alta intensidad.";
        }
    }

    public class Zumba : ClaseGimnasio
    {
        public Zumba()
        {
            Nombre = "Zumba";
            DuracionMinutos = 50;
            CupoMaximo = 30;
        }

        public override string ObtenerDescripcion()
        {
            return "Baile aeróbico con música latina.";
        }
    }

    public class Spinning : ClaseGimnasio
    {
        public Spinning()
        {
            Nombre = "Spinning";
            DuracionMinutos = 45;
            CupoMaximo = 25;
        }

        public override string ObtenerDescripcion()
        {
            return "Ciclismo indoor para resistencia cardiovascular.";
        }
    }

    public class HoraGimnasioAbierto : ClaseGimnasio
    {
        public HoraGimnasioAbierto()
        {
            Nombre = "Hora de gimnasio abierto";
            DuracionMinutos = 60;
            CupoMaximo = 50;
        }

        public override string ObtenerDescripcion()
        {
            return "Uso libre de las instalaciones.";
        }
    }
}
