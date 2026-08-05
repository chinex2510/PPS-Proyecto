namespace ConsultorioPsicopedagogico.CPresentacion
{
    partial class Turnos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelInputCard = new System.Windows.Forms.Panel();
            this.lbl_CardInputTitle = new System.Windows.Forms.Label();
            this.lbl_DniConcurrente = new System.Windows.Forms.Label();
            this.txt_DniConcurrente = new System.Windows.Forms.TextBox();
            this.lbl_NombreConcurrente = new System.Windows.Forms.Label();
            this.lbl_NombrePaciente = new System.Windows.Forms.Label();
            this.txt_NombrePaciente = new System.Windows.Forms.TextBox();
            this.lbl_Especialista = new System.Windows.Forms.Label();
            this.cbo_Especialista = new System.Windows.Forms.ComboBox();
            this.lbl_Fecha = new System.Windows.Forms.Label();
            this.dtp_FechaTurno = new System.Windows.Forms.DateTimePicker();
            this.lbl_Hora = new System.Windows.Forms.Label();
            this.cbo_HoraTurno = new System.Windows.Forms.ComboBox();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.panelGridCard = new System.Windows.Forms.Panel();
            this.lbl_CardGridTitle = new System.Windows.Forms.Label();
            this.dtg_turnos = new System.Windows.Forms.DataGridView();
            this.btn_volver = new System.Windows.Forms.Button();
            this.lbl_FiltroFecha = new System.Windows.Forms.Label();
            this.cbo_FiltroFecha = new System.Windows.Forms.ComboBox();
            this.btn_verificarConcurrente = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelInputCard.SuspendLayout();
            this.panelGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_turnos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ConsultorioPsicopedagogico.Properties.Resources.Screenshot_9;
            this.pictureBox1.Location = new System.Drawing.Point(20, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(80, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "GESTIÓN DE TURNOS";
            // 
            // panelInputCard
            // 
            this.panelInputCard.BackColor = System.Drawing.Color.White;
            this.panelInputCard.Controls.Add(this.lbl_CardInputTitle);
            this.panelInputCard.Controls.Add(this.lbl_DniConcurrente);
            this.panelInputCard.Controls.Add(this.txt_DniConcurrente);
            this.panelInputCard.Controls.Add(this.btn_verificarConcurrente);
            this.panelInputCard.Controls.Add(this.lbl_NombreConcurrente);
            this.panelInputCard.Controls.Add(this.lbl_NombrePaciente);
            this.panelInputCard.Controls.Add(this.txt_NombrePaciente);
            this.panelInputCard.Controls.Add(this.lbl_Especialista);
            this.panelInputCard.Controls.Add(this.cbo_Especialista);
            this.panelInputCard.Controls.Add(this.lbl_Fecha);
            this.panelInputCard.Controls.Add(this.dtp_FechaTurno);
            this.panelInputCard.Controls.Add(this.lbl_Hora);
            this.panelInputCard.Controls.Add(this.cbo_HoraTurno);
            this.panelInputCard.Controls.Add(this.btn_Guardar);
            this.panelInputCard.Controls.Add(this.btn_Modificar);
            this.panelInputCard.Controls.Add(this.btn_Eliminar);
            this.panelInputCard.Controls.Add(this.btn_Limpiar);
            this.panelInputCard.Location = new System.Drawing.Point(20, 90);
            this.panelInputCard.Name = "panelInputCard";
            this.panelInputCard.Size = new System.Drawing.Size(400, 435);
            this.panelInputCard.TabIndex = 1;
            this.panelInputCard.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCard_Paint);
            // 
            // lbl_CardInputTitle
            // 
            this.lbl_CardInputTitle.AutoSize = true;
            this.lbl_CardInputTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CardInputTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(25)))), ((int)(((byte)(120)))));
            this.lbl_CardInputTitle.Location = new System.Drawing.Point(20, 15);
            this.lbl_CardInputTitle.Name = "lbl_CardInputTitle";
            this.lbl_CardInputTitle.Size = new System.Drawing.Size(145, 20);
            this.lbl_CardInputTitle.TabIndex = 0;
            this.lbl_CardInputTitle.Text = "DATOS DEL TURNO";
            // 
            // lbl_DniConcurrente
            // 
            this.lbl_DniConcurrente.AutoSize = true;
            this.lbl_DniConcurrente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DniConcurrente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbl_DniConcurrente.Location = new System.Drawing.Point(20, 50);
            this.lbl_DniConcurrente.Name = "lbl_DniConcurrente";
            this.lbl_DniConcurrente.Size = new System.Drawing.Size(105, 15);
            this.lbl_DniConcurrente.TabIndex = 1;
            this.lbl_DniConcurrente.Text = "DNI Concurrente:";
            // 
            // txt_DniConcurrente
            // 
            this.txt_DniConcurrente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DniConcurrente.Location = new System.Drawing.Point(20, 70);
            this.txt_DniConcurrente.Name = "txt_DniConcurrente";
            this.txt_DniConcurrente.Size = new System.Drawing.Size(220, 25);
            this.txt_DniConcurrente.TabIndex = 2;
            this.txt_DniConcurrente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumbers_KeyPress);
            // 
            // btn_verificarConcurrente
            // 
            this.btn_verificarConcurrente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_verificarConcurrente.FlatAppearance.BorderSize = 0;
            this.btn_verificarConcurrente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_verificarConcurrente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_verificarConcurrente.ForeColor = System.Drawing.Color.White;
            this.btn_verificarConcurrente.Location = new System.Drawing.Point(250, 68);
            this.btn_verificarConcurrente.Name = "btn_verificarConcurrente";
            this.btn_verificarConcurrente.Size = new System.Drawing.Size(130, 28);
            this.btn_verificarConcurrente.TabIndex = 3;
            this.btn_verificarConcurrente.Text = "Buscar Turno";
            this.btn_verificarConcurrente.UseVisualStyleBackColor = false;
            this.btn_verificarConcurrente.Click += new System.EventHandler(this.btn_verificarConcurrente_Click);
            // 
            // lbl_NombreConcurrente
            // 
            this.lbl_NombreConcurrente.AutoSize = true;
            this.lbl_NombreConcurrente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NombreConcurrente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(60)))), ((int)(((byte)(160)))));
            this.lbl_NombreConcurrente.Location = new System.Drawing.Point(20, 98);
            this.lbl_NombreConcurrente.Name = "lbl_NombreConcurrente";
            this.lbl_NombreConcurrente.Size = new System.Drawing.Size(122, 15);
            this.lbl_NombreConcurrente.TabIndex = 4;
            this.lbl_NombreConcurrente.Text = "Paciente no verificado";
            // 
            // lbl_NombrePaciente
            // 
            this.lbl_NombrePaciente.AutoSize = true;
            this.lbl_NombrePaciente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NombrePaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbl_NombrePaciente.Location = new System.Drawing.Point(20, 120);
            this.lbl_NombrePaciente.Name = "lbl_NombrePaciente";
            this.lbl_NombrePaciente.Size = new System.Drawing.Size(107, 15);
            this.lbl_NombrePaciente.TabIndex = 15;
            this.lbl_NombrePaciente.Text = "Nombre Paciente:";
            // 
            // txt_NombrePaciente
            // 
            this.txt_NombrePaciente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombrePaciente.Location = new System.Drawing.Point(20, 140);
            this.txt_NombrePaciente.Name = "txt_NombrePaciente";
            this.txt_NombrePaciente.Size = new System.Drawing.Size(360, 25);
            this.txt_NombrePaciente.TabIndex = 16;
            // 
            // lbl_Especialista
            // 
            this.lbl_Especialista.AutoSize = true;
            this.lbl_Especialista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Especialista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbl_Especialista.Location = new System.Drawing.Point(20, 175);
            this.lbl_Especialista.Name = "lbl_Especialista";
            this.lbl_Especialista.Size = new System.Drawing.Size(72, 15);
            this.lbl_Especialista.TabIndex = 13;
            this.lbl_Especialista.Text = "Especialista:";
            // 
            // cbo_Especialista
            // 
            this.cbo_Especialista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Especialista.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Especialista.FormattingEnabled = true;
            this.cbo_Especialista.Location = new System.Drawing.Point(20, 195);
            this.cbo_Especialista.Name = "cbo_Especialista";
            this.cbo_Especialista.Size = new System.Drawing.Size(360, 25);
            this.cbo_Especialista.TabIndex = 14;
            // 
            // lbl_Fecha
            // 
            this.lbl_Fecha.AutoSize = true;
            this.lbl_Fecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbl_Fecha.Location = new System.Drawing.Point(20, 230);
            this.lbl_Fecha.Name = "lbl_Fecha";
            this.lbl_Fecha.Size = new System.Drawing.Size(42, 15);
            this.lbl_Fecha.TabIndex = 5;
            this.lbl_Fecha.Text = "Fecha:";
            // 
            // dtp_FechaTurno
            // 
            this.dtp_FechaTurno.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_FechaTurno.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaTurno.Location = new System.Drawing.Point(20, 250);
            this.dtp_FechaTurno.Name = "dtp_FechaTurno";
            this.dtp_FechaTurno.Size = new System.Drawing.Size(360, 25);
            this.dtp_FechaTurno.TabIndex = 6;
            // 
            // lbl_Hora
            // 
            this.lbl_Hora.AutoSize = true;
            this.lbl_Hora.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Hora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbl_Hora.Location = new System.Drawing.Point(20, 285);
            this.lbl_Hora.Name = "lbl_Hora";
            this.lbl_Hora.Size = new System.Drawing.Size(37, 15);
            this.lbl_Hora.TabIndex = 7;
            this.lbl_Hora.Text = "Hora:";
            // 
            // cbo_HoraTurno
            // 
            this.cbo_HoraTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_HoraTurno.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_HoraTurno.FormattingEnabled = true;
            this.cbo_HoraTurno.Location = new System.Drawing.Point(20, 305);
            this.cbo_HoraTurno.Name = "cbo_HoraTurno";
            this.cbo_HoraTurno.Size = new System.Drawing.Size(360, 25);
            this.cbo_HoraTurno.TabIndex = 8;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_Guardar.FlatAppearance.BorderSize = 0;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar.ForeColor = System.Drawing.Color.White;
            this.btn_Guardar.Location = new System.Drawing.Point(20, 345);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(170, 35);
            this.btn_Guardar.TabIndex = 9;
            this.btn_Guardar.Text = "Registrar Turno";
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Modificar
            // 
            this.btn_Modificar.BackColor = System.Drawing.Color.White;
            this.btn_Modificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Modificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_Modificar.Location = new System.Drawing.Point(210, 345);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(170, 35);
            this.btn_Modificar.TabIndex = 10;
            this.btn_Modificar.Text = "Modificar";
            this.btn_Modificar.UseVisualStyleBackColor = false;
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.BackColor = System.Drawing.Color.White;
            this.btn_Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Eliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_Eliminar.Location = new System.Drawing.Point(20, 385);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(170, 35);
            this.btn_Eliminar.TabIndex = 11;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = false;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.White;
            this.btn_Limpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btn_Limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Limpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Limpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btn_Limpiar.Location = new System.Drawing.Point(210, 385);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(170, 35);
            this.btn_Limpiar.TabIndex = 12;
            this.btn_Limpiar.Text = "Limpiar Campos";
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // panelGridCard
            // 
            this.panelGridCard.BackColor = System.Drawing.Color.White;
            this.panelGridCard.Controls.Add(this.lbl_CardGridTitle);
            this.panelGridCard.Controls.Add(this.dtg_turnos);
            this.panelGridCard.Controls.Add(this.lbl_FiltroFecha);
            this.panelGridCard.Controls.Add(this.cbo_FiltroFecha);
            this.panelGridCard.Location = new System.Drawing.Point(440, 90);
            this.panelGridCard.Name = "panelGridCard";
            this.panelGridCard.Size = new System.Drawing.Size(540, 435);
            this.panelGridCard.TabIndex = 2;
            this.panelGridCard.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCard_Paint);
            // 
            // lbl_FiltroFecha
            // 
            this.lbl_FiltroFecha.AutoSize = true;
            this.lbl_FiltroFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FiltroFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbl_FiltroFecha.Location = new System.Drawing.Point(235, 18);
            this.lbl_FiltroFecha.Name = "lbl_FiltroFecha";
            this.lbl_FiltroFecha.Size = new System.Drawing.Size(81, 15);
            this.lbl_FiltroFecha.TabIndex = 2;
            this.lbl_FiltroFecha.Text = "Filtrar Fecha:";
            // 
            // cbo_FiltroFecha
            // 
            this.cbo_FiltroFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_FiltroFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_FiltroFecha.FormattingEnabled = true;
            this.cbo_FiltroFecha.Location = new System.Drawing.Point(325, 15);
            this.cbo_FiltroFecha.Name = "cbo_FiltroFecha";
            this.cbo_FiltroFecha.Size = new System.Drawing.Size(200, 23);
            this.cbo_FiltroFecha.TabIndex = 3;
            // 
            // lbl_CardGridTitle
            // 
            this.lbl_CardGridTitle.AutoSize = true;
            this.lbl_CardGridTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CardGridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(25)))), ((int)(((byte)(120)))));
            this.lbl_CardGridTitle.Location = new System.Drawing.Point(15, 15);
            this.lbl_CardGridTitle.Name = "lbl_CardGridTitle";
            this.lbl_CardGridTitle.Size = new System.Drawing.Size(159, 20);
            this.lbl_CardGridTitle.TabIndex = 0;
            this.lbl_CardGridTitle.Text = "LISTADO DE TURNOS";
            // 
            // dtg_turnos
            // 
            this.dtg_turnos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtg_turnos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_turnos.BackgroundColor = System.Drawing.Color.White;
            this.dtg_turnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dtg_turnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_turnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_turnos.EnableHeadersVisualStyles = false;
            this.dtg_turnos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(224)))), ((int)(((byte)(238)))));
            this.dtg_turnos.Location = new System.Drawing.Point(15, 50);
            this.dtg_turnos.Name = "dtg_turnos";
            this.dtg_turnos.ReadOnly = true;
            this.dtg_turnos.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dtg_turnos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtg_turnos.RowTemplate.Height = 24;
            this.dtg_turnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_turnos.Size = new System.Drawing.Size(510, 365);
            this.dtg_turnos.TabIndex = 1;
            this.dtg_turnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_turnos_CellClick);
            // 
            // btn_volver
            // 
            this.btn_volver.BackColor = System.Drawing.Color.White;
            this.btn_volver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btn_volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_volver.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_volver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btn_volver.Location = new System.Drawing.Point(850, 531);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(130, 35);
            this.btn_volver.TabIndex = 3;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = false;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // Turnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1000, 577);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelInputCard);
            this.Controls.Add(this.panelGridCard);
            this.Controls.Add(this.btn_volver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Turnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Turnos";
            this.Load += new System.EventHandler(this.Turnos_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelInputCard.ResumeLayout(false);
            this.panelInputCard.PerformLayout();
            this.panelGridCard.ResumeLayout(false);
            this.panelGridCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_turnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelInputCard;
        private System.Windows.Forms.Label lbl_CardInputTitle;
        private System.Windows.Forms.Label lbl_DniConcurrente;
        private System.Windows.Forms.TextBox txt_DniConcurrente;
        private System.Windows.Forms.Button btn_verificarConcurrente;
        private System.Windows.Forms.Label lbl_NombreConcurrente;
        private System.Windows.Forms.Label lbl_Fecha;
        private System.Windows.Forms.DateTimePicker dtp_FechaTurno;
        private System.Windows.Forms.Label lbl_Hora;
        private System.Windows.Forms.ComboBox cbo_HoraTurno;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Modificar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Panel panelGridCard;
        private System.Windows.Forms.Label lbl_CardGridTitle;
        private System.Windows.Forms.DataGridView dtg_turnos;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.Label lbl_Especialista;
        private System.Windows.Forms.ComboBox cbo_Especialista;
        private System.Windows.Forms.Label lbl_NombrePaciente;
        private System.Windows.Forms.TextBox txt_NombrePaciente;
        private System.Windows.Forms.Label lbl_FiltroFecha;
        private System.Windows.Forms.ComboBox cbo_FiltroFecha;
    }
}