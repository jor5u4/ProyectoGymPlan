///Estudiantes: Nathaly Bejarano Rodriguez / Jorsua Redondo Jimenez
///Profesor: Luis Felipe Mora
///Proyecto 1 Tecnicas de programacion
///Universidad Politecnica Internacional

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProyectoGymPlan.Controllers;
using ProyectoGymPlan.Models;

namespace ProyectoGymPlan.Views
{
    public class FrmClases : Form
    {
        private readonly DataGridView dgvClases = new DataGridView();
        private readonly Button btnCerrar = new Button();

        public FrmClases()
        {
            Text = "Clases del gimnasio";
            ClientSize = new Size(760, 380);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            dgvClases.Location = new Point(20, 20);
            dgvClases.Size = new Size(720, 290);
            dgvClases.ReadOnly = true;
            dgvClases.AllowUserToAddRows = false;
            dgvClases.RowHeadersVisible = false;
            dgvClases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClases.Columns.Add("colClase", "Clase");
            dgvClases.Columns.Add("colDuracion", "Duración (min)");
            dgvClases.Columns.Add("colCupo", "Cupo máximo");
            dgvClases.Columns.Add("colDescripcion", "Descripción");
            Controls.Add(dgvClases);

            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(620, 325);
            btnCerrar.Size = new Size(120, 36);
            btnCerrar.Click += (sender, e) => Close();
            Controls.Add(btnCerrar);

            Load += (sender, e) => CargarClases();
        }

        private void CargarClases()
        {
            dgvClases.Rows.Clear();

            List<ClaseGimnasio> clases = ClaseGimnasioFactory.CrearTodas();

            foreach (ClaseGimnasio clase in clases)
            {
                dgvClases.Rows.Add(
                    clase.Nombre,
                    clase.DuracionMinutos,
                    clase.CupoMaximo,
                    clase.ObtenerDescripcion());
            }
        }
    }
}
