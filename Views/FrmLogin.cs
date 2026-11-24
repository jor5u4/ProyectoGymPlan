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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            Button btnRegistrarse = new Button();
            btnRegistrarse.Text = "Registrarse";
            btnRegistrarse.Location = new Point(402, 425);
            btnRegistrarse.Size = new Size(180, 40);
            btnRegistrarse.Click += btnRegistrarse_Click;
            Controls.Add(btnRegistrarse);

            lblRecuperar.Cursor = Cursors.Hand;
            lblRecuperar.Click += lblRecuperar_Click;
        }

        private void lblRecuperar_Click(object? sender, EventArgs e)
        {
            using FrmRecuperarContrasena recuperar = new FrmRecuperarContrasena(txtUsuario.Text.Trim());

            if (recuperar.ShowDialog(this) == DialogResult.OK)
            {
                txtUsuario.Text = recuperar.NombreUsuario;
                txtContrasena.Clear();
                txtContrasena.Focus();
            }
        }

        private void btnRegistrarse_Click(object? sender, EventArgs e)
        {
            using FrmRegistro registro = new FrmRegistro();

            if (registro.ShowDialog(this) == DialogResult.OK)
            {
                txtUsuario.Text = registro.NombreUsuarioRegistrado;
                txtContrasena.Clear();
                txtContrasena.Focus();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            UsuarioController controlador = new UsuarioController();

            string nombreUsuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            var usuario = controlador.ValidarCredenciales(
                nombreUsuario,
                contrasena
            );

            string nombre = "";
            bool esEntrenador = false;

            if (usuario != null)
            {
                nombre = usuario.Nombre;
            }
            else
            {
                var entrenador = controlador.ValidarCredencialesEntrenador(
                    nombreUsuario,
                    contrasena
                );

                if (entrenador != null)
                {
                    nombre = entrenador.Nombre;
                    esEntrenador = true;
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                    return;
                }
            }

            FrmPrincipal principal = new FrmPrincipal(nombre, esEntrenador, usuario);
            principal.Show();
            this.Hide();
        }
    }
}
