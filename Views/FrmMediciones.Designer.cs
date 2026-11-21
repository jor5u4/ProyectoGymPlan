
namespace ProyectoGymPlan.Views
{
    partial class FrmMediciones
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvMediciones;
        private System.Windows.Forms.Label labelPeso;
        private System.Windows.Forms.Label labelAltura;
        private System.Windows.Forms.Label labelBrazo;
        private System.Windows.Forms.Label labelPecho;
        private System.Windows.Forms.Label labelCintura;
        private System.Windows.Forms.Label labelCadera;
        private System.Windows.Forms.Label labelPierna;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.TextBox txtBrazo;
        private System.Windows.Forms.TextBox txtPecho;
        private System.Windows.Forms.TextBox txtCintura;
        private System.Windows.Forms.TextBox txtCadera;
        private System.Windows.Forms.TextBox txtPierna;
        private System.Windows.Forms.Button btnRegistrarMedicion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTitulo = new System.Windows.Forms.Label();
            dgvMediciones = new System.Windows.Forms.DataGridView();
            labelPeso = new System.Windows.Forms.Label();
            labelAltura = new System.Windows.Forms.Label();
            labelBrazo = new System.Windows.Forms.Label();
            labelPecho = new System.Windows.Forms.Label();
            labelCintura = new System.Windows.Forms.Label();
            labelCadera = new System.Windows.Forms.Label();
            labelPierna = new System.Windows.Forms.Label();
            txtPeso = new System.Windows.Forms.TextBox();
            txtAltura = new System.Windows.Forms.TextBox();
            txtBrazo = new System.Windows.Forms.TextBox();
            txtPecho = new System.Windows.Forms.TextBox();
            txtCintura = new System.Windows.Forms.TextBox();
            txtCadera = new System.Windows.Forms.TextBox();
            txtPierna = new System.Windows.Forms.TextBox();
            btnRegistrarMedicion = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)dgvMediciones).BeginInit();
            SuspendLayout();

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(250, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "MIS MEDICIONES";

            labelPeso.AutoSize = true;
            labelPeso.Location = new System.Drawing.Point(30, 80);
            labelPeso.Text = "Peso (kg)";

            txtPeso.Location = new System.Drawing.Point(30, 105);
            txtPeso.Size = new System.Drawing.Size(130, 23);

            labelAltura.AutoSize = true;
            labelAltura.Location = new System.Drawing.Point(180, 80);
            labelAltura.Text = "Altura (cm)";

            txtAltura.Location = new System.Drawing.Point(180, 105);
            txtAltura.Size = new System.Drawing.Size(130, 23);

            labelBrazo.AutoSize = true;
            labelBrazo.Location = new System.Drawing.Point(330, 80);
            labelBrazo.Text = "Brazo (cm)";

            txtBrazo.Location = new System.Drawing.Point(330, 105);
            txtBrazo.Size = new System.Drawing.Size(130, 23);

            labelPecho.AutoSize = true;
            labelPecho.Location = new System.Drawing.Point(480, 80);
            labelPecho.Text = "Pecho (cm)";

            txtPecho.Location = new System.Drawing.Point(480, 105);
            txtPecho.Size = new System.Drawing.Size(130, 23);

            labelCintura.AutoSize = true;
            labelCintura.Location = new System.Drawing.Point(30, 145);
            labelCintura.Text = "Cintura (cm)";

            txtCintura.Location = new System.Drawing.Point(30, 170);
            txtCintura.Size = new System.Drawing.Size(130, 23);

            labelCadera.AutoSize = true;
            labelCadera.Location = new System.Drawing.Point(180, 145);
            labelCadera.Text = "Cadera (cm)";

            txtCadera.Location = new System.Drawing.Point(180, 170);
            txtCadera.Size = new System.Drawing.Size(130, 23);

            labelPierna.AutoSize = true;
            labelPierna.Location = new System.Drawing.Point(330, 145);
            labelPierna.Text = "Pierna (cm)";

            txtPierna.Location = new System.Drawing.Point(330, 170);
            txtPierna.Size = new System.Drawing.Size(130, 23);

            btnRegistrarMedicion.Location = new System.Drawing.Point(480, 165);
            btnRegistrarMedicion.Size = new System.Drawing.Size(160, 35);
            btnRegistrarMedicion.Name = "btnRegistrarMedicion";
            btnRegistrarMedicion.Text = "Registrar medición";
            btnRegistrarMedicion.UseVisualStyleBackColor = true;
            btnRegistrarMedicion.Click += btnRegistrarMedicion_Click;

            dgvMediciones.AllowUserToAddRows = false;
            dgvMediciones.AllowUserToDeleteRows = false;
            dgvMediciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvMediciones.ReadOnly = true;
            dgvMediciones.RowHeadersVisible = false;
            dgvMediciones.Location = new System.Drawing.Point(30, 230);
            dgvMediciones.Size = new System.Drawing.Size(800, 270);
            dgvMediciones.Name = "dgvMediciones";

            dgvMediciones.Columns.Add("Fecha", "Fecha");
            dgvMediciones.Columns.Add("Peso", "Peso (kg)");
            dgvMediciones.Columns.Add("Altura", "Altura (cm)");
            dgvMediciones.Columns.Add("Imc", "IMC");
            dgvMediciones.Columns.Add("Brazo", "Brazo (cm)");
            dgvMediciones.Columns.Add("Pecho", "Pecho (cm)");
            dgvMediciones.Columns.Add("Cintura", "Cintura (cm)");
            dgvMediciones.Columns.Add("Cadera", "Cadera (cm)");
            dgvMediciones.Columns.Add("Pierna", "Pierna (cm)");

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(880, 540);
            Controls.Add(lblTitulo);
            Controls.Add(labelPeso);
            Controls.Add(txtPeso);
            Controls.Add(labelAltura);
            Controls.Add(txtAltura);
            Controls.Add(labelBrazo);
            Controls.Add(txtBrazo);
            Controls.Add(labelPecho);
            Controls.Add(txtPecho);
            Controls.Add(labelCintura);
            Controls.Add(txtCintura);
            Controls.Add(labelCadera);
            Controls.Add(txtCadera);
            Controls.Add(labelPierna);
            Controls.Add(txtPierna);
            Controls.Add(btnRegistrarMedicion);
            Controls.Add(dgvMediciones);
            Name = "FrmMediciones";
            Text = "Mis mediciones";

            ((System.ComponentModel.ISupportInitialize)dgvMediciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
