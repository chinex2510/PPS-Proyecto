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
            this.btn_volver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_concurrentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg_concurrentes
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(173)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtg_concurrentes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_concurrentes.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dtg_concurrentes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.dtg_concurrentes.GridColor = System.Drawing.Color.LavenderBlush;
            this.dtg_concurrentes.Location = new System.Drawing.Point(9, 65);
            this.dtg_concurrentes.Margin = new System.Windows.Forms.Padding(2);
            this.dtg_concurrentes.Name = "dtg_concurrentes";
            this.dtg_concurrentes.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(173)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dtg_concurrentes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_concurrentes.RowTemplate.Height = 24;
            this.dtg_concurrentes.Size = new System.Drawing.Size(1337, 388);
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
            this.Nombre.HeaderText = "Appelido y Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 125;
            // 
            // FechadeNac
            // 
            this.FechadeNac.DataPropertyName = "FechaNac";
            this.FechadeNac.HeaderText = "Fecha de Nacimiento";
            this.FechadeNac.MinimumWidth = 6;
            this.FechadeNac.Name = "FechadeNac";
            this.FechadeNac.Width = 125;
            // 
            // Diagnostico
            // 
            this.Diagnostico.DataPropertyName = "Diagnostico";
            this.Diagnostico.HeaderText = "Diagnostico";
            this.Diagnostico.MinimumWidth = 6;
            this.Diagnostico.Name = "Diagnostico";
            this.Diagnostico.Width = 125;
            // 
            // Escuela
            // 
            this.Escuela.DataPropertyName = "Escuela";
            this.Escuela.HeaderText = "Escuela";
            this.Escuela.MinimumWidth = 6;
            this.Escuela.Name = "Escuela";
            this.Escuela.Width = 125;
            // 
            // AñoEsc
            // 
            this.AñoEsc.DataPropertyName = "AnioEscolar";
            this.AñoEsc.HeaderText = "Año Escolar";
            this.AñoEsc.MinimumWidth = 6;
            this.AñoEsc.Name = "AñoEsc";
            this.AñoEsc.Width = 125;
            // 
            // NivelEsc
            // 
            this.NivelEsc.DataPropertyName = "NivelEscolar";
            this.NivelEsc.HeaderText = "Nivel Escolar";
            this.NivelEsc.MinimumWidth = 6;
            this.NivelEsc.Name = "NivelEsc";
            this.NivelEsc.Width = 125;
            // 
            // Domicilio
            // 
            this.Domicilio.DataPropertyName = "Domicilio";
            this.Domicilio.HeaderText = "Domicilio";
            this.Domicilio.MinimumWidth = 6;
            this.Domicilio.Name = "Domicilio";
            this.Domicilio.Width = 125;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "Tutor";
            this.Apellido.HeaderText = "Tutor";
            this.Apellido.MinimumWidth = 6;
            this.Apellido.Name = "Apellido";
            this.Apellido.Width = 125;
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
            this.Contacto.Name = "Contacto";
            // 
            // ObraSoc
            // 
            this.ObraSoc.DataPropertyName = "Obrasocial";
            this.ObraSoc.HeaderText = "Obra Social";
            this.ObraSoc.MinimumWidth = 6;
            this.ObraSoc.Name = "ObraSoc";
            this.ObraSoc.Width = 125;
            // 
            // txt_DniBusqueda
            // 
            this.txt_DniBusqueda.BackColor = System.Drawing.Color.LavenderBlush;
            this.txt_DniBusqueda.Location = new System.Drawing.Point(448, 30);
            this.txt_DniBusqueda.Margin = new System.Windows.Forms.Padding(2);
            this.txt_DniBusqueda.Name = "txt_DniBusqueda";
            this.txt_DniBusqueda.Size = new System.Drawing.Size(259, 20);
            this.txt_DniBusqueda.TabIndex = 1;
            this.txt_DniBusqueda.TextChanged += new System.EventHandler(this.txt_DniBusqueda_TextChanged);
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(173)))), ((int)(((byte)(233)))));
            this.btn_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.ForeColor = System.Drawing.Color.Purple;
            this.btn_buscar.Location = new System.Drawing.Point(730, 25);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(94, 26);
            this.btn_buscar.TabIndex = 2;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(173)))), ((int)(((byte)(233)))));
            this.btn_agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_agregar.ForeColor = System.Drawing.Color.Purple;
            this.btn_agregar.Location = new System.Drawing.Point(21, 458);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(112, 26);
            this.btn_agregar.TabIndex = 3;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.UseVisualStyleBackColor = false;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "CONCURRENTES";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ConsultorioPsicopedagogico.Properties.Resources.Screenshot_9;
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btn_editar
            // 
            this.btn_editar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(173)))), ((int)(((byte)(233)))));
            this.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.ForeColor = System.Drawing.Color.Purple;
            this.btn_editar.Location = new System.Drawing.Point(154, 458);
            this.btn_editar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(112, 26);
            this.btn_editar.TabIndex = 7;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = false;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(173)))), ((int)(((byte)(233)))));
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.ForeColor = System.Drawing.Color.Purple;
            this.btn_eliminar.Location = new System.Drawing.Point(282, 458);
            this.btn_eliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(112, 26);
            this.btn_eliminar.TabIndex = 8;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_volver
            // 
            this.btn_volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(173)))), ((int)(((byte)(233)))));
            this.btn_volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_volver.ForeColor = System.Drawing.Color.Purple;
            this.btn_volver.Location = new System.Drawing.Point(730, 458);
            this.btn_volver.Margin = new System.Windows.Forms.Padding(2);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(112, 26);
            this.btn_volver.TabIndex = 9;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = false;
            // 
            // Concurrentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1348, 494);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.txt_DniBusqueda);
            this.Controls.Add(this.dtg_concurrentes);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Concurrentes";
            this.Text = "Concurrentes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dtg_concurrentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}