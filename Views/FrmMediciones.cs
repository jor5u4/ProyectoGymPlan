///Estudiantes: Nathaly Bejarano Rodriguez / Jorsua Redondo Jimenez
///Profesor: Luis Felipe Mora
///Proyecto 1 Tecnicas de programacion
///Universidad Politecnica Internacional

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using ProyectoGymPlan.Models;

namespace ProyectoGymPlan.Views
{
    public partial class FrmMediciones : Form
    {
        private UsuarioBasico usuario;

        public FrmMediciones(UsuarioBasico usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            Load += FrmMediciones_Load;
        }

        private void FrmMediciones_Load(object? sender, EventArgs e)
        {
            lblTitulo.Text = "MIS MEDICIONES";
            CargarMediciones();
        }

        private void CargarMediciones()
        {
            dgvMediciones.Rows.Clear();

            foreach (Medicion medicion in usuario.HistorialMediciones.OrderByDescending(m => m.Fecha))
            {
                dgvMediciones.Rows.Add(
                    medicion.Fecha.ToString("dd/MM/yyyy"),
                    medicion.Peso.ToString("0.00"),
                    medicion.Altura.ToString("0.00"),
                    medicion.Imc.ToString("0.00"),
                    medicion.Brazo.ToString("0.00"),
                    medicion.Pecho.ToString("0.00"),
                    medicion.Cintura.ToString("0.00"),
                    medicion.Cadera.ToString("0.00"),
                    medicion.Pierna.ToString("0.00")
                );
            }
        }

        private void btnRegistrarMedicion_Click(object? sender, EventArgs e)
        {
            if (!double.TryParse(txtPeso.Text, out double peso) ||
                !double.TryParse(txtAltura.Text, out double altura))
            {
                MessageBox.Show("Ingrese un peso y una altura válidos.");
                return;
            }

            if (peso < 30 || peso > 300)
            {
                MessageBox.Show("El peso debe estar entre 30 y 300 kg.");
                return;
            }

            if (altura < 100 || altura > 250)
            {
                MessageBox.Show("La altura debe estar entre 100 y 250 cm.");
                return;
            }

            if (!ObtenerMedida(txtBrazo.Text, out double brazo) ||
                !ObtenerMedida(txtPecho.Text, out double pecho) ||
                !ObtenerMedida(txtCintura.Text, out double cintura) ||
                !ObtenerMedida(txtCadera.Text, out double cadera) ||
                !ObtenerMedida(txtPierna.Text, out double pierna))
            {
                MessageBox.Show("Las medidas corporales deben ser números positivos o estar vacías.");
                return;
            }

            if (usuario.HistorialMediciones == null)
            {
                usuario.HistorialMediciones = new List<Medicion>();
            }

            if (usuario.Insignias == null)
            {
                usuario.Insignias = new List<Insignias>();
            }

            double imc = peso / Math.Pow(altura / 100.0, 2);

            Medicion nuevaMedicion = new Medicion(
                DateTime.Now,
                peso,
                altura,
                imc,
                brazo,
                pecho,
                cintura,
                cadera,
                pierna
            );

            double pesoAnterior = usuario.Peso;
            double alturaAnterior = usuario.Altura;
            double imcAnterior = usuario.Imc;

            usuario.HistorialMediciones.Add(nuevaMedicion);

            usuario.Peso = peso;
            usuario.Altura = altura;
            usuario.Imc = imc;

            List<Insignias> insigniasAgregadas = AgregarInsignias(nuevaMedicion);

            if (!GuardarUsuarios())
            {
                usuario.HistorialMediciones.Remove(nuevaMedicion);
                usuario.Peso = pesoAnterior;
                usuario.Altura = alturaAnterior;
                usuario.Imc = imcAnterior;

                foreach (Insignias insignia in insigniasAgregadas)
                {
                    usuario.Insignias.Remove(insignia);
                }

                MessageBox.Show("No se pudieron guardar las mediciones.");
                return;
            }

            CargarMediciones();

            txtPeso.Clear();
            txtAltura.Clear();
            txtBrazo.Clear();
            txtPecho.Clear();
            txtCintura.Clear();
            txtCadera.Clear();
            txtPierna.Clear();

            string mensaje = $"Medición registrada correctamente.\n\nSu IMC es: {imc:0.00}";

            if (insigniasAgregadas.Count > 0)
            {
                mensaje += "\n\n¡Nueva insignia!";

                foreach (Insignias insignia in insigniasAgregadas)
                {
                    mensaje += $"\n- {insignia.Nombre}";
                }
            }

            MessageBox.Show(mensaje);
        }

