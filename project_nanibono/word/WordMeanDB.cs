using Oracle.ManagedDataAccess.Client;

namespace project_nanibono.word
{
    public class WordMeanDB
    {
        string strconn = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.110)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=bono;Password=bono;";

        public void SelectWordMean(string wordMean)
        {
            OracleConnection oc = new OracleConnection(strconn);

            oc.Open();

            string sql = $"select * from word where word_mean = '{wordMean}'";
            OracleCommand cmd = new OracleCommand(sql, oc);
            OracleDataReader oracleDataReader = cmd.ExecuteReader();
            if (oracleDataReader.Read())
            {
                Console.WriteLine("행있음");
            }
            else
            {
                Console.WriteLine("행없음");
            }

            oc.Close();
        }
    }
}
