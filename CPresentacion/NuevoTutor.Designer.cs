namespace ConsultorioPsicopedagogico.CPresentacion
{
    partial class NuevoTutor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoTutor));
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txt_DniTutor = new System.Windows.Forms.TextBox();
            this.btn_BuscarTutor = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ApellidoTutor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_NombreTutor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Telefono = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_ObraSocial = new System.Windows.Forms.TextBox();
            this.lbl_ObraSocial = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Volver = new System.Windows.Forms.Button();
            this.panelTutorCard = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panelTutorCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(33, 15);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(85, 79);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 38;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // txt_DniTutor
            // 
            this.txt_DniTutor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DniTutor.Location = new System.Drawing.Point(188, 62);
            this.txt_DniTutor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_DniTutor.MaxLength = 8;
            this.txt_DniTutor.Name = "txt_DniTutor";
            this.txt_DniTutor.Size = new System.Drawing.Size(250, 29);
            this.txt_DniTutor.TabIndex = 1;
            this.txt_DniTutor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumbers_KeyPress);
            // 
            // btn_BuscarTutor
            // 
            this.btn_BuscarTutor.Location = new System.Drawing.Point(444, 62);
            this.btn_BuscarTutor.Name = "btn_BuscarTutor";
            this.btn_BuscarTutor.Size = new System.Drawing.Size(76, 29);
            this.btn_BuscarTutor.TabIndex = 99;
            this.btn_BuscarTutor.Text = "Buscar";
            this.btn_BuscarTutor.UseVisualStyleBackColor = true;
            this.btn_BuscarTutor.Click += new System.EventHandler(this.btn_BuscarTutor_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(25)))), ((int)(((byte)(120)))));
            this.label14.Location = new System.Drawing.Point(133, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(353, 50);
            this.label14.TabIndex = 36;
            this.label14.Text = "REGISTRAR TUTOR";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(25)))), ((int)(((byte)(120)))));
            this.label13.Location = new System.Drawing.Point(20, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(178, 25);
            this.label13.TabIndex = 35;
            this.label13.Text = "DATOS DEL TUTOR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "DNI:";
            // 
            // txt_ApellidoTutor
            // 
            this.txt_ApellidoTutor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ApellidoTutor.Location = new System.Drawing.Point(188, 108);
            this.txt_ApellidoTutor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_ApellidoTutor.Name = "txt_ApellidoTutor";
            this.txt_ApellidoTutor.Size = new System.Drawing.Size(332, 29);
            this.txt_ApellidoTutor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "Apellido:";
            // 
            // txt_NombreTutor
            // 
            this.txt_NombreTutor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombreTutor.Location = new System.Drawing.Point(188, 155);
            this.txt_NombreTutor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_NombreTutor.Name = "txt_NombreTutor";
            this.txt_NombreTutor.Size = new System.Drawing.Size(332, 29);
            this.txt_NombreTutor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "Nombre:";
            // 
            // txt_Telefono
            // 
            this.txt_Telefono.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Telefono.Location = new System.Drawing.Point(188, 205);
            this.txt_Telefono.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Telefono.MaxLength = 15;
            this.txt_Telefono.Name = "txt_Telefono";
            this.txt_Telefono.Size = new System.Drawing.Size(332, 29);
            this.txt_Telefono.TabIndex = 5;
            this.txt_Telefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumbers_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 45;
            this.label5.Text = "Telefono:";
            // 
            // txt_Email
            // 
            this.txt_Email.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Email.Location = new System.Drawing.Point(188, 251);
            this.txt_Email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(332, 29);
            this.txt_Email.TabIndex = 6;
            // 
            // txt_ObraSocial
            // 
            this.txt_ObraSocial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ObraSocial.Location = new System.Drawing.Point(188, 301);
            this.txt_ObraSocial.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ObraSocial.Name = "txt_ObraSocial";
            this.txt_ObraSocial.Size = new System.Drawing.Size(332, 29);
            this.txt_ObraSocial.TabIndex = 7;
            // 
            // lbl_ObraSocial
            // 
            this.lbl_ObraSocial.AutoSize = true;
            this.lbl_ObraSocial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ObraSocial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbl_ObraSocial.Location = new System.Drawing.Point(21, 301);
            this.lbl_ObraSocial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ObraSocial.Name = "lbl_ObraSocial";
            this.lbl_ObraSocial.Size = new System.Drawing.Size(101, 23);
            this.lbl_ObraSocial.TabIndex = 99;
            this.lbl_ObraSocial.Text = "Obra Social:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 47;
            this.label6.Text = "Email:";
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_Guardar.FlatAppearance.BorderSize = 0;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar.ForeColor = System.Drawing.Color.White;
            this.btn_Guardar.Location = new System.Drawing.Point(627, 123);
            this.btn_Guardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(333, 55);
            this.btn_Guardar.TabIndex = 7;
            this.btn_Guardar.Text = "GUARDAR";
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Modificar
            // 
            this.btn_Modificar.BackColor = System.Drawing.Color.White;
            this.btn_Modificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Modificar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_Modificar.Location = new System.Drawing.Point(627, 197);
            this.btn_Modificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(333, 55);
            this.btn_Modificar.TabIndex = 8;
            this.btn_Modificar.Text = "MODIFICAR";
            this.btn_Modificar.UseVisualStyleBackColor = false;
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.BackColor = System.Drawing.Color.White;
            this.btn_Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Eliminar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_Eliminar.Location = new System.Drawing.Point(627, 271);
            this.btn_Eliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(333, 55);
            this.btn_Eliminar.TabIndex = 9;
            this.btn_Eliminar.Text = "ELIMINAR";
            this.btn_Eliminar.UseVisualStyleBackColor = false;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.White;
            this.btn_Limpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.btn_Limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Limpiar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Limpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.btn_Limpiar.Location = new System.Drawing.Point(627, 345);
            this.btn_Limpiar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(333, 55);
            this.btn_Limpiar.TabIndex = 10;
            this.btn_Limpiar.Text = "LIMPIAR";
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Volver
            // 
            this.btn_Volver.BackColor = System.Drawing.Color.White;
            this.btn_Volver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btn_Volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Volver.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Volver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btn_Volver.Location = new System.Drawing.Point(627, 433);
            this.btn_Volver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Volver.Name = "btn_Volver";
            this.btn_Volver.Size = new System.Drawing.Size(333, 55);
            this.btn_Volver.TabIndex = 10;
            this.btn_Volver.Text = "VOLVER";
            this.btn_Volver.UseVisualStyleBackColor = false;
            this.btn_Volver.Click += new System.EventHandler(this.btn_Volver_Click);
            // 
            // panelTutorCard
            // 
            this.panelTutorCard.BackColor = System.Drawing.Color.White;
            this.panelTutorCard.Controls.Add(this.label13);
            this.panelTutorCard.Controls.Add(this.label1);
            this.panelTutorCard.Controls.Add(this.txt_DniTutor);
            this.panelTutorCard.Controls.Add(this.btn_BuscarTutor);
            this.panelTutorCard.Controls.Add(this.label2);
            this.panelTutorCard.Controls.Add(this.txt_ApellidoTutor);
            this.panelTutorCard.Controls.Add(this.label3);
            this.panelTutorCard.Controls.Add(this.txt_NombreTutor);
            this.panelTutorCard.Controls.Add(this.label5);
            this.panelTutorCard.Controls.Add(this.txt_Telefono);
            this.panelTutorCard.Controls.Add(this.label6);
            this.panelTutorCard.Controls.Add(this.txt_Email);
            this.panelTutorCard.Controls.Add(this.lbl_ObraSocial);
            this.panelTutorCard.Controls.Add(this.txt_ObraSocial);
            this.panelTutorCard.Location = new System.Drawing.Point(27, 123);
            this.panelTutorCard.Margin = new System.Windows.Forms.Padding(4);
            this.panelTutorCard.Name = "panelTutorCard";
            this.panelTutorCard.Size = new System.Drawing.Size(560, 366);
            this.panelTutorCard.TabIndex = 0;
            this.panelTutorCard.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCard_Paint);
            // 
            // NuevoTutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1000, 509);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panelTutorCard);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.btn_Modificar);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.btn_Volver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "NuevoTutor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Tutor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panelTutorCard.ResumeLayout(false);
            this.panelTutorCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txt_DniTutor;
        private System.Windows.Forms.Button btn_BuscarTutor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ApellidoTutor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_NombreTutor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Telefono;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Email;
        public System.Windows.Forms.TextBox txt_ObraSocial;
        private System.Windows.Forms.Label lbl_ObraSocial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Modificar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Volver;
        private System.Windows.Forms.Panel panelTutorCard;
    }
}
