using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Nomina
{
    class Conexion
    {

        public static string connectionString { get; set; }
        public static string tableName { get; set; }
        protected string status { get; set; }
        protected SqlConnection connection;
        protected SqlCommand command;
        protected SqlDataReader dataReader;

        protected DataTable LoadDataWithALLColumns()
        {
            DataTable data = null;
            try
            {
                connection = new SqlConnection(connectionString);
                string query = string.Format("select * from {0}", tableName);
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        dataReader = command.ExecuteReader();
                        data = new DataTable();
                        data.Load(dataReader);
                    }

                }

                return data;

            }

            catch (Exception x)
            {

                MessageBox.Show(x.Message, "Error");
                return data;

            }
        }

        protected DataTable LoadDataWithParticularColumns(string[] columnsname)
        {
            string columns = "";
            foreach (string column in columnsname)
            {
                columns += column + ",";

            }

            columns = columns.Remove(columns.LastIndexOf(',', 1));

            DataTable data = null;
            try
            {
                connection = new SqlConnection(connectionString);
                string query = string.Format("select {0} from {1}", columns, tableName);
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        dataReader = command.ExecuteReader();
                        data = new DataTable();
                        data.Load(dataReader);
                    }
                }

                return data;

            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message, "La data no cargó");
                return data;
            }
        }

        protected DataTable LoadDataFromQuery(string query)
        {
            DataTable data = null;
            try
            {
                connection = new SqlConnection(connectionString);

                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        dataReader = command.ExecuteReader();
                        data = new DataTable();
                        data.Load(dataReader);
                    }
                }
                return data;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "La data no llegó");
                return data;

            }
        }
    }
}
