using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultorioPsicopedagogico.CPresentacion
{
    public partial class FormRecuperarContrasena : Form
    {
        public FormRecuperarContrasena()
        {
            InitializeComponent();

            panelTarjetaCampos.Paint += (s, e) => RedondearControl(panelTarjetaCampos, 40);
            btnConfirmar.Paint += (s, e) => RedondearControl(btnConfirmar, 18);
            btnCancelar.Paint += (s, e) => RedondearControl(btnCancelar, 18);

            btnCancelar.Click += (s, e) => this.Close();
        }

        private void RedondearControl(Control control, int radio)
        {
            GraphicsPath forma = new GraphicsPath();
            forma.StartFigure();
            forma.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            forma.AddArc(new Rectangle(control.Width - radio, 0, radio, radio), 270, 90);
            forma.AddArc(new Rectangle(control.Width - radio, control.Height - radio, radio, radio), 0, 90);
            forma.AddArc(new Rectangle(0, control.Height - radio, radio, radio), 90, 90);
            forma.CloseFigure();
            control.Region = new Region(forma);
        }
    }
}
