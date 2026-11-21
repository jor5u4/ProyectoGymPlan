
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

            List<UsuarioBasico> usuarios = JsonSerializer.Deserialize<List<UsuarioBasico>>(json) ?? new List<UsuarioBasico>();

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

            List<Entrenador> entrenadores = JsonSerializer.Deserialize<List<Entrenador>>(json) ?? new List<Entrenador>();

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
    }
}
