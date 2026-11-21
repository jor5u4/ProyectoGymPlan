
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProyectoGymPlan.Controllers;
using ProyectoGymPlan.Models;

namespace ProyectoGymPlan.Views
{
    public partial class FrmNotificaciones : Form
    {
        public FrmNotificaciones()
        {
            InitializeComponent();
        }

        private void FrmNotificaciones_Load(object sender, EventArgs e)
        {
            dgvNotificaciones.Columns.Clear();
            dgvNotificaciones.Rows.Clear();

            dgvNotificaciones.Columns.Add("colFecha", "Fecha");
            dgvNotificaciones.Columns.Add("colUsuario", "Usuario");
            dgvNotificaciones.Columns.Add("colNotificacion", "Notificación");
            dgvNotificaciones.Columns.Add("colEstado", "Estado");

            dgvNotificaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNotificaciones.ReadOnly = true;
            dgvNotificaciones.AllowUserToAddRows = false;
            dgvNotificaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            CargarNotificaciones();
        }

        private void CargarNotificaciones()
        {
            UsuarioController controlador = new UsuarioController();
            List<UsuarioBasico> usuarios = controlador.ObtenerUsuarios();

            DateTime hoy = DateTime.Today;
            DateTime limite = hoy.AddDays(7);

            foreach (UsuarioBasico usuario in usuarios)
            {
                if (usuario.Rutinas == null)
                {
                    continue;
                }

                foreach (Rutina rutina in usuario.Rutinas)
                {
                    DateTime vencimiento = rutina.FechaVencimiento.Date;

                    if (vencimiento < hoy)
                    {
                        Notificacion notificacion = new Notificacion(
                            $"La rutina {rutina.Nombre} venció el {vencimiento:dd/MM/yyyy}.",
                            DateTime.Now
                        );

                        dgvNotificaciones.Rows.Add(
                            notificacion.Fecha.ToString("dd/MM/yyyy"),
                            usuario.NombreUsuario,
                            notificacion.Mensaje,
                            "Vencida"
                        );
                    }
                    else if (vencimiento <= limite)
                    {
                        Notificacion notificacion = new Notificacion(
                            $"La rutina {rutina.Nombre} vence el {vencimiento:dd/MM/yyyy}.",
                            DateTime.Now
                        );

                        dgvNotificaciones.Rows.Add(
                            notificacion.Fecha.ToString("dd/MM/yyyy"),
                            usuario.NombreUsuario,
                            notificacion.Mensaje,
                            "Pendiente"
                        );
                    }
                }
            }

            if (dgvNotificaciones.Rows.Count == 0)
            {
                MessageBox.Show("No hay rutinas próximas a vencer ni rutinas vencidas.");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
