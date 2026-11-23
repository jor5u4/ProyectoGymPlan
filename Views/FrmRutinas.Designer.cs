namespace ProyectoGymPlan.Views
{
    partial class FrmRutinas
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
            dgvRutinas = new DataGridView();
            colNombre = new DataGridViewTextBoxColumn();
            colObjetivo = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colEjercicios = new DataGridViewTextBoxColumn();
            btnVolver = new Button();
            btnAgregarRutina = new Button();
            btnEditarRutina = new Button();
            btnEliminarRutina = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRutinas).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(325, 34);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(240, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "MIS RUTINAS";
            // 
            // dgvRutinas
            // 
            dgvRutinas.AllowUserToAddRows = false;
            dgvRutinas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRutinas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRutinas.Columns.AddRange(new DataGridViewColumn[] { colNombre, colObjetivo, colFecha, colEjercicios });
            dgvRutinas.Location = new Point(40, 131);
            dgvRutinas.Name = "dgvRutinas";
            dgvRutinas.ReadOnly = true;
            dgvRutinas.RowHeadersWidth = 51;
            dgvRutinas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRutinas.Size = new Size(800, 300);
            dgvRutinas.TabIndex = 1;
           
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Nombre de rutina";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colObjetivo
            // 
            colObjetivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colObjetivo.HeaderText = "Objetivo";
            colObjetivo.MinimumWidth = 6;
            colObjetivo.Name = "colObjetivo";
            colObjetivo.ReadOnly = true;
            // 
            // colFecha
            // 
            colFecha.HeaderText = "Fecha";
            colFecha.MinimumWidth = 6;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colEjercicios
            // 
            colEjercicios.HeaderText = "Ejercicios";
            colEjercicios.MinimumWidth = 6;
            colEjercicios.Name = "colEjercicios";
            colEjercicios.ReadOnly = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(40, 501);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(120, 40);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnAgregarRutina
            // 
            btnAgregarRutina.Location = new Point(468, 501);
            btnAgregarRutina.Name = "btnAgregarRutina";
            btnAgregarRutina.Size = new Size(120, 40);
            btnAgregarRutina.TabIndex = 3;
            btnAgregarRutina.Text = "Agregar rutina";
            btnAgregarRutina.UseVisualStyleBackColor = true;
            btnAgregarRutina.Click += btnAgregarRutina_Click;
            // 
            // btnEditarRutina
            // 
            btnEditarRutina.Location = new Point(594, 501);
            btnEditarRutina.Name = "btnEditarRutina";
            btnEditarRutina.Size = new Size(120, 40);
            btnEditarRutina.TabIndex = 4;
            btnEditarRutina.Text = "Editar rutina";
            btnEditarRutina.UseVisualStyleBackColor = true;
            // 
            // btnEliminarRutina
            // 
            btnEliminarRutina.Location = new Point(720, 501);
            btnEliminarRutina.Name = "btnEliminarRutina";
            btnEliminarRutina.Size = new Size(120, 40);
            btnEliminarRutina.TabIndex = 5;
            btnEliminarRutina.Text = "Eliminar rutina";
            btnEliminarRutina.UseVisualStyleBackColor = true;
            // 
            // FrmRutinas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(btnEliminarRutina);
            Controls.Add(btnEditarRutina);
            Controls.Add(btnAgregarRutina);
            Controls.Add(btnVolver);
            Controls.Add(dgvRutinas);
            Controls.Add(lblTitulo);
            Name = "FrmRutinas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mis rutinas - GYM PLAN";
            ((System.ComponentModel.ISupportInitialize)dgvRutinas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvRutinas;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colObjetivo;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colEjercicios;
        private Button btnVolver;
        private Button btnAgregarRutina;
        private Button btnEditarRutina;
        private Button btnEliminarRutina;
    }
}