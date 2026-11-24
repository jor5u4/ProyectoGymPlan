///Estudiantes: Nathaly Bejarano Rodriguez / Jorsua Redondo Jimenez
///Profesor: Luis Felipe Mora
///Proyecto 1 Tecnicas de programacion
///Universidad Politecnica Internacional

using System;
using System.Drawing;
using System.Windows.Forms;
using ProyectoGymPlan.Controllers;

namespace ProyectoGymPlan.Views
{
    public class FrmRecuperarContrasena : Form
    {
        private readonly TextBox txtUsuario = new TextBox();
        private readonly NumericUpDown nudEdad = new NumericUpDown();
        private readonly TextBox txtNueva = new TextBox();
        private readonly TextBox txtConfirmar = new TextBox();
        private readonly Button btnRestablecer = new Button();
        private readonly Button btnCancelar = new Button();

        public string NombreUsuario { get; private set; } = string.Empty;

        public FrmRecuperarContrasena(string usuarioInicial)
        {
            Text = "Recuperar contraseña";
            ClientSize = new Size(420, 340);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            txtUsuario.Text = usuarioInicial;
            txtNueva.UseSystemPasswordChar = true;
            txtConfirmar.UseSystemPasswordChar = true;
            nudEdad.Minimum = 12;
            nudEdad.Maximum = 100;
            nudEdad.Value = 18;

            Controls.Add(new Label
            {
                Text = "Para verificar su identidad, ingrese su usuario y su edad registrada.",
                Location = new Point(20, 15),
                Size = new Size(380, 45)
            });

            AgregarCampo("Nombre de usuario", txtUsuario, 70);
            AgregarCampo("Edad registrada", nudEdad, 120);
            AgregarCampo("Nueva contraseña (mín. 4)", txtNueva, 170);
            AgregarCampo("Confirmar contraseña", txtConfirmar, 220);

            btnRestablecer.Text = "Restablecer";
            btnRestablecer.Location = new Point(150, 280);
            btnRestablecer.Size = new Size(120, 36);
            btnRestablecer.Click += btnRestablecer_Click;
            Controls.Add(btnRestablecer);

            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(285, 280);
            btnCancelar.Size = new Size(120, 36);
            btnCancelar.DialogResult = DialogResult.Cancel;
            Controls.Add(btnCancelar);

            AcceptButton = btnRestablecer;
            CancelButton = btnCancelar;
        }

        private void AgregarCampo(string etiqueta, Control campo, int y)
        {
            Controls.Add(new Label { Text = etiqueta, Location = new Point(20, y + 4), Size = new Size(175, 25) });
            campo.Location = new Point(200, y);
            campo.Size = new Size(200, 27);
            Controls.Add(campo);
        }

        private void btnRestablecer_Click(object? sender, EventArgs e)
        {
            if (txtNueva.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            UsuarioController controlador = new UsuarioController();

            bool restablecida = controlador.RestablecerContrasena(
                txtUsuario.Text,
                (int)nudEdad.Value,
                txtNueva.Text,
                out string mensaje);

            MessageBox.Show(mensaje);

            if (restablecida)
            {
                NombreUsuario = txtUsuario.Text.Trim();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
