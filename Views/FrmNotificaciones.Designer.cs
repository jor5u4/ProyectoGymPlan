namespace ProyectoGymPlan.Views
{
    partial class FrmNotificaciones
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
            dgvNotificaciones = new DataGridView();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNotificaciones).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(246, 27);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(267, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "NOTIFICACIONES";
            // 
            // dgvNotificaciones
            // 
            dgvNotificaciones.AllowUserToAddRows = false;
            dgvNotificaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNotificaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotificaciones.Location = new Point(97, 96);
            dgvNotificaciones.Name = "dgvNotificaciones";
            dgvNotificaciones.ReadOnly = true;
            dgvNotificaciones.RowHeadersWidth = 51;
            dgvNotificaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotificaciones.Size = new Size(595, 209);
            dgvNotificaciones.TabIndex = 1;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(676, 412);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(94, 29);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click_1;
            // 
            // FrmNotificaciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(btnVolver);
            Controls.Add(dgvNotificaciones);
            Controls.Add(lblTitulo);
            Name = "FrmNotificaciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Notificaciones";
            Load += FrmNotificaciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNotificaciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvNotificaciones;
        private Button btnVolver;
    }
}