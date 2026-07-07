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
<<<<<<< Updated upstream
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelInputCard = new System.Windows.Forms.Panel();
            this.lbl_CardInputTitle = new System.Windows.Forms.Label();
            this.lbl_DniConcurrente = new System.Windows.Forms.Label();
            this.txt_DniConcurrente = new System.Windows.Forms.TextBox();
            this.btn_verificarConcurrente = new System.Windows.Forms.Button();
            this.lbl_NombreConcurrente = new System.Windows.Forms.Label();
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
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelInputCard.SuspendLayout();
            this.panelGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_turnos)).BeginInit();
=======
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lbl_HeaderTitle = new System.Windows.Forms.Label();
            this.panelFormCard = new System.Windows.Forms.Panel();
            this.lbl_FormTitle = new System.Windows.Forms.Label();
            this.lbl_DniConcurrente = new System.Windows.Forms.Label();
            this.txt_DniConcurrente = new System.Windows.Forms.TextBox();
            this.btn_buscarConcurrente = new System.Windows.Forms.Button();
            this.lbl_Paciente = new System.Windows.Forms.Label();
            this.lbl_NombreConcurrente = new System.Windows.Forms.Label();
            this.lbl_Fecha = new System.Windows.Forms.Label();
            this.dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.lbl_Hora = new System.Windows.Forms.Label();
            this.txt_Hora = new System.Windows.Forms.TextBox();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.panelGridCard = new System.Windows.Forms.Panel();
            this.lbl_GridTitle = new System.Windows.Forms.Label();
            this.dtg_Turnos = new System.Windows.Forms.DataGridView();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.btn_Volver = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelFormCard.SuspendLayout();
            this.panelGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Turnos)).BeginInit();
>>>>>>> Stashed changes
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
<<<<<<< Updated upstream
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
            this.label1.Size = new System.Drawing.Size(262, 32);
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
            this.panelInputCard.Size = new System.Drawing.Size(400, 345);
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
            this.lbl_CardInputTitle.Size = new System.Drawing.Size(147, 20);
            this.lbl_CardInputTitle.TabIndex = 0;
            this.lbl_CardInputTitle.Text = "DATOS DEL TURNO";
=======
            this.panelHeader.Controls.Add(this.lbl_HeaderTitle);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(940, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lbl_HeaderTitle
            // 
            this.lbl_HeaderTitle.AutoSize = true;
            this.lbl_HeaderTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lbl_HeaderTitle.Location = new System.Drawing.Point(20, 20);
            this.lbl_HeaderTitle.Name = "lbl_HeaderTitle";
            this.lbl_HeaderTitle.Size = new System.Drawing.Size(260, 37);
            this.lbl_HeaderTitle.TabIndex = 0;
            this.lbl_HeaderTitle.Text = "AGENDA Y TURNOS";
            // 
            // panelFormCard
            // 
            this.panelFormCard.BackColor = System.Drawing.Color.White;
            this.panelFormCard.Controls.Add(this.lbl_FormTitle);
            this.panelFormCard.Controls.Add(this.lbl_DniConcurrente);
            this.panelFormCard.Controls.Add(this.txt_DniConcurrente);
            this.panelFormCard.Controls.Add(this.btn_buscarConcurrente);
            this.panelFormCard.Controls.Add(this.lbl_Paciente);
            this.panelFormCard.Controls.Add(this.lbl_NombreConcurrente);
            this.panelFormCard.Controls.Add(this.lbl_Fecha);
            this.panelFormCard.Controls.Add(this.dtp_Fecha);
            this.panelFormCard.Controls.Add(this.lbl_Hora);
            this.panelFormCard.Controls.Add(this.txt_Hora);
            this.panelFormCard.Controls.Add(this.btn_Guardar);
            this.panelFormCard.Location = new System.Drawing.Point(20, 100);
            this.panelFormCard.Name = "panelFormCard";
            this.panelFormCard.Size = new System.Drawing.Size(360, 380);
            this.panelFormCard.TabIndex = 1;
            this.panelFormCard.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCard_Paint);
            // 
            // lbl_FormTitle
            // 
            this.lbl_FormTitle.AutoSize = true;
            this.lbl_FormTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(25)))), ((int)(((byte)(120)))));
            this.lbl_FormTitle.Location = new System.Drawing.Point(15, 15);
            this.lbl_FormTitle.Name = "lbl_FormTitle";
            this.lbl_FormTitle.Size = new System.Drawing.Size(142, 20);
            this.lbl_FormTitle.TabIndex = 0;
            this.lbl_FormTitle.Text = "DATOS DEL TURNO";
