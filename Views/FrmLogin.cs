
using System;
using System.Windows.Forms;
using ProyectoGymPlan.Controllers;

namespace ProyectoGymPlan.Views
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
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

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            frmRegistroUsuario registroUsuario = new frmRegistroUsuario();
            registroUsuario.Show();
            this.Hide();
        }
    }
}
