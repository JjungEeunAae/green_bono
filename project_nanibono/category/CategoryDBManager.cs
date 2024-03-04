using Oracle.ManagedDataAccess.Client;
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
       
        public DataTable Select(string code)
        {
            OracleConnection oc = null;
            try
            {
                oc = new OracleConnection(DBINFO.getConnection());
                string sql = $"SELECT word, word_mean,insert_date FROM word WHERE category LIKE '{code}%' ORDER BY insert_date DESC";

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

        // [중분류]
        // 1. 정처기 조회
        public DataTable SelectELF()
        {
            OracleConnection oc = null;
            string ct1;
            try
            {
                oc = new OracleConnection(DBINFO.getConnection());
                string sql = "SELECT word, word_mean,insert_date FROM word WHERE category LIKE 'CT1%' ORDER BY insert_date DESC";

                OracleCommand cmd = new OracleCommand(sql,oc);
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

        // 2. SQLD
        public DataTable SelectSD()
        {
            OracleConnection oc = null;
            string ct2;
            try
            {
                oc = new OracleConnection(DBINFO.getConnection());
                string sql = "SELECT word, word_mean,insert_date FROM word WHERE category LIKE 'CT2%' ORDER BY insert_date DESC";
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