>>>>>>> Stashed changes
            // 
            // lbl_DniConcurrente
            // 
            this.lbl_DniConcurrente.AutoSize = true;
<<<<<<< Updated upstream
            this.lbl_DniConcurrente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DniConcurrente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbl_DniConcurrente.Location = new System.Drawing.Point(20, 50);
            this.lbl_DniConcurrente.Name = "lbl_DniConcurrente";
            this.lbl_DniConcurrente.Size = new System.Drawing.Size(100, 15);
=======
            this.lbl_DniConcurrente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DniConcurrente.Location = new System.Drawing.Point(15, 55);
            this.lbl_DniConcurrente.Name = "lbl_DniConcurrente";
            this.lbl_DniConcurrente.Size = new System.Drawing.Size(104, 17);
>>>>>>> Stashed changes
            this.lbl_DniConcurrente.TabIndex = 1;
            this.lbl_DniConcurrente.Text = "DNI Concurrente:";
            // 
            // txt_DniConcurrente
            // 
            this.txt_DniConcurrente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< Updated upstream
            this.txt_DniConcurrente.Location = new System.Drawing.Point(20, 70);
            this.txt_DniConcurrente.Name = "txt_DniConcurrente";
            this.txt_DniConcurrente.Size = new System.Drawing.Size(220, 25);
            this.txt_DniConcurrente.TabIndex = 2;
            this.txt_DniConcurrente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumbers_KeyPress);
            // 
            // btn_verificarConcurrente
            // 
            this.btn_verificarConcurrente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_verificarConcurrente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_verificarConcurrente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_verificarConcurrente.ForeColor = System.Drawing.Color.White;
            this.btn_verificarConcurrente.Location = new System.Drawing.Point(250, 68);
            this.btn_verificarConcurrente.Name = "btn_verificarConcurrente";
            this.btn_verificarConcurrente.Size = new System.Drawing.Size(130, 28);
            this.btn_verificarConcurrente.TabIndex = 3;
            this.btn_verificarConcurrente.Text = "Verificar Paciente";
            this.btn_verificarConcurrente.UseVisualStyleBackColor = false;
            this.btn_verificarConcurrente.FlatAppearance.BorderSize = 0;
            this.btn_verificarConcurrente.Click += new System.EventHandler(this.btn_verificarConcurrente_Click);
