﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_nanibono.category
{
    public class CategoryDBManager
    {
        public DataTable Select(string category)
        {
            OracleConnection oc = null;
            try
            {
                oc = new OracleConnection(DBINFO.getConnection());
                string sql = $"SELECT word, word_mean,insert_date " +
                    $"FROM word WHERE category LIKE '{category}%'" +
                    $"AND delete_yn = 'N' ORDER BY word_no ASC";

                OracleCommand cmd = new OracleCommand(sql, oc);
                oc.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = cmd;

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                if (oc != null && oc.State == ConnectionState.Open)
                {
                    oc.Close();
                }
            }
        }
    }
}
