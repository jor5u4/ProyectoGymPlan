namespace ProyectoGymPlan.Views
{
    partial class FrmLogin
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
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContrasena = new Label();
            txtContrasena = new TextBox();
            btnIniciarSesion = new Button();
            lblRecuperar = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(387, 34);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(230, 54);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GYM PLAN";
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBienvenida.Location = new Point(387, 107);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(226, 28);
            lblBienvenida.TabIndex = 1;
            lblBienvenida.Text = "Bienvenido a GYM PLAN";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(318, 204);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(158, 23);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Nombre de usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(492, 197);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(125, 30);
            txtUsuario.TabIndex = 3;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(366, 247);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(97, 23);
            lblContrasena.TabIndex = 4;
            lblContrasena.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(492, 240);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(125, 30);
            txtContrasena.TabIndex = 5;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(404, 313);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(180, 40);
            btnIniciarSesion.TabIndex = 6;
            btnIniciarSesion.Text = "Iniciar sesión";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += button1_Click;
            // 
            // lblRecuperar
            // 
            lblRecuperar.AutoSize = true;
            lblRecuperar.Location = new Point(387, 368);
            lblRecuperar.Name = "lblRecuperar";
            lblRecuperar.Size = new Size(206, 23);
            lblRecuperar.TabIndex = 7;
            lblRecuperar.Text = "¿Olvidaste tu contraseña?";
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 636);
            Controls.Add(lblRecuperar);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtContrasena);
            Controls.Add(lblContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblBienvenida);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GYM PLAN";
            Load += FrmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblBienvenida;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblContrasena;
        private TextBox txtContrasena;
        private Button btnIniciarSesion;
        private Label lblRecuperar;
    }
}