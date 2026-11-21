namespace ProyectoGymPlan.Views
{
    partial class FrmMediciones
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
            dgvMediciones = new DataGridView();
            colFecha = new DataGridViewTextBoxColumn();
            colPeso = new DataGridViewTextBoxColumn();
            colAltura = new DataGridViewTextBoxColumn();
            colIMC = new DataGridViewTextBoxColumn();
            label1 = new Label();
            txtPeso = new TextBox();
            label2 = new Label();
            txtAltura = new TextBox();
            btnRegistrarMedicion = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMediciones).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(288, 27);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(301, 46);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "MIS MEDICIONES";
            // 
            // dgvMediciones
            // 
            dgvMediciones.AllowUserToAddRows = false;
            dgvMediciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMediciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMediciones.Columns.AddRange(new DataGridViewColumn[] { colFecha, colPeso, colAltura, colIMC });
            dgvMediciones.Location = new Point(77, 260);
            dgvMediciones.Name = "dgvMediciones";
            dgvMediciones.ReadOnly = true;
            dgvMediciones.RowHeadersWidth = 51;
            dgvMediciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMediciones.Size = new Size(726, 240);
            dgvMediciones.TabIndex = 1;
            // 
            // colFecha
            // 
            colFecha.HeaderText = "Fecha";
            colFecha.MinimumWidth = 6;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colPeso
            // 
            colPeso.HeaderText = "Peso (kg)";
            colPeso.MinimumWidth = 6;
            colPeso.Name = "colPeso";
            colPeso.ReadOnly = true;
            // 
            // colAltura
            // 
            colAltura.HeaderText = "Altura (cm)";
            colAltura.MinimumWidth = 6;
            colAltura.Name = "colAltura";
            colAltura.ReadOnly = true;
            // 
            // colIMC
            // 
            colIMC.HeaderText = "IMC";
            colIMC.MinimumWidth = 6;
            colIMC.Name = "colIMC";
            colIMC.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 118);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 2;
            label1.Text = "Peso (kg):";
            label1.Click += label1_Click;
            // 
            // txtPeso
            // 
            txtPeso.Location = new Point(155, 111);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(125, 27);
            txtPeso.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 157);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 4;
            label2.Text = "Altura (cm):";
            // 
            // txtAltura
            // 
            txtAltura.Location = new Point(169, 150);
            txtAltura.Name = "txtAltura";
            txtAltura.Size = new Size(125, 27);
            txtAltura.TabIndex = 5;
            // 
            // btnRegistrarMedicion
            // 
            btnRegistrarMedicion.Location = new Point(77, 207);
            btnRegistrarMedicion.Name = "btnRegistrarMedicion";
            btnRegistrarMedicion.Size = new Size(143, 29);
            btnRegistrarMedicion.TabIndex = 6;
            btnRegistrarMedicion.Text = "Registrar medición";
            btnRegistrarMedicion.UseVisualStyleBackColor = true;
            btnRegistrarMedicion.Click += btnRegistrarMedicion_Click;
            // 
            // FrmMediciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(btnRegistrarMedicion);
            Controls.Add(txtAltura);
            Controls.Add(label2);
            Controls.Add(txtPeso);
            Controls.Add(label1);
            Controls.Add(dgvMediciones);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMediciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mis mediciones - GYM PLAN";
            ((System.ComponentModel.ISupportInitialize)dgvMediciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvMediciones;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colPeso;
        private DataGridViewTextBoxColumn colAltura;
        private DataGridViewTextBoxColumn colIMC;
        private Label label1;
        private TextBox txtPeso;
        private Label label2;
        private TextBox txtAltura;
        private Button btnRegistrarMedicion;
    }
}