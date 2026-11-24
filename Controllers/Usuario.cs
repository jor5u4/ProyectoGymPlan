///Estudiantes: Nathaly Bejarano Rodriguez / Jorsua Redondo Jimenez
///Profesor: Luis Felipe Mora
///Proyecto 1 Tecnicas de programacion
///Universidad Politecnica Internacional

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ProyectoGymPlan.Models;

namespace ProyectoGymPlan.Controllers
{
    public class Usuario
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

        public bool RegistrarUsuario(
            string nombre,
            string nombreUsuario,
            string contrasena,
            int edad,
            double peso,
            double altura,
            out string mensaje)
        {
            string? error = ValidarDatosRegistro(nombre, nombreUsuario, contrasena, edad, peso, altura);

            if (error != null)
            {
                mensaje = error;
                return false;
            }

            try
            {
                List<UsuarioBasico> usuarios = ObtenerUsuarios();

                if (ExisteNombreUsuario(nombreUsuario.Trim(), usuarios))
                {
                    mensaje = "Ese nombre de usuario ya está en uso.";
                    return false;
                }

                double imc = peso / Math.Pow(altura / 100.0, 2);

                UsuarioBasico nuevo = new UsuarioBasico(
                    nombre.Trim(), nombreUsuario.Trim(), contrasena, edad, peso, imc);
                nuevo.Altura = altura;
                nuevo.HistorialMediciones[0].Altura = altura;

                usuarios.Add(nuevo);
                GuardarUsuarios(usuarios);

                mensaje = "Usuario registrado correctamente. Ya puede iniciar sesión.";
                return true;
            }
            catch (IOException)
            {
                mensaje = "No se pudo guardar el usuario.";
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                mensaje = "No se tiene permiso para guardar el usuario.";
                return false;
            }
            catch (JsonException)
            {
                mensaje = "El archivo de usuarios tiene un formato inválido.";
                return false;
            }
        }

        private static string? ValidarDatosRegistro(
            string nombre, string nombreUsuario, string contrasena, int edad, double peso, double altura)
        {
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(nombreUsuario) ||
                string.IsNullOrWhiteSpace(contrasena))
            {
                return "Complete el nombre, el usuario y la contraseña.";
            }

            if (contrasena.Length < 4)
            {
                return "La contraseña debe tener al menos 4 caracteres.";
            }

            if (edad < 12 || edad > 100)
            {
                return "La edad debe estar entre 12 y 100 años.";
            }

            if (peso < 30 || peso > 300)
            {
                return "El peso debe estar entre 30 y 300 kg.";
            }

            if (altura < 100 || altura > 250)
            {
                return "La altura debe estar entre 100 y 250 cm.";
            }

            return null;
        }

        private bool ExisteNombreUsuario(string nombreUsuario, List<UsuarioBasico> usuarios)
        {
            bool existeComoUsuario = usuarios.Any(u =>
                string.Equals(u.NombreUsuario, nombreUsuario, StringComparison.OrdinalIgnoreCase));

            string rutaEntrenadores = Path.Combine(AppContext.BaseDirectory, "entrenadores.json");

            if (existeComoUsuario || !File.Exists(rutaEntrenadores))
            {
                return existeComoUsuario;
            }

            List<Entrenador> entrenadores = JsonSerializer.Deserialize<List<Entrenador>>(
                File.ReadAllText(rutaEntrenadores)) ?? new List<Entrenador>();

            return entrenadores.Any(e =>
                string.Equals(e.NombreUsuario, nombreUsuario, StringComparison.OrdinalIgnoreCase));
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
