using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string path = @"CPresentacion\ConcurrentesInactivos.cs";
        string content = File.ReadAllText(path, Encoding.UTF8);
        string target = @"string columnaDni = rbtnConcurrentes.Checked ? "DNI_C" : "dniTutor";
                    dt.DefaultView.RowFilter = string.Format("CONVERT({0}, System.String) LIKE '{1}%'", columnaDni, txt_DniBusqueda.Text);";
        
        string replacement = @"if (rbtnConcurrentes.Checked)
                    {
                        dt.DefaultView.RowFilter = string.Format("CONVERT(DNI_C, System.String) LIKE '{0}%' OR CONVERT(DNI_Tutor, System.String) LIKE '{0}%'", txt_DniBusqueda.Text);
                    }
                    else if (rbtnTutores.Checked)
                    {
                        dt.DefaultView.RowFilter = string.Format("CONVERT(dniTutor, System.String) LIKE '{0}%'", txt_DniBusqueda.Text);
                    }";
        
        if (content.Contains(target))
        {
            content = content.Replace(target, replacement);
            File.WriteAllText(path, content, Encoding.UTF8);
            Console.WriteLine("Replaced successfully.");
        }
        else
        {
            Console.WriteLine("Target not found.");
        }
    }
}
