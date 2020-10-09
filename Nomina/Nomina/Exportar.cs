using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomina
{
    class Exportar: Conexion

    {

        public DataTable Tab = new DataTable();


        public Exportar() { }

        public DataTable GetData()
        {
            Tab = base.LoadDataWithALLColumns();
            return Tab; 
        }

        public DataTable GetData(string[] columnsname)
        {
            Tab = base.LoadDataWithParticularColumns(columnsname);
            return Tab;
        }

        public DataTable GetData(string query)
        {
            Tab = base.LoadDataFromQuery(query);
            return Tab;
        }


        // Exportar la data a TXT 

        public void To_TXT()
        {

            try
            {
                string filename = null;
                SaveFileDialog SaveTxt = new SaveFileDialog();
                SaveTxt.Filter = "TEXT FILES|*. txt";
                SaveTxt.FileName = "Layout.txt";
                if (SaveTxt.ShowDialog() == DialogResult.OK)
                {
                    filename = SaveTxt.FileName; 

                }

                using (StreamWriter sw = new StreamWriter(filename))
                {
                    FileInfo fileInfo = new FileInfo(filename);
                    StringBuilder sb = new StringBuilder();
                    //sb.AppendFormat("Este documento fue creado el: " + DateTime.Now.ToShortDateString() + " a las " + DateTime.Now.ToShortTimeString());
                    sb.AppendLine("");

                    foreach (DataRow row in Tab.Rows)
                    {
                        for (int i = 0; i < Tab.Columns.Count; i++)
                        {
                            sb.AppendFormat("{1}: {2}", (i + 1), Tab.Columns[i].ColumnName.ToUpper(), row[i].ToString());

                            sb.AppendLine(""); 

                        }
                        sb.AppendLine("");
                        

                        sw.Write(sb.ToString()); 

                    }
                }

            }


            catch (Exception x )
            {

                MessageBox.Show(x.Message, "Export to TXT Error"); 
            }

            
          
        }












    }


}
