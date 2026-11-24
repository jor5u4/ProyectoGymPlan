namespace ProyectoGymPlan.Views
{
    partial class FrmInsignias
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
            dgvInsignias = new DataGridView();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInsignias).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(143, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(500, 50);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "MIS INSIGNIAS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
           
            // 
            // dgvInsignias
            // 
            dgvInsignias.AllowUserToAddRows = false;
            dgvInsignias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInsignias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInsignias.Location = new Point(98, 107);
            dgvInsignias.MultiSelect = false;
            dgvInsignias.Name = "dgvInsignias";
            dgvInsignias.ReadOnly = true;
            dgvInsignias.RowHeadersVisible = false;
            dgvInsignias.RowHeadersWidth = 51;
            dgvInsignias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInsignias.Size = new Size(600, 250);
            dgvInsignias.TabIndex = 1;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(694, 409);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(94, 29);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // FrmInsignias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVolver);
            Controls.Add(dgvInsignias);
            Controls.Add(lblTitulo);
            Name = "FrmInsignias";
            Text = "FrmInsignias";
            ((System.ComponentModel.ISupportInitialize)dgvInsignias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvInsignias;
        private Button btnVolver;
    }
}