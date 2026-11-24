///Estudiantes: Nathaly Bejarano Rodriguez / Jorsua Redondo Jimenez
///Profesor: Luis Felipe Mora
///Proyecto 1 Tecnicas de programacion
///Universidad Politecnica Internacional

using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoGymPlan.Models;

namespace ProyectoGymPlan.Controllers
{
    public class ResumenVisitas
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int CantidadVisitas { get; set; }
    }

    public class ResumenPersonal
    {
        public int VisitasEnRango { get; set; }
        public double? CambioPeso { get; set; }
        public double? CambioCintura { get; set; }
        public int InsigniasLogro { get; set; }
        public int InsigniasVerguenza { get; set; }
    }

    public class FiltroEstadisticas
    {
        public static List<ResumenVisitas> ObtenerTopVisitantes(
            List<UsuarioBasico> usuarios, DateTime desde, DateTime hasta, int cantidad = 10)
        {
            return CalcularVisitas(usuarios, desde, hasta)
                .OrderByDescending(resumen => resumen.CantidadVisitas)
                .ThenBy(resumen => resumen.NombreUsuario, StringComparer.OrdinalIgnoreCase)
                .Take(cantidad)
                .ToList();
        }

        public static List<ResumenVisitas> ObtenerTopAusentes(
            List<UsuarioBasico> usuarios, DateTime desde, DateTime hasta, int cantidad = 10)
        {
            return CalcularVisitas(usuarios, desde, hasta)
                .OrderBy(resumen => resumen.CantidadVisitas)
                .ThenBy(resumen => resumen.NombreUsuario, StringComparer.OrdinalIgnoreCase)
                .Take(cantidad)
                .ToList();
        }

        public ResumenPersonal ObtenerResumenPersonal(UsuarioBasico usuario, DateTime desde, DateTime hasta)
        {
            ValidarRango(desde, hasta);

            List<Insignias> insignias = usuario.Insignias ?? new List<Insignias>();

            return new ResumenPersonal
            {
                VisitasEnRango = ContarVisitas(usuario, desde, hasta),
                CambioPeso = CalcularCambio(usuario, desde, hasta, medicion => medicion.Peso),
                CambioCintura = CalcularCambio(usuario, desde, hasta, medicion => medicion.Cintura),
                InsigniasLogro = insignias.Count(i => i.TipoInsignia == TipoInsignia.Logro),
                InsigniasVerguenza = insignias.Count(i => i.TipoInsignia == TipoInsignia.Verguenza)
            };
        }

        public static void ValidarRango(DateTime desde, DateTime hasta)
        {
            if (desde.Date > hasta.Date)
            {
                throw new ArgumentException("La fecha inicial no puede ser posterior a la fecha final.");
            }
        }

        public static int ContarVisitas(UsuarioBasico usuario, DateTime desde, DateTime hasta)
        {
            List<DateTime> visitas = usuario.HistorialVisitas ?? new List<DateTime>();

            return visitas.Count(visita => visita.Date >= desde.Date && visita.Date <= hasta.Date);
        }

        private static List<ResumenVisitas> CalcularVisitas(
            List<UsuarioBasico> usuarios, DateTime desde, DateTime hasta)
        {
            ValidarRango(desde, hasta);

            return usuarios
                .Select(usuario => new ResumenVisitas
                {
                    NombreUsuario = usuario.NombreUsuario,
                    Nombre = usuario.Nombre,
                    CantidadVisitas = ContarVisitas(usuario, desde, hasta)
                })
                .ToList();
        }

        private static double? CalcularCambio(
            UsuarioBasico usuario, DateTime desde, DateTime hasta, Func<Medicion, double> medida)
        {
            List<Medicion> mediciones = (usuario.HistorialMediciones ?? new List<Medicion>())
                .Where(m => m.Fecha.Date >= desde.Date && m.Fecha.Date <= hasta.Date)
                .Where(m => medida(m) > 0)
                .OrderBy(m => m.Fecha)
                .ToList();

            if (mediciones.Count < 2)
            {
                return null;
            }

            return medida(mediciones.Last()) - medida(mediciones.First());
        }
    }
}
