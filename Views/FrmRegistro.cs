///Estudiantes: Nathaly Bejarano Rodriguez / Jorsua Redondo Jimenez
///Profesor: Luis Felipe Mora
///Proyecto 1 Tecnicas de programacion
///Universidad Politecnica Internacional

using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ProyectoGymPlan.Controllers;

namespace ProyectoGymPlan.Views
{
    public class FrmRegistro : Form
    {
        private readonly TextBox txtNombre = new TextBox();
        private readonly TextBox txtUsuario = new TextBox();
        private readonly TextBox txtContrasena = new TextBox();
        private readonly TextBox txtConfirmar = new TextBox();
        private readonly NumericUpDown nudEdad = new NumericUpDown();
        private readonly TextBox txtPeso = new TextBox();
        private readonly TextBox txtAltura = new TextBox();
        private readonly Button btnRegistrar = new Button();
        private readonly Button btnCancelar = new Button();

        public string NombreUsuarioRegistrado { get; private set; } = string.Empty;

        public FrmRegistro()
        {
            Text = "Registro de usuario";
            ClientSize = new Size(420, 420);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            txtContrasena.UseSystemPasswordChar = true;
            txtConfirmar.UseSystemPasswordChar = true;
            nudEdad.Minimum = 12;
            nudEdad.Maximum = 100;
            nudEdad.Value = 18;

            AgregarCampo("Nombre completo", txtNombre, 20);
            AgregarCampo("Nombre de usuario", txtUsuario, 70);
            AgregarCampo("Contraseña (mín. 4)", txtContrasena, 120);
            AgregarCampo("Confirmar contraseña", txtConfirmar, 170);
            AgregarCampo("Edad", nudEdad, 220);
            AgregarCampo("Peso (kg)", txtPeso, 270);
            AgregarCampo("Altura (cm)", txtAltura, 320);

            btnRegistrar.Text = "Registrarse";
            btnRegistrar.Location = new Point(150, 370);
            btnRegistrar.Size = new Size(120, 36);
            btnRegistrar.Click += btnRegistrar_Click;
            Controls.Add(btnRegistrar);

            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(285, 370);
            btnCancelar.Size = new Size(120, 36);
            btnCancelar.DialogResult = DialogResult.Cancel;
            Controls.Add(btnCancelar);

            AcceptButton = btnRegistrar;
            CancelButton = btnCancelar;
        }

        private void AgregarCampo(string etiqueta, Control campo, int y)
        {
            Controls.Add(new Label { Text = etiqueta, Location = new Point(20, y + 4), Size = new Size(170, 25) });
            campo.Location = new Point(200, y);
            campo.Size = new Size(200, 27);
            Controls.Add(campo);
        }

        private void btnRegistrar_Click(object? sender, EventArgs e)
        {
            if (txtContrasena.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            if (!TryLeerNumero(txtPeso.Text, out double peso) || !TryLeerNumero(txtAltura.Text, out double altura))
            {
                MessageBox.Show("Ingrese un peso y una altura numéricos.");
                return;
            }

            Usuario controlador = new Usuario();

            bool registrado = controlador.RegistrarUsuario(
                txtNombre.Text,
                txtUsuario.Text,
                txtContrasena.Text,
                (int)nudEdad.Value,
                peso,
                altura,
                out string mensaje);

            MessageBox.Show(mensaje);

            if (registrado)
            {
                NombreUsuarioRegistrado = txtUsuario.Text.Trim();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private static bool TryLeerNumero(string texto, out double valor)
        {
            return double.TryParse(
                texto.Trim().Replace(',', '.'),
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out valor);
        }
    }
}
