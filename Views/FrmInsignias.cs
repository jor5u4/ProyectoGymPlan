
using System;
using System.Windows.Forms;
using ProyectoGymPlan.Models;

namespace ProyectoGymPlan.Views
{
    public partial class FrmInsignias : Form
    {
        private UsuarioBasico? usuario;

        public FrmInsignias()
        {
            InitializeComponent();

            Load -= FrmInsignias_Load;
            Load += FrmInsignias_Load;

            btnVolver.Click -= btnVolver_Click;
            btnVolver.Click += btnVolver_Click;
        }

        public FrmInsignias(UsuarioBasico usuario) : this()
        {
            this.usuario = usuario;
        }

        private void FrmInsignias_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "MIS INSIGNIAS";

            dgvInsignias.Columns.Clear();
            dgvInsignias.Rows.Clear();

            dgvInsignias.Columns.Add("colNombre", "Insignia");
            dgvInsignias.Columns.Add("colTipo", "Tipo");

            dgvInsignias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInsignias.ReadOnly = true;
            dgvInsignias.AllowUserToAddRows = false;
            dgvInsignias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInsignias.MultiSelect = false;
            dgvInsignias.RowHeadersVisible = false;

            CargarInsignias();
        }

        private void CargarInsignias()
        {
            if (usuario == null)
            {
                MessageBox.Show("No se encontró la información del usuario.");
                return;
            }

            if (usuario.Insignias == null || usuario.Insignias.Count == 0)
            {
                MessageBox.Show("Todavía no tenés insignias.");
                return;
            }

            foreach (Insignias insignia in usuario.Insignias)
            {
                dgvInsignias.Rows.Add(
                    insignia.Nombre,
                    insignia.TipoInsignia.ToString()
                );
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
