
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProyectoGymPlan.Controllers;
using ProyectoGymPlan.Models;

namespace ProyectoGymPlan.Views
{
    public partial class FrmPrincipal : Form
    {
        private UsuarioBasico? usuario;
        private bool esEntrenador;

        public FrmPrincipal()
        {
            InitializeComponent();

            btnRutinas.Click += btnRutinas_Click;
            btnHistorialVisitas.Click += btnHistorialVisitas_Click;
            btnMediciones.Click += btnMediciones_Click;
            btnNotificaciones.Click += btnNotificaciones_Click;
        }

        public FrmPrincipal(string nombre, bool esEntrenador, UsuarioBasico? usuario) : this()
        {
            this.usuario = usuario;
            this.esEntrenador = esEntrenador;

            lblBienvenida.Text = $"Bienvenido/a, {nombre}";

            if (esEntrenador)
            {
                btnRutinas.Text = "Administrar rutinas";
                btnHistorialVisitas.Visible = false;
                btnMediciones.Visible = false;
                btnInsignias.Visible = false;
                btnNotificaciones.Text = "Notificaciones";
                btnNotificaciones.Visible = true;
            }
            else
            {
                btnRutinas.Text = "Mis rutinas";
                btnHistorialVisitas.Visible = true;
                btnMediciones.Visible = true;
                btnInsignias.Visible = true;
                btnNotificaciones.Text = "Mis notificaciones";
                btnNotificaciones.Visible = true;
            }
        }

        private void lblBienvenida_Click(object sender, EventArgs e)
        {
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void btnRutinas_Click(object sender, EventArgs e)
        {
            if (esEntrenador)
            {
                UsuarioController controlador = new UsuarioController();
                List<UsuarioBasico> usuarios = controlador.ObtenerUsuarios();

                if (usuarios.Count == 0)
                {
                    MessageBox.Show("No hay usuarios básicos registrados.");
                    return;
                }

                UsuarioBasico? usuarioSeleccionado = SeleccionarUsuario(usuarios);

                if (usuarioSeleccionado == null)
                {
                    return;
                }

                FrmRutinas formularioRutinas = new FrmRutinas(usuarioSeleccionado, true);
                formularioRutinas.ShowDialog();
                return;
            }

            if (usuario == null)
            {
                MessageBox.Show("No se encontró la información del usuario.");
                return;
            }

            FrmRutinas formularioUsuario = new FrmRutinas(usuario, false);
            formularioUsuario.ShowDialog();
        }

        private UsuarioBasico? SeleccionarUsuario(List<UsuarioBasico> usuarios)
        {
            Form formulario = new Form();
            formulario.Text = "Seleccionar usuario";
            formulario.Size = new Size(400, 170);
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.FormBorderStyle = FormBorderStyle.FixedDialog;
            formulario.MaximizeBox = false;
            formulario.MinimizeBox = false;

            Label lblSeleccion = new Label();
            lblSeleccion.Text = "Seleccione el usuario para administrar sus rutinas:";
            lblSeleccion.Location = new Point(15, 15);
            lblSeleccion.Size = new Size(350, 25);

            ComboBox cmbUsuarios = new ComboBox();
            cmbUsuarios.Location = new Point(15, 45);
            cmbUsuarios.Size = new Size(350, 25);
            cmbUsuarios.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuarios.DataSource = usuarios;
            cmbUsuarios.DisplayMember = "NombreUsuario";

            Button btnAceptar = new Button();
            btnAceptar.Text = "Seleccionar";
            btnAceptar.Location = new Point(190, 85);
            btnAceptar.Size = new Size(85, 30);
            btnAceptar.DialogResult = DialogResult.OK;

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(280, 85);
            btnCancelar.Size = new Size(85, 30);
            btnCancelar.DialogResult = DialogResult.Cancel;

            formulario.Controls.Add(lblSeleccion);
            formulario.Controls.Add(cmbUsuarios);
            formulario.Controls.Add(btnAceptar);
            formulario.Controls.Add(btnCancelar);

            formulario.AcceptButton = btnAceptar;
            formulario.CancelButton = btnCancelar;

            if (formulario.ShowDialog(this) == DialogResult.OK)
            {
                return cmbUsuarios.SelectedItem as UsuarioBasico;
            }

            return null;
        }

        private void btnHistorialVisitas_Click(object sender, EventArgs e)
        {
            if (esEntrenador)
            {
                MessageBox.Show("Esta opción está disponible para usuarios básicos.");
                return;
            }

            if (usuario == null)
            {
                MessageBox.Show("No se encontró la información del usuario.");
                return;
            }

            FrmHistorialVisitas formularioVisitas = new FrmHistorialVisitas(usuario);
            formularioVisitas.ShowDialog();
        }

        private void btnMediciones_Click(object sender, EventArgs e)
        {
            if (esEntrenador)
            {
                MessageBox.Show("Esta opción está disponible para usuarios básicos.");
                return;
            }

            if (usuario == null)
            {
                MessageBox.Show("No se encontró la información del usuario.");
                return;
            }

            FrmMediciones formularioMediciones = new FrmMediciones(usuario);
            formularioMediciones.ShowDialog();
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            FrmNotificaciones formulario = new FrmNotificaciones();
            formulario.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            Close();
        }
    }
}
