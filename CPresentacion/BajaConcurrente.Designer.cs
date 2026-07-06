namespace ConsultorioPsicopedagogico.CPresentacion
{
    partial class BajaConcurrente
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_DniBusqueda = new System.Windows.Forms.TextBox();
            this.dtg_Baja = new System.Windows.Forms.DataGridView();
            this.btn_baja = new System.Windows.Forms.Button();
            this.DNI_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomTutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI_Tutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactoTutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObraSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelBajaCard = new System.Windows.Forms.Panel();
            this.lbl_CardTitle = new System.Windows.Forms.Label();
            this.lbl_BuscarDni = new System.Windows.Forms.Label();
            this.btn_volver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Baja)).BeginInit();
            this.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelBajaCard.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ConsultorioPsicopedagogico.Properties.Resources.Screenshot_9;
            this.pictureBox1.Location = new System.Drawing.Point(20, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(80, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "ELIMINAR PACIENTE / BAJA";
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.ForeColor = System.Drawing.Color.White;
            this.btn_buscar.Location = new System.Drawing.Point(325, 45);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(100, 29);
            this.btn_buscar.TabIndex = 8;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.FlatAppearance.BorderSize = 0;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // txt_DniBusqueda
            // 
            this.txt_DniBusqueda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DniBusqueda.Location = new System.Drawing.Point(130, 47);
            this.txt_DniBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.txt_DniBusqueda.Name = "txt_DniBusqueda";
            this.txt_DniBusqueda.Size = new System.Drawing.Size(180, 25);
            this.txt_DniBusqueda.TabIndex = 7;
            this.txt_DniBusqueda.TextChanged += new System.EventHandler(this.txt_DniBusqueda_TextChanged);
            // 
            // dtg_Baja
            // 
            this.dtg_Baja.AllowUserToAddRows = false;
            this.dtg_Baja.BackgroundColor = System.Drawing.Color.White;
            this.dtg_Baja.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtg_Baja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Baja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DNI_C,
            this.ApellidoNombre,
            this.FechaNac,
            this.NomTutor,
            this.DNI_Tutor,
            this.ContactoTutor,
            this.ObraSocial});
            this.dtg_Baja.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(224)))), ((int)(((byte)(238)))));
            this.dtg_Baja.Location = new System.Drawing.Point(15, 95);
            this.dtg_Baja.Name = "dtg_Baja";
            this.dtg_Baja.Size = new System.Drawing.Size(750, 110);
            this.dtg_Baja.TabIndex = 11;
            this.dtg_Baja.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dtg_Baja.EnableHeadersVisualStyles = false;

            System.Windows.Forms.DataGridViewCellStyle cellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            cellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            cellStyle1.ForeColor = System.Drawing.Color.White;
            cellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            cellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dtg_Baja.ColumnHeadersDefaultCellStyle = cellStyle1;

            System.Windows.Forms.DataGridViewCellStyle cellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            cellStyle2.BackColor = System.Drawing.Color.White;
            cellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            cellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            cellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            cellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtg_Baja.RowsDefaultCellStyle = cellStyle2;
            // 
            // btn_baja
            // 
            this.btn_baja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_baja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_baja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_baja.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_baja.ForeColor = System.Drawing.Color.White;
            this.btn_baja.Location = new System.Drawing.Point(435, 45);
            this.btn_baja.Margin = new System.Windows.Forms.Padding(2);
            this.btn_baja.Name = "btn_baja";
            this.btn_baja.Size = new System.Drawing.Size(100, 29);
            this.btn_baja.TabIndex = 12;
            this.btn_baja.Text = "Eliminar";
            this.btn_baja.UseVisualStyleBackColor = false;
            this.btn_baja.FlatAppearance.BorderSize = 0;
            this.btn_baja.Click += new System.EventHandler(this.btn_baja_Click);
            // 
            // btn_volver
            // 
            this.btn_volver.BackColor = System.Drawing.Color.White;
            this.btn_volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_volver.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_volver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btn_volver.Location = new System.Drawing.Point(665, 45);
            this.btn_volver.Margin = new System.Windows.Forms.Padding(2);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(100, 29);
            this.btn_volver.TabIndex = 13;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = false;
            this.btn_volver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // DNI_C
            // 
            this.DNI_C.DataPropertyName = "DNI_C";
            this.DNI_C.HeaderText = "DNI Paciente";
            this.DNI_C.Name = "DNI_C";
            this.DNI_C.Width = 100;
            // 
            // ApellidoNombre
            // 
            this.ApellidoNombre.DataPropertyName = "ApellidoNombre";
            this.ApellidoNombre.HeaderText = "Apellido y Nombre";
            this.ApellidoNombre.Name = "ApellidoNombre";
            this.ApellidoNombre.Width = 140;
            // 
            // FechaNac
            // 
            this.FechaNac.DataPropertyName = "FechaNac";
            this.FechaNac.HeaderText = "Fecha Nacimiento";
            this.FechaNac.Name = "FechaNac";
            this.FechaNac.Width = 110;
            // 
            // NomTutor
            // 
            this.NomTutor.DataPropertyName = "Tutor";
            this.NomTutor.HeaderText = "Tutor";
            this.NomTutor.Name = "NomTutor";
            this.NomTutor.Width = 110;
            // 
            // DNI_Tutor
            // 
            this.DNI_Tutor.DataPropertyName = "DNI_Tutor";
            this.DNI_Tutor.HeaderText = "DNI Tutor";
            this.DNI_Tutor.Name = "DNI_Tutor";
            this.DNI_Tutor.Width = 90;
            // 
            // ContactoTutor
            // 
            this.ContactoTutor.DataPropertyName = "ContactoTutor";
            this.ContactoTutor.HeaderText = "Contacto Tutor";
            this.ContactoTutor.Name = "ContactoTutor";
            this.ContactoTutor.Width = 100;
            // 
            // ObraSocial
            // 
            this.ObraSocial.DataPropertyName = "ObraSocial";
            this.ObraSocial.HeaderText = "Obra Social";
            this.ObraSocial.Name = "ObraSocial";
            this.ObraSocial.Width = 100;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(820, 70);
            this.panelHeader.TabIndex = 14;
            // 
            // panelBajaCard
            // 
            this.panelBajaCard.BackColor = System.Drawing.Color.White;
            this.panelBajaCard.Controls.Add(this.lbl_CardTitle);
            this.panelBajaCard.Controls.Add(this.lbl_BuscarDni);
            this.panelBajaCard.Controls.Add(this.txt_DniBusqueda);
            this.panelBajaCard.Controls.Add(this.btn_buscar);
            this.panelBajaCard.Controls.Add(this.btn_baja);
            this.panelBajaCard.Controls.Add(this.btn_volver);
            this.panelBajaCard.Controls.Add(this.dtg_Baja);
            this.panelBajaCard.Location = new System.Drawing.Point(20, 90);
            this.panelBajaCard.Name = "panelBajaCard";
            this.panelBajaCard.Size = new System.Drawing.Size(780, 220);
            this.panelBajaCard.TabIndex = 15;
            this.panelBajaCard.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCard_Paint);
            // 
            // lbl_CardTitle
            // 
            this.lbl_CardTitle.AutoSize = true;
            this.lbl_CardTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(25)))), ((int)(((byte)(120)))));
            this.lbl_CardTitle.Location = new System.Drawing.Point(15, 15);
            this.lbl_CardTitle.Name = "lbl_CardTitle";
            this.lbl_CardTitle.Size = new System.Drawing.Size(209, 20);
            this.lbl_CardTitle.TabIndex = 0;
            this.lbl_CardTitle.Text = "BÚSQUEDA Y CONFIRMACIÓN";
            // 
            // lbl_BuscarDni
            // 
            this.lbl_BuscarDni.AutoSize = true;
            this.lbl_BuscarDni.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BuscarDni.Location = new System.Drawing.Point(15, 50);
            this.lbl_BuscarDni.Name = "lbl_BuscarDni";
            this.lbl_BuscarDni.Size = new System.Drawing.Size(97, 17);
            this.lbl_BuscarDni.TabIndex = 1;
            this.lbl_BuscarDni.Text = "Buscar por DNI:";
            // 
            // BajaConcurrente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(820, 330);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelBajaCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BajaConcurrente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baja Concurrente";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Baja)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBajaCard.ResumeLayout(false);
            this.panelBajaCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox txt_DniBusqueda;
        private System.Windows.Forms.DataGridView dtg_Baja;
        private System.Windows.Forms.Button btn_baja;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNac;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomTutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI_Tutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactoTutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObraSocial;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelBajaCard;
        private System.Windows.Forms.Label lbl_CardTitle;
        private System.Windows.Forms.Label lbl_BuscarDni;
        private System.Windows.Forms.Button btn_volver;
    }
}