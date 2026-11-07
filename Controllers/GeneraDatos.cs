using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ProyectoGymPlan.Models;

namespace ProyectoGymPlan.Controllers
{
    public static class GeneraDatos
    {
        private static readonly string ArchivoUsuarios = "usuarios.json";
        private static readonly string ArchivoEntrenadores = "entrenadores.json";

        public static void InicializarSiNoExisten()
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };

            if (!File.Exists(ArchivoEntrenadores))
            {
                var entrenadores = GenerarEntrenadoresBase();
                string jsonEntrenadores = JsonSerializer.Serialize(entrenadores, opciones);
                File.WriteAllText(ArchivoEntrenadores, jsonEntrenadores);
            }

            if (!File.Exists(ArchivoUsuarios))
            {
                var usuarios = GenerarUsuariosBase();
                string jsonUsuarios = JsonSerializer.Serialize(usuarios, opciones);
                File.WriteAllText(ArchivoUsuarios, jsonUsuarios);
            }
        }

        private static List<Entrenador> GenerarEntrenadoresBase()
        {
            var lista = new List<Entrenador>();
            for (int i = 1; i <= 10; i++)
            {
                TipoEntrenador tipo = (i % 2 == 0) ? TipoEntrenador.Personal : TipoEntrenador.DeGimnasio;
                lista.Add(new Entrenador(
                    $"Entrenador {i}",
                    $"coach{i}",
                    "1234",
                    25 + (i % 15),
                    70.0 + (i * 1.5),
                    22.5,
                    tipo
                ));
            }
            return lista;
        }

        private static List<UsuarioBasico> GenerarUsuariosBase()
        {
            var lista = new List<UsuarioBasico>();
            var rnd = new Random(42);

            for (int i = 1; i <= 32; i++)
            {
                double peso = 65.0 + (i * 1.2);
                double imc = 21.0 + (i % 6);
                var usuario = new UsuarioBasico($"Usuario {i}", $"user{i}", "1234", 18 + (i % 25), peso, imc);

                int visitas = rnd.Next(1, 15);
                for (int v = 0; v < visitas; v++)
                {
                    usuario.HistorialVisitas.Add(DateTime.Now.AddDays(-v * 2));
                }

                for (int r = 1; r <= 5; r++)
                {
                    var rutina = new Rutina(
                        $"Rutina {r} - Nivel {r}",
                        $"Descripción de rutina {r} para acondicionamiento",
                        DateTime.Now.AddDays(-10 * r),
                        DateTime.Now.AddDays(15 * r)
                    );

                    rutina.Ejercicios.Add(new Ejercicio("Press Banca", 4, 10, 40.0 + (r * 5)));
                    rutina.Ejercicios.Add(new Ejercicio("Sentadilla", 4, 12, 50.0 + (r * 5)));
                    rutina.Ejercicios.Add(new Ejercicio("Remo con Barra", 3, 10, 35.0 + (r * 2.5)));

                    usuario.Rutinas.Add(rutina);
                }

                usuario.HistorialMediciones.Add(new medicion(DateTime.Now.AddDays(-30), peso + 2.0, imc + 0.8, 32, 95, 82, 96, 54));

                lista.Add(usuario);
            }
            return lista;
        }
    }
}