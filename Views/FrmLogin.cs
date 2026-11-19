using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var usuario = controlador.ValidarCredenciales(nombreUsuario, contrasena);

            if (usuario != null)
            {
                MessageBox.Show($"¡Bienvenido, {usuario.Nombre}!");
                return;
            }

            var entrenador = controlador.ValidarCredencialesEntrenador(nombreUsuario, contrasena);

            if (entrenador != null)
            {
                MessageBox.Show($"¡Bienvenido, {entrenador.Nombre}!");
                return;
            }

            MessageBox.Show("Usuario o contraseña incorrectos.");

        }

    }
}
