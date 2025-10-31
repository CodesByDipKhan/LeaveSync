using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementSystem
{
    internal class DataConnect
    {
        static string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\AIUB\\6th Semester\\EmployeeLeaveManagementSystem\\ELMSDB.mdf\";Integrated Security=True;Connect Timeout=30";

        public static DataTable GetData(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection(_connectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool ExecuteQuery(string query)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
