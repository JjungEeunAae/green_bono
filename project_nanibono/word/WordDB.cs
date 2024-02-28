using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Text;

namespace project_nanibono.word
{
    public class WordDB
    {
        string strconn = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.110)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=bono;Password=bono;";

        public DataTable SelectWord(string word)
        {
            OracleConnection oc = null;
            try
            {
                oc = new OracleConnection(strconn);

                oc.Open();
                string sql = "SELECT word" +
                              "     , word_mean" +
                               "     , insert_date" +
                                  "     , category" +
                                  "FROM word " +
                                 "ORDER BY 1 DESC";

                OracleDataAdapter adapter = new OracleDataAdapter();
                DataSet ds = new DataSet();

                OracleCommand oracleCommand = new OracleCommand(sql, oc);
                adapter.SelectCommand = oracleCommand;

                adapter.Fill(ds);

                oc.Close();
                return ds.Tables[0];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(e.Message);
                    Console.WriteLine("행있음");
                    return null;
                }

            }
    }
    } 