=======
            this.txt_DniConcurrente.Location = new System.Drawing.Point(15, 75);
            this.txt_DniConcurrente.MaxLength = 8;
            this.txt_DniConcurrente.Name = "txt_DniConcurrente";
            this.txt_DniConcurrente.Size = new System.Drawing.Size(210, 25);
            this.txt_DniConcurrente.TabIndex = 2;
            this.txt_DniConcurrente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumbers_KeyPress);
            // 
            // btn_buscarConcurrente
            // 
            this.btn_buscarConcurrente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_buscarConcurrente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_buscarConcurrente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscarConcurrente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscarConcurrente.ForeColor = System.Drawing.Color.White;
            this.btn_buscarConcurrente.Location = new System.Drawing.Point(235, 73);
            this.btn_buscarConcurrente.Name = "btn_buscarConcurrente";
            this.btn_buscarConcurrente.Size = new System.Drawing.Size(110, 29);
            this.btn_buscarConcurrente.TabIndex = 3;
            this.btn_buscarConcurrente.Text = "Buscar";
            this.btn_buscarConcurrente.UseVisualStyleBackColor = false;
            this.btn_buscarConcurrente.FlatAppearance.BorderSize = 0;
            this.btn_buscarConcurrente.Click += new System.EventHandler(this.btn_buscarConcurrente_Click);
            // 
            // lbl_Paciente
            // 
            this.lbl_Paciente.AutoSize = true;
            this.lbl_Paciente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Paciente.Location = new System.Drawing.Point(15, 110);
            this.lbl_Paciente.Name = "lbl_Paciente";
            this.lbl_Paciente.Size = new System.Drawing.Size(55, 15);
            this.lbl_Paciente.TabIndex = 4;
            this.lbl_Paciente.Text = "Paciente:";
>>>>>>> Stashed changes
            // 
            // lbl_NombreConcurrente
            // 
            this.lbl_NombreConcurrente.AutoSize = true;
<<<<<<< Updated upstream
            this.lbl_NombreConcurrente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NombreConcurrente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(60)))), ((int)(((byte)(160)))));
            this.lbl_NombreConcurrente.Location = new System.Drawing.Point(20, 98);
            this.lbl_NombreConcurrente.Name = "lbl_NombreConcurrente";
            this.lbl_NombreConcurrente.Size = new System.Drawing.Size(120, 15);
            this.lbl_NombreConcurrente.TabIndex = 4;
            this.lbl_NombreConcurrente.Text = "Paciente no verificado";
=======
            this.lbl_NombreConcurrente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NombreConcurrente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.lbl_NombreConcurrente.Location = new System.Drawing.Point(15, 130);
            this.lbl_NombreConcurrente.Name = "lbl_NombreConcurrente";
            this.lbl_NombreConcurrente.Size = new System.Drawing.Size(148, 17);
            this.lbl_NombreConcurrente.TabIndex = 5;
            this.lbl_NombreConcurrente.Text = "(Buscar concurrente...)";
>>>>>>> Stashed changes
            // 
            // lbl_Fecha
            // 
            this.lbl_Fecha.AutoSize = true;
<<<<<<< Updated upstream
            this.lbl_Fecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbl_Fecha.Location = new System.Drawing.Point(20, 125);
            this.lbl_Fecha.Name = "lbl_Fecha";
            this.lbl_Fecha.Size = new System.Drawing.Size(42, 15);
            this.lbl_Fecha.TabIndex = 5;
            this.lbl_Fecha.Text = "Fecha:";
            // 
            // dtp_FechaTurno
            // 
            this.dtp_FechaTurno.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_FechaTurno.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaTurno.Location = new System.Drawing.Point(20, 145);
            this.dtp_FechaTurno.Name = "dtp_FechaTurno";
            this.dtp_FechaTurno.Size = new System.Drawing.Size(360, 25);
            this.dtp_FechaTurno.TabIndex = 6;
=======
            this.lbl_Fecha.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fecha.Location = new System.Drawing.Point(15, 170);
            this.lbl_Fecha.Name = "lbl_Fecha";
            this.lbl_Fecha.Size = new System.Drawing.Size(44, 17);
            this.lbl_Fecha.TabIndex = 6;
            this.lbl_Fecha.Text = "Fecha:";
            // 
            // dtp_Fecha
            // 
            this.dtp_Fecha.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Fecha.Location = new System.Drawing.Point(15, 190);
            this.dtp_Fecha.Name = "dtp_Fecha";
            this.dtp_Fecha.Size = new System.Drawing.Size(330, 25);
            this.dtp_Fecha.TabIndex = 7;
>>>>>>> Stashed changes
            // 
            // lbl_Hora
            // 
            this.lbl_Hora.AutoSize = true;
