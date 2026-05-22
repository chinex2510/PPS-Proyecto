using ConsultorioPsicopedagogico.CLogica;
using FluentValidation;
using FluentValidation.Results;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultorioPsicopedagogico.CPresentacion
{
    public partial class BajaConcurrente : Form
    {
        int encontrado = 0;
        public BajaConcurrente()
        {
            InitializeComponent();            
            dtg_Baja.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            var validacion = new ValidacionPaciente();
            ValidationResult resultados = validacion.Validate(this);
            if (!resultados.IsValid)
            {
                foreach (var error in resultados.Errors)
                {
                    MessageBox.Show(error.ErrorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_DniBusqueda.Focus();
                    txt_DniBusqueda.Clear();
                    return;
                }
            }
            else 
            {
                var logica = new ConcurrentesCL();
                var tabla = logica.BusquedaBaja(int.Parse(txt_DniBusqueda.Text));

                if (tabla == null || tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron resultados.");
                    return;
                }
                dtg_Baja.DataSource = tabla;
                encontrado = 1;
            }
           
        }

        private void btn_baja_Click(object sender, EventArgs e)
        {            
            var validacion = new ValidacionPaciente();
            ValidationResult resultados = validacion.Validate(this);
            if (!resultados.IsValid)
            {
                foreach (var error in resultados.Errors)
                {
                    MessageBox.Show(error.ErrorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_DniBusqueda.Focus();
                    txt_DniBusqueda.Clear();
                    return;
                }
            }
            else 
            {
                var logica = new ConcurrentesCL();
                var concurrente = logica.SeleccionarPorDni(int.Parse(txt_DniBusqueda.Text));
                if (concurrente == null)
                {
                    MessageBox.Show("No se encontró el concurrente para dar de baja.");
                    return;
                }
                if (encontrado == 0)
                {
                    MessageBox.Show("Debe buscar un paciente antes de eliminarlo.");
                    return;
                }
                var confirmResult = MessageBox.Show(
                    "¿Está seguro que desea eliminar este paciente?",
                    "Confirmar eliminación",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.OK)
                {
                    logica.EliminarPorDni(concurrente);
                    txt_DniBusqueda.Clear();
                }
                else
                {
                    txt_DniBusqueda.Clear();
                }
            }
            
        }

        private void txt_DniBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_DniBusqueda.Text))
            {
                
            }
        }
        public class ValidacionPaciente : AbstractValidator<BajaConcurrente>
        {
            public ValidacionPaciente()
            {
                RuleFor(x => x.txt_DniBusqueda.Text)
                    .NotEmpty().WithMessage("El DNI es obligatorio.")
                    .Matches(@"^\d{8}$").WithMessage("Ingrese un DNI valido");            
            }
        }
    }
}

//private void txt_Num_Recibo_TextChanged(object sender, EventArgs e)
//{
//    if (!String.IsNullOrEmpty(txt_Num_Recibo.Text))
//    {

//        // Verificar si cada carácter es un dígito numérico
//        foreach (char c in txt_Num_Recibo.Text)
//        {
//            if (!Char.IsDigit(c))
//            {
//                MessageBox.Show("Por favor, ingrese solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                txt_Num_Recibo.Text = ""; // Limpiar el TextBox si se ingresan caracteres no numéricos
//                return;
//            }
//        }

//        ClsLogicaVentas objVenta = new ClsLogicaVentas();
//        dgvHistorialVenta.DataSource = objVenta.mostrar_busqueda(Convert.ToInt32(txt_Num_Recibo.Text));
//    }
//    else
//    {
//        ClsLogicaVentas objVentas = new ClsLogicaVentas();
//        dgvHistorialVenta.DataSource = objVentas.mostrar_tabla_venta();

//        // Ajustar automáticamente el tamaño de las columnas
//        dgvHistorialVenta.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

//        // Alinear los datos al centro
//        foreach (DataGridViewColumn column in dgvHistorialVenta.Columns)
//        {
//            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
//        }
//    }

//}