using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace multi_experiment
{
    public class Connection_class
    {
        SqlConnection co;
        SqlCommand cmd;
        public Connection_class()
        {
            co = new SqlConnection(@"server=CHRISTO-SOJAN\SQLEXPRESS;database=experiment;Integrated security=True");
        }
        public int fn_exenonquery(string sqlquery)
        {
            if (co.State == ConnectionState.Open)
            {
                co.Close();
            }
            cmd = new SqlCommand(sqlquery, co);
            co.Open();
            int i = cmd.ExecuteNonQuery();
            co.Close();
            return i;
        }

        public string fn_exescalar(string sqlquery)
        {
            if (co.State == ConnectionState.Open)
            {
                co.Close();
            }
            cmd = new SqlCommand(sqlquery, co);
            co.Open();
            string s = cmd.ExecuteScalar().ToString();
            co.Close();
            return s;
        }

        public SqlDataReader fn_exereader(string sqlquery)
        {
            if (co.State == ConnectionState.Open)
            {
                co.Close();
            }
            cmd = new SqlCommand(sqlquery, co);
            co.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public DataSet fn_exeadapter(string sqlquery)
        {
            if (co.State == ConnectionState.Open)
            {
                co.Close();
            }
            co.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, co);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}