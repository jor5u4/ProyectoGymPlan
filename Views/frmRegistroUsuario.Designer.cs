namespace ProyectoGymPlan.Views
{
    partial class frmRegistroUsuario
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
            label1 = new Label();
            label2 = new Label();
            btncrear = new Button();
            btncancelar = new Button();
            txtUsuario = new TextBox();
            txtcontrasena = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(329, 56);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre de usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(346, 135);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // btncrear
            // 
            btncrear.Location = new Point(249, 246);
            btncrear.Name = "btncrear";
            btncrear.Size = new Size(94, 29);
            btncrear.TabIndex = 2;
            btncrear.Text = "Crear";
            btncrear.UseVisualStyleBackColor = true;
            // 
            // btncancelar
            // 
            btncancelar.Location = new Point(410, 246);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(94, 29);
            btncancelar.TabIndex = 3;
            btncancelar.Text = "cancelar";
            btncancelar.UseVisualStyleBackColor = true;
            btncancelar.Click += btncancelar_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(304, 79);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(182, 27);
            txtUsuario.TabIndex = 4;
            // 
            // txtcontrasena
            // 
            txtcontrasena.Location = new Point(304, 170);
            txtcontrasena.Name = "txtcontrasena";
            txtcontrasena.PasswordChar = '*';
            txtcontrasena.Size = new Size(182, 27);
            txtcontrasena.TabIndex = 5;
            // 
            // frmRegistroUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtcontrasena);
            Controls.Add(txtUsuario);
            Controls.Add(btncancelar);
            Controls.Add(btncrear);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmRegistroUsuario";
            Text = "frmRegistroUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btncrear;
        private Button btncancelar;
        private TextBox txtUsuario;
        private TextBox txtcontrasena;
    }
}