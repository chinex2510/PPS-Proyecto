namespace ConsultorioPsicopedagogico.CPresentacion
{
    partial class Concurrentes
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
            this.dtg_concurrentes = new System.Windows.Forms.DataGridView();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechadeNac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diagnostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Escuela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AñoEsc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NivelEsc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObraSoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_DniBusqueda = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_inactivos = new System.Windows.Forms.Button();
            this.btn_volver = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelGridCard = new System.Windows.Forms.Panel();
            this.lbl_GridTitle = new System.Windows.Forms.Label();
            this.lbl_BuscarDni = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_concurrentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelGridCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtg_concurrentes
            // 
            this.dtg_concurrentes.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtg_concurrentes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_concurrentes.BackgroundColor = System.Drawing.Color.White;
            this.dtg_concurrentes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dtg_concurrentes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_concurrentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_concurrentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DNI,
            this.Nombre,
            this.FechadeNac,
            this.Diagnostico,
            this.Escuela,
            this.AñoEsc,
            this.NivelEsc,
            this.Domicilio,
            this.Apellido,
            this.Tutor,
            this.Contacto,
            this.ObraSoc});
            this.dtg_concurrentes.EnableHeadersVisualStyles = false;
            this.dtg_concurrentes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(224)))), ((int)(((byte)(238)))));
            this.dtg_concurrentes.Location = new System.Drawing.Point(15, 55);
            this.dtg_concurrentes.Margin = new System.Windows.Forms.Padding(2);
            this.dtg_concurrentes.Name = "dtg_concurrentes";
            this.dtg_concurrentes.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dtg_concurrentes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtg_concurrentes.RowTemplate.Height = 24;
            this.dtg_concurrentes.Size = new System.Drawing.Size(1280, 310);
            this.dtg_concurrentes.TabIndex = 0;
            // 
            // DNI
            // 
            this.DNI.DataPropertyName = "DNI_C";
            this.DNI.HeaderText = "DNI Paciente";
            this.DNI.MinimumWidth = 6;
            this.DNI.Name = "DNI";
            this.DNI.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "ApellidoNombre";
            this.Nombre.HeaderText = "Apellido y Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 150;
            // 
            // FechadeNac
            // 
            this.FechadeNac.DataPropertyName = "FechaNac";
            this.FechadeNac.HeaderText = "Fecha Nac.";
            this.FechadeNac.MinimumWidth = 6;
            this.FechadeNac.Name = "FechadeNac";
            this.FechadeNac.Width = 90;
            // 
            // Diagnostico
            // 
            this.Diagnostico.DataPropertyName = "Diagnostico";
            this.Diagnostico.HeaderText = "Diagnóstico";
            this.Diagnostico.MinimumWidth = 6;
            this.Diagnostico.Name = "Diagnostico";
            this.Diagnostico.Width = 120;
            // 
            // Escuela
            // 
            this.Escuela.DataPropertyName = "Escuela";
            this.Escuela.HeaderText = "Escuela";
            this.Escuela.MinimumWidth = 6;
            this.Escuela.Name = "Escuela";
            this.Escuela.Width = 120;
            // 
            // AñoEsc
            // 
            this.AñoEsc.DataPropertyName = "AnioEscolar";
            this.AñoEsc.HeaderText = "Año Esc.";
            this.AñoEsc.MinimumWidth = 6;
            this.AñoEsc.Name = "AñoEsc";
            this.AñoEsc.Width = 80;
            // 
            // NivelEsc
            // 
            this.NivelEsc.DataPropertyName = "NivelEscolar";
            this.NivelEsc.HeaderText = "Nivel Esc.";
            this.NivelEsc.MinimumWidth = 6;
            this.NivelEsc.Name = "NivelEsc";
            this.NivelEsc.Width = 90;
            // 
            // Domicilio
            // 
            this.Domicilio.DataPropertyName = "Domicilio";
            this.Domicilio.HeaderText = "Domicilio";
            this.Domicilio.MinimumWidth = 6;
            this.Domicilio.Name = "Domicilio";
            this.Domicilio.Width = 110;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "Tutor";
            this.Apellido.HeaderText = "Tutor";
            this.Apellido.MinimumWidth = 6;
            this.Apellido.Name = "Apellido";
            this.Apellido.Width = 120;
            // 
            // Tutor
            // 
            this.Tutor.DataPropertyName = "DNI_Tutor";
            this.Tutor.HeaderText = "DNI Tutor";
            this.Tutor.MinimumWidth = 6;
            this.Tutor.Name = "Tutor";
            this.Tutor.Width = 125;
            // 
            // Contacto
            // 
            this.Contacto.DataPropertyName = "ContactoTutor";
            this.Contacto.HeaderText = "Contacto Tutor";
            this.Contacto.MinimumWidth = 6;
            this.Contacto.Name = "Contacto";
            this.Contacto.Width = 120;
            // 
            // ObraSoc
            // 
            this.ObraSoc.DataPropertyName = "ObraSocial";
            this.ObraSoc.HeaderText = "Obra Social";
            this.ObraSoc.MinimumWidth = 6;
            this.ObraSoc.Name = "ObraSoc";
            this.ObraSoc.Width = 120;
            // 
            // txt_DniBusqueda
            // 
            this.txt_DniBusqueda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DniBusqueda.Location = new System.Drawing.Point(960, 17);
            this.txt_DniBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.txt_DniBusqueda.Name = "txt_DniBusqueda";
            this.txt_DniBusqueda.Size = new System.Drawing.Size(200, 29);
            this.txt_DniBusqueda.TabIndex = 1;
            this.txt_DniBusqueda.TextChanged += new System.EventHandler(this.txt_DniBusqueda_TextChanged);
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_buscar.FlatAppearance.BorderSize = 0;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.ForeColor = System.Drawing.Color.White;
            this.btn_buscar.Location = new System.Drawing.Point(1175, 14);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(100, 30);
            this.btn_buscar.TabIndex = 2;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_agregar.FlatAppearance.BorderSize = 0;
            this.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregar.ForeColor = System.Drawing.Color.White;
            this.btn_agregar.Location = new System.Drawing.Point(20, 505);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(130, 40);
            this.btn_agregar.TabIndex = 3;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.UseVisualStyleBackColor = false;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(80, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 46);
            this.label1.TabIndex = 5;
            this.label1.Text = "CONCURRENTES";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ConsultorioPsicopedagogico.Properties.Resources.Screenshot_9;
            this.pictureBox1.Location = new System.Drawing.Point(20, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btn_editar
            // 
            this.btn_editar.BackColor = System.Drawing.Color.White;
            this.btn_editar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.btn_editar.Location = new System.Drawing.Point(160, 505);
            this.btn_editar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(130, 40);
            this.btn_editar.TabIndex = 7;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = false;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackColor = System.Drawing.Color.White;
            this.btn_eliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_eliminar.Location = new System.Drawing.Point(300, 505);
            this.btn_eliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(130, 40);
            this.btn_eliminar.TabIndex = 8;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_inactivos
            // 
            this.btn_inactivos.BackColor = System.Drawing.Color.White;
            this.btn_inactivos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btn_inactivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_inactivos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inactivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btn_inactivos.Location = new System.Drawing.Point(961, 509);
            this.btn_inactivos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_inactivos.Name = "btn_inactivos";
            this.btn_inactivos.Size = new System.Drawing.Size(219, 40);
            this.btn_inactivos.TabIndex = 9;
            this.btn_inactivos.Text = "Concurrentes Inactivos";
            this.btn_inactivos.UseVisualStyleBackColor = false;
            this.btn_inactivos.Click += new System.EventHandler(this.btn_inactivos_Click);
            // 
            // btn_volver
            // 
            this.btn_volver.BackColor = System.Drawing.Color.White;
            this.btn_volver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btn_volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_volver.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_volver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btn_volver.Location = new System.Drawing.Point(1200, 505);
            this.btn_volver.Margin = new System.Windows.Forms.Padding(2);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(130, 40);
            this.btn_volver.TabIndex = 9;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = false;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(35)))), ((int)(((byte)(150)))));
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1350, 80);
            this.panelHeader.TabIndex = 10;
            // 
            // panelGridCard
            // 
            this.panelGridCard.BackColor = System.Drawing.Color.White;
            this.panelGridCard.Controls.Add(this.lbl_GridTitle);
            this.panelGridCard.Controls.Add(this.lbl_BuscarDni);
            this.panelGridCard.Controls.Add(this.txt_DniBusqueda);
            this.panelGridCard.Controls.Add(this.btn_buscar);
            this.panelGridCard.Controls.Add(this.dtg_concurrentes);
            this.panelGridCard.Location = new System.Drawing.Point(20, 100);
            this.panelGridCard.Name = "panelGridCard";
            this.panelGridCard.Size = new System.Drawing.Size(1310, 390);
            this.panelGridCard.TabIndex = 11;
            this.panelGridCard.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCard_Paint);
            // 
            // lbl_GridTitle
            // 
            this.lbl_GridTitle.AutoSize = true;
            this.lbl_GridTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(25)))), ((int)(((byte)(120)))));
            this.lbl_GridTitle.Location = new System.Drawing.Point(15, 18);
            this.lbl_GridTitle.Name = "lbl_GridTitle";
            this.lbl_GridTitle.Size = new System.Drawing.Size(272, 25);
            this.lbl_GridTitle.TabIndex = 3;
            this.lbl_GridTitle.Text = "LISTADO DE CONCURRENTES";
            // 
            // lbl_BuscarDni
            // 
            this.lbl_BuscarDni.AutoSize = true;
            this.lbl_BuscarDni.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BuscarDni.Location = new System.Drawing.Point(814, 20);
            this.lbl_BuscarDni.Name = "lbl_BuscarDni";
            this.lbl_BuscarDni.Size = new System.Drawing.Size(130, 23);
            this.lbl_BuscarDni.TabIndex = 4;
            this.lbl_BuscarDni.Text = "Buscar por DNI:";
            // 
            // Concurrentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1350, 560);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelGridCard);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_inactivos);
            this.Controls.Add(this.btn_volver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Concurrentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Concurrentes";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_concurrentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelGridCard.ResumeLayout(false);
            this.panelGridCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtg_concurrentes;
        private System.Windows.Forms.TextBox txt_DniBusqueda;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_inactivos;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechadeNac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diagnostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Escuela;
        private System.Windows.Forms.DataGridViewTextBoxColumn AñoEsc;
        private System.Windows.Forms.DataGridViewTextBoxColumn NivelEsc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObraSoc;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelGridCard;
        private System.Windows.Forms.Label lbl_GridTitle;
        private System.Windows.Forms.Label lbl_BuscarDni;
    }
}
