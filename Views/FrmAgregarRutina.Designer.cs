
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
            SuspendLayout();

            txtNombre.Location = new Point(14, 67);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(248, 27);
            txtNombre.TabIndex = 0;

            label1.AutoSize = true;
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre de rutina";

            btnGuardar.Location = new Point(301, 377);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;

            txtObjetivo.Location = new Point(12, 136);
            txtObjetivo.Name = "txtObjetivo";
            txtObjetivo.Size = new Size(250, 27);
            txtObjetivo.TabIndex = 3;

            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(12, 113);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(87, 20);
            lblDescripcion.TabIndex = 4;
            lblDescripcion.Text = "Descripción";

            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(12, 187);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(108, 20);
            lblFechaInicio.TabIndex = 5;
            lblFechaInicio.Text = "Fecha de inicio";

            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(12, 210);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(250, 27);
            dtpFechaInicio.TabIndex = 6;

            lblFechaVencimiento.AutoSize = true;
            lblFechaVencimiento.Location = new Point(12, 260);
            lblFechaVencimiento.Name = "lblFechaVencimiento";
            lblFechaVencimiento.Size = new Size(153, 20);
            lblFechaVencimiento.TabIndex = 7;
            lblFechaVencimiento.Text = "Fecha de vencimiento";

            dtpFechaVencimiento.Format = DateTimePickerFormat.Short;
            dtpFechaVencimiento.Location = new Point(12, 283);
            dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            dtpFechaVencimiento.Size = new Size(250, 27);
            dtpFechaVencimiento.TabIndex = 8;

            btnCancelar.Location = new Point(401, 377);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
