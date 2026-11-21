namespace ProyectoGymPlan.Views
{
    partial class FrmHistorialVisitas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            dgvVisitas = new DataGridView();
            colFechaVisita = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvVisitas).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(252, 40);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(381, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "HISTORIAL DE VISITAS";
            // 
            // dgvVisitas
            // 
            dgvVisitas.AllowUserToAddRows = false;
            dgvVisitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVisitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVisitas.Columns.AddRange(new DataGridViewColumn[] { colFechaVisita });
            dgvVisitas.Location = new Point(36, 146);
            dgvVisitas.Name = "dgvVisitas";
            dgvVisitas.ReadOnly = true;
            dgvVisitas.RowHeadersWidth = 51;
            dgvVisitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisitas.Size = new Size(800, 300);
            dgvVisitas.TabIndex = 1;
            // 
            // colFechaVisita
            // 
            colFechaVisita.HeaderText = "Fecha de visita";
            colFechaVisita.MinimumWidth = 6;
            colFechaVisita.Name = "colFechaVisita";
            colFechaVisita.ReadOnly = true;
            // 
            // FrmHistorialVisitas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(dgvVisitas);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmHistorialVisitas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial de visitas - GYM PLAN";
            ((System.ComponentModel.ISupportInitialize)dgvVisitas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvVisitas;
        private DataGridViewTextBoxColumn colFechaVisita;
    }
}