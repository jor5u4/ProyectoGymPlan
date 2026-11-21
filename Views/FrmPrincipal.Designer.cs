namespace ProyectoGymPlan.Views
{
    partial class FrmPrincipal
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
            lblBienvenida = new Label();
            btnRutinas = new Button();
            btnHistorialVisitas = new Button();
            btnMediciones = new Button();
            btnInsignias = new Button();
            btnNotificaciones = new Button();
            btnCerrarSesion = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(370, 37);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(230, 54);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GYM PLAN";
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBienvenida.Location = new Point(370, 113);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(226, 28);
            lblBienvenida.TabIndex = 1;
            lblBienvenida.Text = "Bienvenido a GYM PLAN";
            // 
            // btnRutinas
            // 
            btnRutinas.Location = new Point(387, 191);
            btnRutinas.Name = "btnRutinas";
            btnRutinas.Size = new Size(200, 50);
            btnRutinas.TabIndex = 2;
            btnRutinas.Text = "Mis rutinas";
            btnRutinas.UseVisualStyleBackColor = true;
            // 
            // btnHistorialVisitas
            // 
            btnHistorialVisitas.Location = new Point(387, 247);
            btnHistorialVisitas.Name = "btnHistorialVisitas";
            btnHistorialVisitas.Size = new Size(200, 50);
            btnHistorialVisitas.TabIndex = 3;
            btnHistorialVisitas.Text = "Historial de visitas";
            btnHistorialVisitas.UseVisualStyleBackColor = true;
            // 
            // btnMediciones
            // 
            btnMediciones.Location = new Point(387, 303);
            btnMediciones.Name = "btnMediciones";
            btnMediciones.Size = new Size(200, 50);
            btnMediciones.TabIndex = 4;
            btnMediciones.Text = "Mis mediciones";
            btnMediciones.UseVisualStyleBackColor = true;
            // 
            // btnInsignias
            // 
            btnInsignias.Location = new Point(387, 359);
            btnInsignias.Name = "btnInsignias";
            btnInsignias.Size = new Size(200, 50);
            btnInsignias.TabIndex = 5;
            btnInsignias.Text = "Mis insignias";
            btnInsignias.UseVisualStyleBackColor = true;
            btnInsignias.Click += btnInsignias_Click;
            // 
            // btnNotificaciones
            // 
            btnNotificaciones.Location = new Point(387, 415);
            btnNotificaciones.Name = "btnNotificaciones";
            btnNotificaciones.Size = new Size(200, 50);
            btnNotificaciones.TabIndex = 6;
            btnNotificaciones.Text = "Mis notificaciones";
            btnNotificaciones.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(820, 551);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(150, 40);
            btnCerrarSesion.TabIndex = 7;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(btnCerrarSesion);
            Controls.Add(btnNotificaciones);
            Controls.Add(btnInsignias);
            Controls.Add(btnMediciones);
            Controls.Add(btnHistorialVisitas);
            Controls.Add(btnRutinas);
            Controls.Add(lblBienvenida);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GYM PLAN";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblBienvenida;
        private Button btnRutinas;
        private Button btnHistorialVisitas;
        private Button btnMediciones;
        private Button btnInsignias;
        private Button btnNotificaciones;
        private Button btnCerrarSesion;
    }
}