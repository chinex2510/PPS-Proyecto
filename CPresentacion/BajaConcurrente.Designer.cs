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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Baja)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ConsultorioPsicopedagogico.Properties.Resources.Screenshot_9;
            this.pictureBox1.Location = new System.Drawing.Point(11, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 39);
            this.label1.TabIndex = 9;
            this.label1.Text = "Eliminar Paciente";
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(173)))), ((int)(((byte)(233)))));
            this.btn_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.ForeColor = System.Drawing.Color.Purple;
            this.btn_buscar.Location = new System.Drawing.Point(274, 77);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(94, 26);
            this.btn_buscar.TabIndex = 8;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // txt_DniBusqueda
            // 
            this.txt_DniBusqueda.BackColor = System.Drawing.Color.LavenderBlush;
            this.txt_DniBusqueda.Location = new System.Drawing.Point(11, 81);
            this.txt_DniBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.txt_DniBusqueda.Name = "txt_DniBusqueda";
            this.txt_DniBusqueda.Size = new System.Drawing.Size(259, 20);
            this.txt_DniBusqueda.TabIndex = 7;
            this.txt_DniBusqueda.TextChanged += new System.EventHandler(this.txt_DniBusqueda_TextChanged);
            // 
            // dtg_Baja
            // 
            this.dtg_Baja.AllowUserToAddRows = false;
            this.dtg_Baja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Baja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DNI_C,
            this.ApellidoNombre,
            this.FechaNac,
            this.NomTutor,
            this.DNI_Tutor,
            this.ContactoTutor,
            this.ObraSocial});
            this.dtg_Baja.Location = new System.Drawing.Point(11, 121);
            this.dtg_Baja.Name = "dtg_Baja";
            this.dtg_Baja.Size = new System.Drawing.Size(747, 69);
            this.dtg_Baja.TabIndex = 11;
            this.dtg_Baja.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_baja
            // 
            this.btn_baja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(173)))), ((int)(((byte)(233)))));
            this.btn_baja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_baja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_baja.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_baja.ForeColor = System.Drawing.Color.Purple;
            this.btn_baja.Location = new System.Drawing.Point(372, 77);
            this.btn_baja.Margin = new System.Windows.Forms.Padding(2);
            this.btn_baja.Name = "btn_baja";
            this.btn_baja.Size = new System.Drawing.Size(94, 26);
            this.btn_baja.TabIndex = 12;
            this.btn_baja.Text = "Eliminar";
            this.btn_baja.UseVisualStyleBackColor = false;
            this.btn_baja.Click += new System.EventHandler(this.btn_baja_Click);
            // 
            // DNI_C
            // 
            this.DNI_C.DataPropertyName = "DNI_C";
            this.DNI_C.HeaderText = "DNI Paciente";
            this.DNI_C.Name = "DNI_C";
            // 
            // ApellidoNombre
            // 
            this.ApellidoNombre.DataPropertyName = "ApellidoNombre";
            this.ApellidoNombre.HeaderText = "Apellido y Nombre";
            this.ApellidoNombre.Name = "ApellidoNombre";
            // 
            // FechaNac
            // 
            this.FechaNac.DataPropertyName = "FechaNac";
            this.FechaNac.HeaderText = "Fecha de Nacimiento";
            this.FechaNac.Name = "FechaNac";
            // 
            // NomTutor
            // 
            this.NomTutor.DataPropertyName = "Tutor";
            this.NomTutor.HeaderText = "Tutor";
            this.NomTutor.Name = "NomTutor";
            // 
            // DNI_Tutor
            // 
            this.DNI_Tutor.DataPropertyName = "DNI_Tutor";
            this.DNI_Tutor.HeaderText = "DNI Tutor";
            this.DNI_Tutor.Name = "DNI_Tutor";
            // 
            // ContactoTutor
            // 
            this.ContactoTutor.DataPropertyName = "ContactoTutor";
            this.ContactoTutor.HeaderText = "Contacto Tutor";
            this.ContactoTutor.Name = "ContactoTutor";
            // 
            // ObraSocial
            // 
            this.ObraSocial.DataPropertyName = "ObraSocial";
            this.ObraSocial.HeaderText = "Obra Social";
            this.ObraSocial.Name = "ObraSocial";
            // 
            // BajaConcurrente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(790, 223);
            this.Controls.Add(this.btn_baja);
            this.Controls.Add(this.dtg_Baja);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.txt_DniBusqueda);
            this.Name = "BajaConcurrente";
            this.Text = "BajaConcurrente";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Baja)).EndInit();
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
    }
}