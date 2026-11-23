
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
        public List<Ejercicio> EjerciciosRutina { get; private set; } = new List<Ejercicio>();

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

                // Copiamos los ejercicios existentes para no modificar la rutina original si cancelan
                if (rutina.Ejercicios != null)
                {
                    EjerciciosRutina = new List<Ejercicio>(rutina.Ejercicios);
                    ActualizarListaEjercicios();
                }

            }
            else
            {
                Text = "Agregar rutina";
            }
        }
        private void ActualizarListaEjercicios()
        {
            lstEjercicios.Items.Clear();

            foreach (Ejercicio ej in EjerciciosRutina)
            {
                string texto = $"{ej.Nombre} - {ej.Series}x{ej.Repeticiones}";
                if (ej.Peso > 0) texto += $" | {ej.Peso} kg";
                if (ej.DuracionMinutos > 0) texto += $" | {ej.DuracionMinutos} min";

                lstEjercicios.Items.Add(texto);
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

        private void btnAgregarEjercicio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombreEjercicio.Text))
            {
                MessageBox.Show("Ingrese el nombre del ejercicio.");
                TxtNombreEjercicio.Focus();
                return;
            }

            Ejercicio nuevo = new Ejercicio(
                TxtNombreEjercicio.Text.Trim(),
                (int)Ndseries.Value,
                (int)NdRepes.Value,
                (double)NdPeso.Value,
                (int)NdDuracion.Value
            );

            EjerciciosRutina.Add(nuevo);
            ActualizarListaEjercicios();

            // Limpiar campos para el siguiente ejercicio
            TxtNombreEjercicio.Clear();
            Ndseries.Value = 0;
            NdRepes.Value = 0;
            NdPeso.Value = 0;
            NdDuracion.Value = 0;
            TxtNombreEjercicio.Focus();
        }

        private void btnquitarejercicio_Click(object sender, EventArgs e)
        {
            if (lstEjercicios.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un ejercicio de la lista para quitarlo.");
                return;
            }

            EjerciciosRutina.RemoveAt(lstEjercicios.SelectedIndex);
            ActualizarListaEjercicios();
        }
    }
}