        private List<Insignias> AgregarInsignias(Medicion medicionActual)
        {
            List<Insignias> nuevasInsignias = new List<Insignias>();
            int cantidadMediciones = usuario.HistorialMediciones.Count;

            if (cantidadMediciones >= 1 &&
                !usuario.Insignias.Any(i => i.Nombre == "Primera medición"))
            {
                AgregarInsignia("Primera medición", nuevasInsignias);
            }

            if (cantidadMediciones >= 5 &&
                !usuario.Insignias.Any(i => i.Nombre == "Constancia: 5 mediciones"))
            {
                AgregarInsignia("Constancia: 5 mediciones", nuevasInsignias);
            }

            Medicion? medicionAnteriorCintura = ObtenerMedicionAnterior(
                medicionActual,
                m => m.Cintura
            );

            if (medicionActual.Cintura > 0 &&
                medicionAnteriorCintura != null &&
                medicionAnteriorCintura.Cintura - medicionActual.Cintura >= 2 &&
                !usuario.Insignias.Any(i => i.Nombre == "Progreso de cintura"))
            {
                AgregarInsignia("Progreso de cintura", nuevasInsignias);
            }

            Medicion? medicionAnteriorBrazo = ObtenerMedicionAnterior(
                medicionActual,
                m => m.Brazo
            );

            if (medicionActual.Brazo > 0 &&
                medicionAnteriorBrazo != null &&
                medicionActual.Brazo - medicionAnteriorBrazo.Brazo >= 2 &&
                !usuario.Insignias.Any(i => i.Nombre == "Progreso de brazo"))
            {
                AgregarInsignia("Progreso de brazo", nuevasInsignias);
            }

            Medicion? medicionAnteriorPierna = ObtenerMedicionAnterior(
                medicionActual,
                m => m.Pierna
            );

            if (medicionActual.Pierna > 0 &&
                medicionAnteriorPierna != null &&
                medicionActual.Pierna - medicionAnteriorPierna.Pierna >= 2 &&
                !usuario.Insignias.Any(i => i.Nombre == "Progreso de pierna"))
            {
                AgregarInsignia("Progreso de pierna", nuevasInsignias);
            }

            return nuevasInsignias;
        }

        private Medicion? ObtenerMedicionAnterior(
            Medicion medicionActual,
            Func<Medicion, double> obtenerValor)
        {
            return usuario.HistorialMediciones
                .Where(m => m != medicionActual &&
                            m.Fecha < medicionActual.Fecha &&
                            obtenerValor(m) > 0)
                .OrderByDescending(m => m.Fecha)
                .FirstOrDefault();
        }

        private void AgregarInsignia(
            string nombre,
            List<Insignias> nuevasInsignias)
        {
            Insignias insignia = new Insignias(
                nombre,
                TipoInsignia.Logro
            );

            usuario.Insignias.Add(insignia);
            nuevasInsignias.Add(insignia);
        }

        private static bool ObtenerMedida(string texto, out double medida)
        {
            medida = 0;

            if (string.IsNullOrWhiteSpace(texto))
            {
                return true;
            }

            if (!double.TryParse(texto, out medida))
            {
                return false;
            }

            return medida >= 0 && medida <= 250;
        }

        private bool GuardarUsuarios()
        {
            try
            {
                string ruta = Path.Combine(AppContext.BaseDirectory, "usuarios.json");

                List<UsuarioBasico> usuarios = new List<UsuarioBasico>();

                if (File.Exists(ruta))
                {
                    string contenido = File.ReadAllText(ruta);

                    usuarios = JsonSerializer.Deserialize<List<UsuarioBasico>>(contenido)
                        ?? new List<UsuarioBasico>();
                }

                int indice = usuarios.FindIndex(
                    u => u.NombreUsuario == usuario.NombreUsuario
                );

                if (indice >= 0)
                {
                    usuarios[indice] = usuario;
                }
                else
                {
                    usuarios.Add(usuario);
                }

                string json = JsonSerializer.Serialize(
                    usuarios,
                    new JsonSerializerOptions { WriteIndented = true }
                );

                File.WriteAllText(ruta, json);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