<<<<<<< Updated upstream
            this.lbl_Hora.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Hora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lbl_Hora.Location = new System.Drawing.Point(20, 185);
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
            this.cbo_HoraTurno.Location = new System.Drawing.Point(20, 205);
            this.cbo_HoraTurno.Name = "cbo_HoraTurno";
            this.cbo_HoraTurno.Size = new System.Drawing.Size(360, 25);
            this.cbo_HoraTurno.TabIndex = 8;
=======
            this.lbl_Hora.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Hora.Location = new System.Drawing.Point(15, 230);
            this.lbl_Hora.Name = "lbl_Hora";
            this.lbl_Hora.Size = new System.Drawing.Size(107, 17);
            this.lbl_Hora.TabIndex = 8;
            this.lbl_Hora.Text = "Hora (ej: 10:30):";
            // 
            // txt_Hora
            // 
            this.txt_Hora.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Hora.Location = new System.Drawing.Point(15, 250);
            this.txt_Hora.Name = "txt_Hora";
            this.txt_Hora.Size = new System.Drawing.Size(330, 25);
            this.txt_Hora.TabIndex = 9;
>>>>>>> Stashed changes
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
<<<<<<< Updated upstream
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar.ForeColor = System.Drawing.Color.White;
            this.btn_Guardar.Location = new System.Drawing.Point(20, 250);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(170, 35);
            this.btn_Guardar.TabIndex = 9;
            this.btn_Guardar.Text = "Registrar Turno";
=======
            this.btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar.ForeColor = System.Drawing.Color.White;
            this.btn_Guardar.Location = new System.Drawing.Point(15, 300);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(330, 40);
            this.btn_Guardar.TabIndex = 10;
            this.btn_Guardar.Text = "Guardar Turno";
>>>>>>> Stashed changes
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.FlatAppearance.BorderSize = 0;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
<<<<<<< Updated upstream
            // btn_Modificar
            // 
            this.btn_Modificar.BackColor = System.Drawing.Color.White;
            this.btn_Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Modificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_Modificar.Location = new System.Drawing.Point(210, 250);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(170, 35);
            this.btn_Modificar.TabIndex = 10;
            this.btn_Modificar.Text = "Modificar";
            this.btn_Modificar.UseVisualStyleBackColor = false;
            this.btn_Modificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
=======
            // panelGridCard
            // 
            this.panelGridCard.BackColor = System.Drawing.Color.White;
            this.panelGridCard.Controls.Add(this.lbl_GridTitle);
            this.panelGridCard.Controls.Add(this.dtg_Turnos);
            this.panelGridCard.Controls.Add(this.btn_Eliminar);
            this.panelGridCard.Controls.Add(this.btn_Modificar);
            this.panelGridCard.Location = new System.Drawing.Point(400, 100);
            this.panelGridCard.Name = "panelGridCard";
            this.panelGridCard.Size = new System.Drawing.Size(520, 380);
            this.panelGridCard.TabIndex = 2;
            this.panelGridCard.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCard_Paint);
            // 
            // lbl_GridTitle
            // 
            this.lbl_GridTitle.AutoSize = true;
            this.lbl_GridTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(25)))), ((int)(((byte)(120)))));
            this.lbl_GridTitle.Location = new System.Drawing.Point(15, 15);
            this.lbl_GridTitle.Name = "lbl_GridTitle";
            this.lbl_GridTitle.Size = new System.Drawing.Size(183, 20);
            this.lbl_GridTitle.TabIndex = 0;
            this.lbl_GridTitle.Text = "TURNOS PROGRAMADOS";
            // 
            // dtg_Turnos
            // 
            this.dtg_Turnos.AllowUserToAddRows = false;
            this.dtg_Turnos.BackgroundColor = System.Drawing.Color.White;
            this.dtg_Turnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtg_Turnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Turnos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(224)))), ((int)(((byte)(238)))));
            this.dtg_Turnos.Location = new System.Drawing.Point(15, 55);
            this.dtg_Turnos.Name = "dtg_Turnos";
            this.dtg_Turnos.Size = new System.Drawing.Size(490, 250);
            this.dtg_Turnos.TabIndex = 1;
            this.dtg_Turnos.EnableHeadersVisualStyles = false;
            
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dtg_Turnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtg_Turnos.RowsDefaultCellStyle = dataGridViewCellStyle2;

            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dtg_Turnos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
