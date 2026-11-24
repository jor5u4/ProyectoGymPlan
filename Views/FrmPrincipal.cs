///Estudiantes: Nathaly Bejarano Rodriguez / Jorsua Redondo Jimenez
///Profesor: Luis Felipe Mora
///Proyecto 1 Tecnicas de programacion
///Universidad Politecnica Internacional

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
        private Button btnRegistrarVisita;
        private Button btnEstadisticas;
        private Button btnClases;

        public FrmPrincipal()
        {
            InitializeComponent();

            btnRutinas.Click -= btnRutinas_Click;
            btnRutinas.Click += btnRutinas_Click;

            btnHistorialVisitas.Click -= btnHistorialVisitas_Click;
            btnHistorialVisitas.Click += btnHistorialVisitas_Click;

            btnMediciones.Click -= btnMediciones_Click;
            btnMediciones.Click += btnMediciones_Click;

            btnNotificaciones.Click -= btnNotificaciones_Click;
            btnNotificaciones.Click += btnNotificaciones_Click;

            btnInsignias.Click -= btnInsignias_Click;
            btnInsignias.Click += btnInsignias_Click;

            btnRegistrarVisita = new Button();
            btnRegistrarVisita.Text = "Registrar visita";
            btnRegistrarVisita.Size = btnRutinas.Size;
            btnRegistrarVisita.Location = new Point(
                btnRutinas.Left,
                btnRutinas.Bottom + 20
            );
            btnRegistrarVisita.Visible = false;
            btnRegistrarVisita.Click += btnRegistrarVisita_Click;

            Controls.Add(btnRegistrarVisita);
            btnRegistrarVisita.BringToFront();

            btnEstadisticas = new Button();
            btnEstadisticas.Text = "Estadísticas";
            btnEstadisticas.Size = btnRutinas.Size;
            btnEstadisticas.Location = new Point(btnRutinas.Left, btnNotificaciones.Bottom + 6);
            btnEstadisticas.Visible = false;
            btnEstadisticas.Click += btnEstadisticas_Click;
            Controls.Add(btnEstadisticas);

            btnClases = new Button();
            btnClases.Text = "Clases del gimnasio";
            btnClases.Size = btnRutinas.Size;
            btnClases.Location = new Point(btnRutinas.Left, btnEstadisticas.Bottom + 6);
            btnClases.Click += btnClases_Click;
            Controls.Add(btnClases);
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
                btnRegistrarVisita.Visible = true;
                btnEstadisticas.Visible = false;
                btnClases.Location = new Point(btnRutinas.Left, btnRegistrarVisita.Bottom + 6);
            }
            else
            {
                btnRutinas.Text = "Mis rutinas";
                btnHistorialVisitas.Visible = true;
                btnMediciones.Visible = true;
                btnInsignias.Visible = true;
                btnNotificaciones.Text = "Mis notificaciones";
                btnNotificaciones.Visible = true;
                btnRegistrarVisita.Visible = false;
                btnEstadisticas.Visible = true;
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
                Controllers.Usuario controlador = new Controllers.Usuario();
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
                formularioRutinas.ShowDialog(this);
                return;
            }

            if (usuario == null)
            {
                MessageBox.Show("No se encontró la información del usuario.");
                return;
            }

            FrmRutinas formularioUsuario = new FrmRutinas(usuario, false);
            formularioUsuario.ShowDialog(this);
        }

        private void btnRegistrarVisita_Click(object sender, EventArgs e)
        {
            if (!esEntrenador)
            {
                MessageBox.Show("Esta opción está disponible para entrenadores.");
                return;
            }

            Controllers.Usuario controlador = new Controllers.Usuario();
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

            controlador.RegistrarVisita(usuarioSeleccionado);

            MessageBox.Show(
                $"La visita de {usuarioSeleccionado.NombreUsuario} se registró correctamente.",
                "Visita registrada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
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
            lblSeleccion.Text = "Seleccione el usuario:";
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
            formularioVisitas.ShowDialog(this);
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
            formularioMediciones.ShowDialog(this);
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            FrmNotificaciones formulario = new FrmNotificaciones(usuario, esEntrenador);
            formulario.ShowDialog(this);
        }

        private void btnInsignias_Click(object sender, EventArgs e)
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

            Controllers.Usuario controlador = new Controllers.Usuario();
            List<UsuarioBasico> usuarios = controlador.ObtenerUsuarios();

            UsuarioBasico? usuarioActualizado = null;

            foreach (UsuarioBasico usuarioGuardado in usuarios)
            {
                if (string.Equals(
                    usuarioGuardado.NombreUsuario,
                    usuario.NombreUsuario,
                    StringComparison.OrdinalIgnoreCase))
                {
                    usuarioActualizado = usuarioGuardado;
                    break;
                }
            }

            if (usuarioActualizado == null)
            {
                MessageBox.Show("No se encontró la información actualizada del usuario.");
                return;
            }

            usuario = usuarioActualizado;

            FrmInsignias formulario = new FrmInsignias(usuario);
            formulario.ShowDialog(this);
        }

        private void btnEstadisticas_Click(object? sender, EventArgs e)
        {
            if (esEntrenador || usuario == null)
            {
                MessageBox.Show("Las estadísticas están disponibles para usuarios básicos.");
                return;
            }

            FrmEstadisticas formulario = new FrmEstadisticas(usuario);
            formulario.ShowDialog(this);
        }

        private void btnClases_Click(object? sender, EventArgs e)
        {
            FrmClases formulario = new FrmClases();
            formulario.ShowDialog(this);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            Close();
        }
    }
}
