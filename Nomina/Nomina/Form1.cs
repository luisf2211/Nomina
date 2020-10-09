//using DocumentFormat.OpenXml.Drawing.Diagrams;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string connectionString = null;
        private string tableName = null;


        Exportar exportar = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Pon el connectiong string: 
            connectionString = @"Data Source=DESKTOP-V5M6LK3; Initial catalog = Layout_PrimerParcial; Integrated security = True";
            // Pon el nombre de la tabla: 
            tableName = "Nomina";
            exportar = new Exportar();
            Conexion.connectionString = connectionString;
            Conexion.tableName = tableName;
            dataGridView1.DataSource = exportar.GetData(); 


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            exportar.To_TXT(); 
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
