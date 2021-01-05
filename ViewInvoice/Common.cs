using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ViewInvoice
{
    public static class Common
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
        public static int UserId;
        public static Setting GeneralSetting = new Setting();
        public static Dictionary<string, PointF> Coordinates = new Dictionary<string, PointF>();
        public static string CompanyName = "Sharif Enterprises";
        public static int ExecuteNonQuery(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static DataSet GetDataSet(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection))
                {
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    return ds;
                }
            }
        }

        
    }
}
