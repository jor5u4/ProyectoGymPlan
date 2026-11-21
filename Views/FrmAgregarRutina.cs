
using System;
using System.Windows.Forms;
using ProyectoGymPlan.Models;

namespace ProyectoGymPlan.Views
{
    public partial class FrmAgregarRutina : Form
    {
        public string NombreRutina { get; private set; } = string.Empty;
        public string DescripcionRutina { get; private set; } = string.Empty;
        public DateTime FechaInicioRutina { get; private set; }
        public DateTime FechaVencimientoRutina { get; private set; }

        private bool esEdicion;

        public FrmAgregarRutina(Rutina? rutina = null)
        {
            InitializeComponent();

            if (rutina != null)
            {
                esEdicion = true;

                Text = "Editar rutina";
                btnGuardar.Text = "Guardar cambios";

                txtNombre.Text = rutina.Nombre;
                txtObjetivo.Text = rutina.Descripcion;
                dtpFechaInicio.Value = rutina.FechaInicio;
                dtpFechaVencimiento.Value = rutina.FechaVencimiento;
            }
            else
            {
                Text = "Agregar rutina";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre de la rutina.");
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtObjetivo.Text))
            {
                MessageBox.Show("Ingrese la descripción de la rutina.");
                txtObjetivo.Focus();
                return;
            }

            if (dtpFechaVencimiento.Value.Date < dtpFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha de vencimiento no puede ser anterior a la fecha de inicio.");
                return;
            }

            NombreRutina = txtNombre.Text.Trim();
            DescripcionRutina = txtObjetivo.Text.Trim();
            FechaInicioRutina = dtpFechaInicio.Value.Date;
            FechaVencimientoRutina = dtpFechaVencimiento.Value.Date;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
