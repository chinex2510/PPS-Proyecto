using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsultorioPsicopedagogico.CPresentacion;
using ConsultorioPsicopedagogico.CLogica;

namespace ConsultorioPsicopedagogico.CPresentacion
{
    public partial class Concurrentes : Form
    {
        public Concurrentes()
        {
            InitializeComponent();
            CargarConcurrentes();
            
        }

        private void CargarConcurrentes()
        {
            var logica = new ConcurrentesCL();
            var tabla = logica.MostrarTodos();
            if (tabla == null)
            {
                MessageBox.Show("No se pudo obtener datos de la base.");
                return;
            }
            dtg_concurrentes.DataSource = tabla;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            CPresentacion.NuevoConcurrente nuevoConcurrente = new CPresentacion.NuevoConcurrente();
            nuevoConcurrente.Show();
            this.Hide();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            var logica = new ConcurrentesCL();
            var tabla = logica.BuscarConcurrentePorDni(int.Parse(txt_DniBusqueda.Text));
            if(tabla== null || tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados.");
                return;
            }
            dtg_concurrentes.DataSource = tabla;

        }

        private void txt_DniBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_DniBusqueda.Text))
            {
                CargarConcurrentes();
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            var baja = new BajaConcurrente();
            baja.Show();
        }
    }
}
