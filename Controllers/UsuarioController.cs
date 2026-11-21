
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ProyectoGymPlan.Models;

namespace ProyectoGymPlan.Controllers
{
    public class UsuarioController
    {
        public UsuarioBasico? ValidarCredenciales(string nombreUsuario, string contrasena)
        {
            string ruta = Path.Combine(AppContext.BaseDirectory, "usuarios.json");

            if (!File.Exists(ruta))
            {
                return null;
            }

            string json = File.ReadAllText(ruta);

            List<UsuarioBasico> usuarios = JsonSerializer.Deserialize<List<UsuarioBasico>>(json)
                ?? new List<UsuarioBasico>();

            return usuarios.FirstOrDefault(usuario =>
                string.Equals(usuario.NombreUsuario, nombreUsuario, StringComparison.OrdinalIgnoreCase)
                && usuario.Contrasena == contrasena);
        }

        public Entrenador? ValidarCredencialesEntrenador(string nombreUsuario, string contrasena)
        {
            string ruta = Path.Combine(AppContext.BaseDirectory, "entrenadores.json");

            if (!File.Exists(ruta))
            {
                return null;
            }

            string json = File.ReadAllText(ruta);

            List<Entrenador> entrenadores = JsonSerializer.Deserialize<List<Entrenador>>(json)
                ?? new List<Entrenador>();

            return entrenadores.FirstOrDefault(entrenador =>
                string.Equals(entrenador.NombreUsuario, nombreUsuario, StringComparison.OrdinalIgnoreCase)
                && entrenador.Contrasena == contrasena);
        }

        public List<UsuarioBasico> ObtenerUsuarios()
        {
            string ruta = Path.Combine(AppContext.BaseDirectory, "usuarios.json");

            if (!File.Exists(ruta))
            {
                return new List<UsuarioBasico>();
            }

            string json = File.ReadAllText(ruta);

            return JsonSerializer.Deserialize<List<UsuarioBasico>>(json)
                ?? new List<UsuarioBasico>();
        }

        public void GuardarUsuarios(List<UsuarioBasico> usuarios)
        {
            string ruta = Path.Combine(AppContext.BaseDirectory, "usuarios.json");

            string json = JsonSerializer.Serialize(
                usuarios,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(ruta, json);
        }

        public bool RegistrarVisita(UsuarioBasico usuario)
        {
            try
            {
                List<UsuarioBasico> usuarios = ObtenerUsuarios();

                UsuarioBasico? usuarioGuardado = usuarios.FirstOrDefault(u =>
                    string.Equals(
                        u.NombreUsuario,
                        usuario.NombreUsuario,
                        StringComparison.OrdinalIgnoreCase));

                if (usuarioGuardado == null)
                {
                    return false;
                }

                usuarioGuardado.HistorialVisitas ??= new List<DateTime>();
                usuarioGuardado.Insignias ??= new List<Insignias>();

                DateTime? ultimaVisita = usuarioGuardado.HistorialVisitas
                    .OrderByDescending(fecha => fecha)
                    .Cast<DateTime?>()
                    .FirstOrDefault();

                if (ultimaVisita.HasValue)
                {
                    int diasSinVisitar = (DateTime.Now.Date - ultimaVisita.Value.Date).Days;

                    if (diasSinVisitar >= 7)
                    {
                        AgregarInsigniaVerguenza(
                            usuarioGuardado,
                            "Ausencia de 7 días");
                    }
                }

                usuarioGuardado.HistorialVisitas.Add(DateTime.Now);

                bool tienePrimeraVisita = usuarioGuardado.Insignias.Any(insignia =>
                    string.Equals(
                        insignia.Nombre,
                        "Primera visita",
                        StringComparison.OrdinalIgnoreCase));

                if (!tienePrimeraVisita)
                {
                    usuarioGuardado.Insignias.Add(
                        new Insignias("Primera visita", TipoInsignia.Logro));
                }

                GuardarUsuarios(usuarios);

                usuario.HistorialVisitas = usuarioGuardado.HistorialVisitas;
                usuario.Insignias = usuarioGuardado.Insignias;

                return true;
            }
            catch (IOException)
            {
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (JsonException)
            {
                return false;
            }
        }

        private void AgregarInsigniaVerguenza(
            UsuarioBasico usuario,
            string nombreInsignia)
        {
            bool yaTieneInsignia = usuario.Insignias.Any(insignia =>
                string.Equals(
                    insignia.Nombre,
                    nombreInsignia,
                    StringComparison.OrdinalIgnoreCase));

            if (!yaTieneInsignia)
            {
                usuario.Insignias.Add(
                    new Insignias(nombreInsignia, TipoInsignia.Verguenza));
            }
        }
    }
}