>>>>>>> Stashed changes
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.BackColor = System.Drawing.Color.White;
<<<<<<< Updated upstream
            this.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Eliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_Eliminar.Location = new System.Drawing.Point(20, 295);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(170, 35);
            this.btn_Eliminar.TabIndex = 11;
            this.btn_Eliminar.Text = "Eliminar";
=======
            this.btn_Eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Eliminar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_Eliminar.Location = new System.Drawing.Point(15, 325);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(230, 40);
            this.btn_Eliminar.TabIndex = 2;
            this.btn_Eliminar.Text = "Eliminar Seleccionado";
>>>>>>> Stashed changes
            this.btn_Eliminar.UseVisualStyleBackColor = false;
            this.btn_Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
<<<<<<< Updated upstream
            // btn_Limpiar
            // 
            this.btn_Limpiar.BackColor = System.Drawing.Color.White;
            this.btn_Limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Limpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Limpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btn_Limpiar.Location = new System.Drawing.Point(210, 295);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(170, 35);
            this.btn_Limpiar.TabIndex = 12;
            this.btn_Limpiar.Text = "Limpiar Campos";
            this.btn_Limpiar.UseVisualStyleBackColor = false;
            this.btn_Limpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // panelGridCard
            // 
            this.panelGridCard.BackColor = System.Drawing.Color.White;
            this.panelGridCard.Controls.Add(this.lbl_CardGridTitle);
            this.panelGridCard.Controls.Add(this.dtg_turnos);
            this.panelGridCard.Location = new System.Drawing.Point(440, 90);
            this.panelGridCard.Name = "panelGridCard";
            this.panelGridCard.Size = new System.Drawing.Size(540, 345);
            this.panelGridCard.TabIndex = 2;
            this.panelGridCard.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCard_Paint);
            // 
            // lbl_CardGridTitle
            // 
            this.lbl_CardGridTitle.AutoSize = true;
            this.lbl_CardGridTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CardGridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(25)))), ((int)(((byte)(120)))));
            this.lbl_CardGridTitle.Location = new System.Drawing.Point(15, 15);
            this.lbl_CardGridTitle.Name = "lbl_CardGridTitle";
            this.lbl_CardGridTitle.Size = new System.Drawing.Size(161, 20);
            this.lbl_CardGridTitle.TabIndex = 0;
            this.lbl_CardGridTitle.Text = "LISTADO DE TURNOS";
            // 
            // dtg_turnos
            // 
            this.dtg_turnos.AllowUserToAddRows = false;
            this.dtg_turnos.BackgroundColor = System.Drawing.Color.White;
            this.dtg_turnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtg_turnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_turnos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(224)))), ((int)(((byte)(238)))));
            this.dtg_turnos.Location = new System.Drawing.Point(15, 50);
            this.dtg_turnos.Name = "dtg_turnos";
            this.dtg_turnos.ReadOnly = true;
            this.dtg_turnos.RowHeadersWidth = 51;
            this.dtg_turnos.RowTemplate.Height = 24;
            this.dtg_turnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_turnos.Size = new System.Drawing.Size(510, 275);
            this.dtg_turnos.TabIndex = 1;
            this.dtg_turnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_turnos_CellClick);
            this.dtg_turnos.EnableHeadersVisualStyles = false;

            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dtg_turnos.ColumnHeadersDefaultCellStyle = headerStyle;

            System.Windows.Forms.DataGridViewCellStyle rowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            rowStyle.SelectionForeColor = System.Drawing.Color.Black;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtg_turnos.RowsDefaultCellStyle = rowStyle;

            System.Windows.Forms.DataGridViewCellStyle alternatingStyle = new System.Windows.Forms.DataGridViewCellStyle();
            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            alternatingStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            alternatingStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            alternatingStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dtg_turnos.AlternatingRowsDefaultCellStyle = alternatingStyle;
            // 
            // btn_volver
            // 
            this.btn_volver.BackColor = System.Drawing.Color.White;
            this.btn_volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_volver.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_volver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btn_volver.Location = new System.Drawing.Point(850, 448);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(130, 35);
            this.btn_volver.TabIndex = 3;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = false;
            this.btn_volver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
