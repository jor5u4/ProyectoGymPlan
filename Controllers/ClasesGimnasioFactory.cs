///Estudiantes: Nathaly Bejarano Rodriguez / Jorsua Redondo Jimenez
///Profesor: Luis Felipe Mora
///Proyecto 1 Tecnicas de programacion
///Universidad Politecnica Internacional

using System;
using System.Collections.Generic;
using ProyectoGymPlan.Models;

namespace ProyectoGymPlan.Controllers
{
    public enum TipoClase
    {
        Yoga,
        Crossfit,
        Zumba,
        Spinning,
        HoraGimnasioAbierto

    }
    // Aplica el patrón Simple Factory para centralizar la creación de las clases del gimnasio.
    public static class ClaseGimnasioFactory
    {
        public static ClaseGimnasio Crear(TipoClase tipo)
        {
            return tipo switch
            {
                TipoClase.Yoga => new Yoga(),
                TipoClase.Crossfit => new Crossfit(),
                TipoClase.Zumba => new Zumba(),
                TipoClase.Spinning => new Spinning(),
                TipoClase.HoraGimnasioAbierto => new HoraGimnasioAbierto(),
                _ => throw new ArgumentOutOfRangeException(nameof(tipo), tipo, "Tipo de clase no soportado.")
            };
        }

        public static List<ClaseGimnasio> CrearTodas()
        {
            List<ClaseGimnasio> clases = new List<ClaseGimnasio>();

            foreach (TipoClase tipo in Enum.GetValues<TipoClase>())
            {
                clases.Add(Crear(tipo));
            }

            return clases;
        }
    }
}
