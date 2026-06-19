namespace ConsultorioPsicopedagogico.CPresentacion
{
    partial class FormNuevoUsuario
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
            this.panelIzquierdo = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelDerecho = new System.Windows.Forms.Panel();
            this.lbl_Minimizar = new System.Windows.Forms.Label();
            this.lbl_Cerrar = new System.Windows.Forms.Label();
            this.lblCrearUsuario = new System.Windows.Forms.Label();
            this.panelContenedorCampos = new System.Windows.Forms.Panel();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombreApellido = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblConfirmar = new System.Windows.Forms.Label();
            this.txtConfirmarContrasena = new System.Windows.Forms.TextBox();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.cmbPreguntaSecreta = new System.Windows.Forms.ComboBox();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelDecorativo = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelDerecho.SuspendLayout();
            this.panelContenedorCampos.SuspendLayout();
            this.panelDecorativo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelIzquierdo
            // 
            this.panelIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(162)))), ((int)(((byte)(200)))));
            this.panelIzquierdo.Controls.Add(this.pictureBox2);
            this.panelIzquierdo.Controls.Add(this.pictureBox1);
            this.panelIzquierdo.Controls.Add(this.lblSubtitulo);
            this.panelIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.panelIzquierdo.Name = "panelIzquierdo";
            this.panelIzquierdo.Size = new System.Drawing.Size(350, 600);
            this.panelIzquierdo.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ConsultorioPsicopedagogico.Properties.Resources.logoNuevo;
            this.pictureBox2.Location = new System.Drawing.Point(90, 169);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(171, 181);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::ConsultorioPsicopedagogico.Properties.Resources.UsuarioNuevo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
            this.lblSubtitulo.Location = new System.Drawing.Point(90, 362);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(170, 90);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "CREAR\n USUARIO";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDerecho
            // 
            this.panelDerecho.BackColor = System.Drawing.Color.LavenderBlush;
            this.panelDerecho.Controls.Add(this.lbl_Minimizar);
            this.panelDerecho.Controls.Add(this.lbl_Cerrar);
            this.panelDerecho.Controls.Add(this.lblCrearUsuario);
            this.panelDerecho.Controls.Add(this.panelContenedorCampos);
            this.panelDerecho.Controls.Add(this.panelDecorativo);
            this.panelDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDerecho.Location = new System.Drawing.Point(350, 0);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Size = new System.Drawing.Size(642, 600);
            this.panelDerecho.TabIndex = 0;
            // 
            // lbl_Minimizar
            // 
            this.lbl_Minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Minimizar.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Minimizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(15)))), ((int)(((byte)(58)))));
            this.lbl_Minimizar.Location = new System.Drawing.Point(579, 0);
            this.lbl_Minimizar.Name = "lbl_Minimizar";
            this.lbl_Minimizar.Size = new System.Drawing.Size(30, 30);
            this.lbl_Minimizar.TabIndex = 11;
            this.lbl_Minimizar.Text = "—";
            this.lbl_Minimizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Minimizar.UseCompatibleTextRendering = true;
            this.lbl_Minimizar.Click += new System.EventHandler(this.lbl_Minimizar_Click);
            this.lbl_Minimizar.MouseEnter += new System.EventHandler(this.lbl_Minimizar_MouseEnter);
            this.lbl_Minimizar.MouseLeave += new System.EventHandler(this.lbl_Minimizar_MouseLeave);
            // 
            // lbl_Cerrar
            // 
            this.lbl_Cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Cerrar.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(15)))), ((int)(((byte)(58)))));
            this.lbl_Cerrar.Location = new System.Drawing.Point(612, 0);
            this.lbl_Cerrar.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Cerrar.Name = "lbl_Cerrar";
            this.lbl_Cerrar.Size = new System.Drawing.Size(30, 30);
            this.lbl_Cerrar.TabIndex = 10;
            this.lbl_Cerrar.Text = "X";
            this.lbl_Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Cerrar.UseCompatibleTextRendering = true;
            this.lbl_Cerrar.Click += new System.EventHandler(this.lbl_Cerrar_Click);
            this.lbl_Cerrar.MouseEnter += new System.EventHandler(this.lbl_Cerrar_MouseEnter);
            this.lbl_Cerrar.MouseLeave += new System.EventHandler(this.lbl_Cerrar_MouseLeave);
            // 
            // lblCrearUsuario
            // 
            this.lblCrearUsuario.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCrearUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(15)))), ((int)(((byte)(58)))));
            this.lblCrearUsuario.Location = new System.Drawing.Point(50, 20);
            this.lblCrearUsuario.Name = "lblCrearUsuario";
            this.lblCrearUsuario.Size = new System.Drawing.Size(550, 35);
            this.lblCrearUsuario.TabIndex = 0;
            this.lblCrearUsuario.Text = "CREAR NUEVO USUARIO";
            this.lblCrearUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelContenedorCampos
            // 
            this.panelContenedorCampos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(205)))), ((int)(((byte)(130)))));
            this.panelContenedorCampos.Controls.Add(this.lblMatricula);
            this.panelContenedorCampos.Controls.Add(this.txtMatricula);
            this.panelContenedorCampos.Controls.Add(this.lblDni);
            this.panelContenedorCampos.Controls.Add(this.txtDni);
            this.panelContenedorCampos.Controls.Add(this.lblNombre);
            this.panelContenedorCampos.Controls.Add(this.txtNombreApellido);
            this.panelContenedorCampos.Controls.Add(this.lblMail);
            this.panelContenedorCampos.Controls.Add(this.txtMail);
            this.panelContenedorCampos.Controls.Add(this.lblEspecialidad);
            this.panelContenedorCampos.Controls.Add(this.txtEspecialidad);
            this.panelContenedorCampos.Controls.Add(this.lblContrasena);
            this.panelContenedorCampos.Controls.Add(this.txtContrasena);
            this.panelContenedorCampos.Controls.Add(this.lblConfirmar);
            this.panelContenedorCampos.Controls.Add(this.txtConfirmarContrasena);
            this.panelContenedorCampos.Controls.Add(this.lblPregunta);
            this.panelContenedorCampos.Controls.Add(this.cmbPreguntaSecreta);
            this.panelContenedorCampos.Controls.Add(this.lblRespuesta);
            this.panelContenedorCampos.Controls.Add(this.txtRespuesta);
            this.panelContenedorCampos.Controls.Add(this.btnCrearUsuario);
            this.panelContenedorCampos.Controls.Add(this.btnCancelar);
            this.panelContenedorCampos.Location = new System.Drawing.Point(50, 70);
            this.panelContenedorCampos.Name = "panelContenedorCampos";
            this.panelContenedorCampos.Size = new System.Drawing.Size(550, 490);
            this.panelContenedorCampos.TabIndex = 1;
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatricula.Location = new System.Drawing.Point(42, 16);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(66, 17);
            this.lblMatricula.TabIndex = 0;
            this.lblMatricula.Text = "Matrícula";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Location = new System.Drawing.Point(45, 35);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(450, 25);
            this.txtMatricula.TabIndex = 1;
            this.txtMatricula.Text = "Ingrese su matrícula";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDni.Location = new System.Drawing.Point(42, 58);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(32, 17);
            this.lblDni.TabIndex = 2;
            this.lblDni.Text = "DNI";
            // 
            // txtDni
            // 
            this.txtDni.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDni.Location = new System.Drawing.Point(45, 78);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(450, 25);
            this.txtDni.TabIndex = 3;
            this.txtDni.Text = "Ingrese su DNI";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(42, 101);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(123, 17);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre y apellido";
            // 
            // txtNombreApellido
            // 
            this.txtNombreApellido.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreApellido.Location = new System.Drawing.Point(45, 121);
            this.txtNombreApellido.Name = "txtNombreApellido";
            this.txtNombreApellido.Size = new System.Drawing.Size(450, 25);
            this.txtNombreApellido.TabIndex = 5;
            this.txtNombreApellido.Text = "Ingrese su nombre completo";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMail.Location = new System.Drawing.Point(42, 144);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(121, 17);
            this.lblMail.TabIndex = 6;
            this.lblMail.Text = "Correo Electrónico";
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.Location = new System.Drawing.Point(45, 164);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(450, 25);
            this.txtMail.TabIndex = 7;
            this.txtMail.Text = "Ingrese su correo electrónico";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspecialidad.Location = new System.Drawing.Point(42, 187);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(84, 17);
            this.lblEspecialidad.TabIndex = 8;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEspecialidad.Location = new System.Drawing.Point(45, 207);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(450, 25);
            this.txtEspecialidad.TabIndex = 9;
            this.txtEspecialidad.Text = "Ingrese su especialidad profesional";
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasena.Location = new System.Drawing.Point(42, 230);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(77, 17);
            this.lblContrasena.TabIndex = 10;
            this.lblContrasena.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.Location = new System.Drawing.Point(45, 250);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(450, 25);
            this.txtContrasena.TabIndex = 11;
            this.txtContrasena.Text = "Ingrese su contraseña";
            // 
            // lblConfirmar
            // 
            this.lblConfirmar.AutoSize = true;
            this.lblConfirmar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmar.Location = new System.Drawing.Point(42, 273);
            this.lblConfirmar.Name = "lblConfirmar";
            this.lblConfirmar.Size = new System.Drawing.Size(143, 17);
            this.lblConfirmar.TabIndex = 12;
            this.lblConfirmar.Text = "Confirmar Contraseña";
            // 
            // txtConfirmarContrasena
            // 
            this.txtConfirmarContrasena.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmarContrasena.Location = new System.Drawing.Point(45, 293);
            this.txtConfirmarContrasena.Name = "txtConfirmarContrasena";
            this.txtConfirmarContrasena.Size = new System.Drawing.Size(450, 25);
            this.txtConfirmarContrasena.TabIndex = 13;
            this.txtConfirmarContrasena.Text = "Confirme su contraseña";
            // 
            // lblPregunta
            // 
            this.lblPregunta.AutoSize = true;
            this.lblPregunta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPregunta.Location = new System.Drawing.Point(42, 316);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(112, 17);
            this.lblPregunta.TabIndex = 14;
            this.lblPregunta.Text = "Pregunta Secreta";
            // 
            // cmbPreguntaSecreta
            // 
            this.cmbPreguntaSecreta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPreguntaSecreta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPreguntaSecreta.Items.AddRange(new object[] {
            "¿Primera mascota?",
            "¿Escuela Primaria?",
            "¿Comida favorita?",
            "¿Pelicula favorita?"});
            this.cmbPreguntaSecreta.Location = new System.Drawing.Point(45, 336);
            this.cmbPreguntaSecreta.Name = "cmbPreguntaSecreta";
            this.cmbPreguntaSecreta.Size = new System.Drawing.Size(450, 25);
            this.cmbPreguntaSecreta.TabIndex = 15;
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRespuesta.Location = new System.Drawing.Point(42, 360);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(70, 17);
            this.lblRespuesta.TabIndex = 16;
            this.lblRespuesta.Text = "Respuesta";
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRespuesta.Location = new System.Drawing.Point(45, 379);
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(450, 25);
            this.txtRespuesta.TabIndex = 17;
            this.txtRespuesta.Text = "Ingrese la respuesta";
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(140)))), ((int)(((byte)(70)))));
            this.btnCrearUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCrearUsuario.ForeColor = System.Drawing.Color.White;
            this.btnCrearUsuario.Location = new System.Drawing.Point(110, 440);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(150, 35);
            this.btnCrearUsuario.TabIndex = 18;
            this.btnCrearUsuario.Text = "Crear Usuario";
            this.btnCrearUsuario.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(15)))), ((int)(((byte)(58)))));
            this.btnCancelar.Location = new System.Drawing.Point(280, 440);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 35);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            // 
            // panelDecorativo
            // 
            this.panelDecorativo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panelDecorativo.Controls.Add(this.panel6);
            this.panelDecorativo.Controls.Add(this.panel5);
            this.panelDecorativo.Controls.Add(this.panel4);
            this.panelDecorativo.Controls.Add(this.panel3);
            this.panelDecorativo.Controls.Add(this.panel2);
            this.panelDecorativo.Controls.Add(this.panel1);
            this.panelDecorativo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDecorativo.Location = new System.Drawing.Point(0, 585);
            this.panelDecorativo.Name = "panelDecorativo";
            this.panelDecorativo.Size = new System.Drawing.Size(642, 15);
            this.panelDecorativo.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(535, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(107, 15);
            this.panel6.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(428, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(107, 15);
            this.panel5.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Yellow;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(321, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(107, 15);
            this.panel4.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(214, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(107, 15);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(107, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(107, 15);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(162)))), ((int)(((byte)(200)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 15);
            this.panel1.TabIndex = 0;
            // 
            // FormNuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 600);
            this.Controls.Add(this.panelDerecho);
            this.Controls.Add(this.panelIzquierdo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNuevoUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Nuevo Usuario";
            this.panelIzquierdo.ResumeLayout(false);
            this.panelIzquierdo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelDerecho.ResumeLayout(false);
            this.panelContenedorCampos.ResumeLayout(false);
            this.panelContenedorCampos.PerformLayout();
            this.panelDecorativo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        // Declaración de controles públicos para usarlos desde la validación
        public System.Windows.Forms.Panel panelIzquierdo;
        public System.Windows.Forms.Label lblSubtitulo;
        public System.Windows.Forms.Panel panelDerecho;
        public System.Windows.Forms.Label lblCrearUsuario;
        public System.Windows.Forms.Panel panelContenedorCampos;
        public System.Windows.Forms.TextBox txtMatricula;
        public System.Windows.Forms.TextBox txtDni;
        public System.Windows.Forms.TextBox txtNombreApellido;
        public System.Windows.Forms.TextBox txtMail;
        public System.Windows.Forms.TextBox txtEspecialidad;
        public System.Windows.Forms.TextBox txtContrasena;
        public System.Windows.Forms.TextBox txtConfirmarContrasena;
        public System.Windows.Forms.ComboBox cmbPreguntaSecreta;
        public System.Windows.Forms.TextBox txtRespuesta;
        public System.Windows.Forms.Button btnCrearUsuario;
        public System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblConfirmar;
        private System.Windows.Forms.Label lblPregunta;
        private System.Windows.Forms.Label lblRespuesta;
        private System.Windows.Forms.Panel panelDecorativo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbl_Cerrar;
        private System.Windows.Forms.Label lbl_Minimizar;
    }
}