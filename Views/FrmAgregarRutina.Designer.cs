
namespace ProyectoGymPlan.Views
{
    partial class FrmAgregarRutina
    {
        private System.ComponentModel.IContainer components = null;

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
            txtNombre = new TextBox();
            label1 = new Label();
            btnGuardar = new Button();
            txtObjetivo = new TextBox();
            lblDescripcion = new Label();
            lblFechaInicio = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblFechaVencimiento = new Label();
            dtpFechaVencimiento = new DateTimePicker();
            btnCancelar = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            TxtNombreEjercicio = new TextBox();
            Ndseries = new NumericUpDown();
            NdRepes = new NumericUpDown();
            NdDuracion = new NumericUpDown();
            NdPeso = new NumericUpDown();
            btnAgregarEjercicio = new Button();
            btnquitarejercicio = new Button();
            lstEjercicios = new ListBox();
            ((System.ComponentModel.ISupportInitialize)Ndseries).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NdRepes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NdDuracion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NdPeso).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(14, 67);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(248, 27);
            txtNombre.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre de rutina";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(14, 341);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(125, 29);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar Rutina";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtObjetivo
            // 
            txtObjetivo.Location = new Point(12, 136);
            txtObjetivo.Name = "txtObjetivo";
            txtObjetivo.Size = new Size(250, 27);
            txtObjetivo.TabIndex = 3;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(12, 113);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(87, 20);
            lblDescripcion.TabIndex = 4;
            lblDescripcion.Text = "Descripción";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(12, 187);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(108, 20);
            lblFechaInicio.TabIndex = 5;
            lblFechaInicio.Text = "Fecha de inicio";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(12, 210);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(250, 27);
            dtpFechaInicio.TabIndex = 6;
            // 
            // lblFechaVencimiento
            // 
            lblFechaVencimiento.AutoSize = true;
            lblFechaVencimiento.Location = new Point(12, 260);
            lblFechaVencimiento.Name = "lblFechaVencimiento";
            lblFechaVencimiento.Size = new Size(153, 20);
            lblFechaVencimiento.TabIndex = 7;
            lblFechaVencimiento.Text = "Fecha de vencimiento";
            // 
            // dtpFechaVencimiento
            // 
            dtpFechaVencimiento.Format = DateTimePickerFormat.Short;
            dtpFechaVencimiento.Location = new Point(12, 283);
            dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            dtpFechaVencimiento.Size = new Size(250, 27);
            dtpFechaVencimiento.TabIndex = 8;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(168, 341);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(339, 44);
            label2.Name = "label2";
            label2.Size = new Size(149, 20);
            label2.TabIndex = 10;
            label2.Text = "Nombre del ejercicio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(342, 97);
            label3.Name = "label3";
            label3.Size = new Size(127, 20);
            label3.TabIndex = 11;
            label3.Text = "Numero De series";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(339, 150);
            label4.Name = "label4";
            label4.Size = new Size(173, 20);
            label4.TabIndex = 12;
            label4.Text = "Numero de Repeticiones";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(339, 210);
            label5.Name = "label5";
            label5.Size = new Size(93, 20);
            label5.TabIndex = 13;
            label5.Text = "Peso en kilos";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(339, 268);
            label6.Name = "label6";
            label6.Size = new Size(146, 20);
            label6.TabIndex = 14;
            label6.Text = "Duracion en minutos";
            // 
            // TxtNombreEjercicio
            // 
            TxtNombreEjercicio.Location = new Point(339, 67);
            TxtNombreEjercicio.Name = "TxtNombreEjercicio";
            TxtNombreEjercicio.Size = new Size(146, 27);
            TxtNombreEjercicio.TabIndex = 15;
            // 
            // Ndseries
            // 
            Ndseries.Location = new Point(342, 120);
            Ndseries.Name = "Ndseries";
            Ndseries.Size = new Size(150, 27);
            Ndseries.TabIndex = 16;
            // 
            // NdRepes
            // 
            NdRepes.Location = new Point(342, 173);
            NdRepes.Name = "NdRepes";
            NdRepes.Size = new Size(150, 27);
            NdRepes.TabIndex = 17;
            // 
            // NdDuracion
            // 
            NdDuracion.Location = new Point(342, 291);
            NdDuracion.Name = "NdDuracion";
            NdDuracion.Size = new Size(150, 27);
            NdDuracion.TabIndex = 18;
            // 
            // NdPeso
            // 
            NdPeso.Location = new Point(342, 238);
            NdPeso.Name = "NdPeso";
            NdPeso.Size = new Size(150, 27);
            NdPeso.TabIndex = 19;
            // 
            // btnAgregarEjercicio
            // 
            btnAgregarEjercicio.Location = new Point(339, 389);
            btnAgregarEjercicio.Name = "btnAgregarEjercicio";
            btnAgregarEjercicio.Size = new Size(169, 29);
            btnAgregarEjercicio.TabIndex = 20;
            btnAgregarEjercicio.Text = "Agregar Ejercicio";
            btnAgregarEjercicio.UseVisualStyleBackColor = true;
            btnAgregarEjercicio.Click += btnAgregarEjercicio_Click;
            // 
            // btnquitarejercicio
            // 
            btnquitarejercicio.Location = new Point(339, 341);
            btnquitarejercicio.Name = "btnquitarejercicio";
            btnquitarejercicio.Size = new Size(169, 29);
            btnquitarejercicio.TabIndex = 21;
            btnquitarejercicio.Text = "Eliminar ejercicio";
            btnquitarejercicio.UseVisualStyleBackColor = true;
            btnquitarejercicio.Click += btnquitarejercicio_Click;
            // 
            // lstEjercicios
            // 
            lstEjercicios.FormattingEnabled = true;
            lstEjercicios.IntegralHeight = false;
            lstEjercicios.Location = new Point(685, 44);
            lstEjercicios.Name = "lstEjercicios";
            lstEjercicios.Size = new Size(443, 364);
            lstEjercicios.TabIndex = 22;
            // 
            // FrmAgregarRutina
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 450);
            Controls.Add(lstEjercicios);
            Controls.Add(btnquitarejercicio);
            Controls.Add(btnAgregarEjercicio);
            Controls.Add(NdPeso);
            Controls.Add(NdDuracion);
            Controls.Add(NdRepes);
            Controls.Add(Ndseries);
            Controls.Add(TxtNombreEjercicio);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(dtpFechaVencimiento);
            Controls.Add(lblFechaVencimiento);
            Controls.Add(dtpFechaInicio);
            Controls.Add(lblFechaInicio);
            Controls.Add(lblDescripcion);
            Controls.Add(txtObjetivo);
            Controls.Add(btnGuardar);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Name = "FrmAgregarRutina";
            Text = "FrmAgregarRutina";
            ((System.ComponentModel.ISupportInitialize)Ndseries).EndInit();
            ((System.ComponentModel.ISupportInitialize)NdRepes).EndInit();
            ((System.ComponentModel.ISupportInitialize)NdDuracion).EndInit();
            ((System.ComponentModel.ISupportInitialize)NdPeso).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtNombre;
        private Label label1;
        private Button btnGuardar;
        private TextBox txtObjetivo;
        private Label lblDescripcion;
        private Label lblFechaInicio;
        private DateTimePicker dtpFechaInicio;
        private Label lblFechaVencimiento;
        private DateTimePicker dtpFechaVencimiento;
        private Button btnCancelar;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox TxtNombreEjercicio;
        private NumericUpDown Ndseries;
        private NumericUpDown NdRepes;
        private NumericUpDown NdDuracion;
        private NumericUpDown NdPeso;
        private Button btnAgregarEjercicio;
        private Button btnquitarejercicio;
        private ListBox lstEjercicios;
    }
}
