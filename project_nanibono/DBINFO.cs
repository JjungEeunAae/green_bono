using Oracle.ManagedDataAccess.Client;

namespace project_nanibono
{
    public static class DBINFO
    {
        public static string getConnection() // db 연결하는 메서드
        {
            string dbstr = "DATA SOURCE=192.168.0.110; User Id=bono; Password=bono";

            // 각자 집에서 DB 연결할 때 쓸 string 변수
            //string dbstr = "DATA SOURCE=localhost; User Id=green; Password=1234";
            return dbstr;
        }

        public static OracleConnection con = new OracleConnection(getConnection());
        public static OracleCommand cmd = new OracleCommand();
        public static string sql = "";


        // 은애코드
        public static string strConnection = "DATA SOURCE=192.168.0.110; User Id=bono; Password=bono";
        //public static string strConnection = "DATA SOURCE=localhost; User Id=green; Password=1234";
        public static OracleConnection conn = new OracleConnection(strConnection);
        public static OracleCommand cmd_eunae;
        public static OracleDataReader rdr_eunae;
    }
}
