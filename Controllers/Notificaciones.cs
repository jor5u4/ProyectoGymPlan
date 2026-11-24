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
    public class Notificaciones
    {
        private const int DiasEntreMediciones = 30;
        private const int DiasAvisoMedicion = 7;
        private const int VisitasParaDescanso = 5;
        private const int VisitasMinimasMensuales = 2;
        private const int DiasRutinaNueva = 7;

        private readonly filtroEstadisticas estadisticas = new filtroEstadisticas();

        public List<Notificacion> GenerarParaUsuario(UsuarioBasico usuario, List<UsuarioBasico> todosLosUsuarios)
        {
            List<Notificacion> notificaciones = new List<Notificacion>();

            AgregarNotificacionesDeInsignias(usuario, notificaciones);
            AgregarNotificacionesDeRutinasNuevas(usuario, notificaciones);
            AgregarNotificacionDeDescanso(usuario, notificaciones);
            AgregarNotificacionesDeVerguenza(usuario, todosLosUsuarios, notificaciones);
            AgregarNotificacionDeMedicion(usuario, notificaciones);

            return notificaciones;
        }

        public List<Notificacion> GenerarMedicionesProximas(List<UsuarioBasico> usuarios)
        {
            List<Notificacion> notificaciones = new List<Notificacion>();

            foreach (UsuarioBasico usuario in usuarios)
            {
                int? diasRestantes = ObtenerDiasParaProximaMedicion(usuario);

                if (diasRestantes.HasValue && diasRestantes.Value <= DiasAvisoMedicion)
                {
                    notificaciones.Add(new Notificacion(
                        $"{usuario.NombreUsuario}: {DescribirMedicion(diasRestantes.Value)}",
                        DateTime.Now,
                        "Pendiente"));
                }
            }

            return notificaciones;
        }

        private static void AgregarNotificacionesDeInsignias(UsuarioBasico usuario, List<Notificacion> destino)
        {
            foreach (Insignias insignia in usuario.Insignias ?? new List<Insignias>())
            {
                if (insignia.TipoInsignia == TipoInsignia.Logro)
                {
                    destino.Add(new Notificacion($"¡Has ganado la insignia \"{insignia.Nombre}\"!", DateTime.Now, "Logro"));
                }
                else
                {
                    destino.Add(new Notificacion($"Insignia de la vergüenza: \"{insignia.Nombre}\".", DateTime.Now, "Vergüenza"));
                }
            }
        }

        private static void AgregarNotificacionesDeRutinasNuevas(UsuarioBasico usuario, List<Notificacion> destino)
        {
            DateTime hoy = DateTime.Today;

            foreach (Rutina rutina in usuario.Rutinas ?? new List<Rutina>())
            {
                DateTime inicio = rutina.FechaInicio.Date;

                if (inicio <= hoy && inicio >= hoy.AddDays(-DiasRutinaNueva))
                {
                    destino.Add(new Notificacion($"Nueva rutina agregada: {rutina.Nombre}.", DateTime.Now, "Nueva"));
                }
            }
        }

        private static void AgregarNotificacionDeDescanso(UsuarioBasico usuario, List<Notificacion> destino)
        {
            DateTime hoy = DateTime.Today;
            int visitasSemana = filtroEstadisticas.ContarVisitas(usuario, hoy.AddDays(-6), hoy);

            if (visitasSemana >= VisitasParaDescanso)
            {
                destino.Add(new Notificacion(
                    $"Descansa esta semana: acumulaste {visitasSemana} visitas en los últimos 7 días.",
                    DateTime.Now,
                    "Descanso"));
            }
        }

        private void AgregarNotificacionesDeVerguenza(
            UsuarioBasico usuario, List<UsuarioBasico> todos, List<Notificacion> destino)
        {
            DateTime hoy = DateTime.Today;
            DateTime desde = hoy.AddDays(-30);
            int visitasMes = filtroEstadisticas.ContarVisitas(usuario, desde, hoy);

            if (visitasMes <= VisitasMinimasMensuales)
            {
                destino.Add(new Notificacion(
                    $"Solo tienes {visitasMes} visita(s) en los últimos 30 días. ¡Vuelve al gimnasio!",
                    DateTime.Now,
                    "Vergüenza"));
            }

            bool esTopAusente = estadisticas
                .ObtenerTopAusentes(todos, desde, hoy, 10)
                .Any(resumen => string.Equals(resumen.NombreUsuario, usuario.NombreUsuario, StringComparison.OrdinalIgnoreCase));

            if (esTopAusente)
            {
                destino.Add(new Notificacion(
                    "Estás en el top 10 de ausentes del último mes.",
                    DateTime.Now,
                    "Vergüenza"));
            }
        }

        private static void AgregarNotificacionDeMedicion(UsuarioBasico usuario, List<Notificacion> destino)
        {
            int? diasRestantes = ObtenerDiasParaProximaMedicion(usuario);

            if (diasRestantes.HasValue && diasRestantes.Value <= DiasAvisoMedicion)
            {
                string estado = diasRestantes.Value < 0 ? "Vergüenza" : "Pendiente";
                destino.Add(new Notificacion(DescribirMedicion(diasRestantes.Value), DateTime.Now, estado));
            }
        }

        private static int? ObtenerDiasParaProximaMedicion(UsuarioBasico usuario)
        {
            List<Medicion> mediciones = usuario.HistorialMediciones ?? new List<Medicion>();

            if (mediciones.Count == 0)
            {
                return null;
            }

            DateTime ultima = mediciones.Max(m => m.Fecha).Date;
            DateTime proxima = ultima.AddDays(DiasEntreMediciones);

            return (proxima - DateTime.Today).Days;
        }

        private static string DescribirMedicion(int diasRestantes)
        {
            if (diasRestantes < 0)
            {
                return $"Tu medición tiene {-diasRestantes} día(s) de retraso. ¡Registra una nueva!";
            }

            return $"Tu próxima medición es en {diasRestantes} día(s).";
        }
    }
}
