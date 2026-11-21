
using System;
using System.Windows.Forms;
using ProyectoGymPlan.Models;

namespace ProyectoGymPlan.Views
{
    public partial class FrmHistorialVisitas : Form
    {
        private UsuarioBasico usuario;

        public FrmHistorialVisitas(UsuarioBasico usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            Load += FrmHistorialVisitas_Load;
        }

        private void FrmHistorialVisitas_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "HISTORIAL DE VISITAS";

            dgvVisitas.Rows.Clear();

            foreach (DateTime fecha in usuario.HistorialVisitas)
            {
                dgvVisitas.Rows.Add(fecha.ToShortDateString());
            }
        }
    }
}