=======
            // btn_Modificar
            // 
            this.btn_Modificar.BackColor = System.Drawing.Color.White;
            this.btn_Modificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Modificar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_Modificar.Location = new System.Drawing.Point(275, 325);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(230, 40);
            this.btn_Modificar.TabIndex = 3;
            this.btn_Modificar.Text = "Modificar Seleccionado";
            this.btn_Modificar.UseVisualStyleBackColor = false;
            this.btn_Modificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
            // 
            // btn_Volver
            // 
            this.btn_Volver.BackColor = System.Drawing.Color.White;
            this.btn_Volver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Volver.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Volver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btn_Volver.Location = new System.Drawing.Point(20, 498);
            this.btn_Volver.Name = "btn_Volver";
            this.btn_Volver.Size = new System.Drawing.Size(170, 40);
            this.btn_Volver.TabIndex = 3;
            this.btn_Volver.Text = "Volver al Menú";
            this.btn_Volver.UseVisualStyleBackColor = false;
            this.btn_Volver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btn_Volver.Click += new System.EventHandler(this.btn_Volver_Click);
>>>>>>> Stashed changes
            // 
            // Turnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
<<<<<<< Updated upstream
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelInputCard);
            this.Controls.Add(this.panelGridCard);
            this.Controls.Add(this.btn_volver);
=======
            this.ClientSize = new System.Drawing.Size(940, 550);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelFormCard);
            this.Controls.Add(this.panelGridCard);
            this.Controls.Add(this.btn_Volver);
>>>>>>> Stashed changes
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Turnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
<<<<<<< Updated upstream
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
=======
            this.Text = "Turnos";
            this.Load += new System.EventHandler(this.Turnos_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFormCard.ResumeLayout(false);
            this.panelFormCard.PerformLayout();
            this.panelGridCard.ResumeLayout(false);
            this.panelGridCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Turnos)).EndInit();
>>>>>>> Stashed changes
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
<<<<<<< Updated upstream
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
=======
        private System.Windows.Forms.Label lbl_HeaderTitle;
        private System.Windows.Forms.Panel panelFormCard;
        private System.Windows.Forms.Label lbl_FormTitle;
        private System.Windows.Forms.Label lbl_DniConcurrente;
        private System.Windows.Forms.TextBox txt_DniConcurrente;
        private System.Windows.Forms.Button btn_buscarConcurrente;
        private System.Windows.Forms.Label lbl_Paciente;
        private System.Windows.Forms.Label lbl_NombreConcurrente;
        private System.Windows.Forms.Label lbl_Fecha;
        private System.Windows.Forms.DateTimePicker dtp_Fecha;
        private System.Windows.Forms.Label lbl_Hora;
        private System.Windows.Forms.TextBox txt_Hora;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Panel panelGridCard;
        private System.Windows.Forms.Label lbl_GridTitle;
        private System.Windows.Forms.DataGridView dtg_Turnos;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Modificar;
        private System.Windows.Forms.Button btn_Volver;
>>>>>>> Stashed changes
    }
}