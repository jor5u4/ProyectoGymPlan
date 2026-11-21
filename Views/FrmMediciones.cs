
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        private void FrmMediciones_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "MIS MEDICIONES";

            dgvMediciones.Rows.Clear();

            foreach (Medicion medicion in usuario.HistorialMediciones)
            {
                dgvMediciones.Rows.Add(
                    medicion.Fecha.ToShortDateString(),
                    medicion.Peso.ToString("0.0"),
                    medicion.Altura.ToString("0"),
                    medicion.Imc.ToString("0.00")
                );
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnRegistrarMedicion_Click(object sender, EventArgs e)
        {
            double peso;
            double altura;

            bool pesoValido = double.TryParse(
                txtPeso.Text.Trim().Replace(',', '.'),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out peso
            );

            bool alturaValida = double.TryParse(
                txtAltura.Text.Trim().Replace(',', '.'),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out altura
            );

            if (!pesoValido || !alturaValida)
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

            double imc = peso / Math.Pow(altura / 100.0, 2);

            Medicion nuevaMedicion = new Medicion(
                DateTime.Now,
                peso,
                altura,
                imc
            );

            double pesoAnterior = usuario.Peso;
            double alturaAnterior = usuario.Altura;
            double imcAnterior = usuario.Imc;

            usuario.HistorialMediciones.Add(nuevaMedicion);
            usuario.Peso = peso;
            usuario.Altura = altura;
            usuario.Imc = imc;

            try
            {
                if (!GuardarUsuarios())
                {
                    usuario.HistorialMediciones.Remove(nuevaMedicion);
                    usuario.Peso = pesoAnterior;
                    usuario.Altura = alturaAnterior;
                    usuario.Imc = imcAnterior;
                    return;
                }
            }
            catch (Exception ex)
            {
                usuario.HistorialMediciones.Remove(nuevaMedicion);
                usuario.Peso = pesoAnterior;
                usuario.Altura = alturaAnterior;
                usuario.Imc = imcAnterior;

                MessageBox.Show(
                    "No se pudo guardar la medición: " + ex.Message
                );

                return;
            }

            dgvMediciones.Rows.Add(
                nuevaMedicion.Fecha.ToShortDateString(),
                nuevaMedicion.Peso.ToString("0.0"),
                nuevaMedicion.Altura.ToString("0"),
                nuevaMedicion.Imc.ToString("0.00")
            );

            txtPeso.Clear();
            txtAltura.Clear();

            MessageBox.Show(
                "Medición registrada correctamente.\nIMC: " + imc.ToString("0.00")
            );
        }

        private bool GuardarUsuarios()
        {
            string ruta = Path.Combine(
                AppContext.BaseDirectory,
                "usuarios.json"
            );

            if (!File.Exists(ruta))
            {
                MessageBox.Show("No se encontró el archivo usuarios.json.");
                return false;
            }

            string contenido = File.ReadAllText(ruta);

            JsonSerializerOptions opcionesLectura = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<UsuarioBasico> usuarios =
                JsonSerializer.Deserialize<List<UsuarioBasico>>(
                    contenido,
                    opcionesLectura
                ) ?? new List<UsuarioBasico>();

            int indice = usuarios.FindIndex(
                u => string.Equals(
                    u.NombreUsuario,
                    usuario.NombreUsuario,
                    StringComparison.OrdinalIgnoreCase
                )
            );

            if (indice >= 0)
            {
                usuarios[indice] = usuario;
            }
            else
            {
                usuarios.Add(usuario);
            }

            JsonSerializerOptions opcionesEscritura = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(
                usuarios,
                opcionesEscritura
            );

            File.WriteAllText(ruta, json);

            return true;
        }
    }
}
