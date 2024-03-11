using Oracle.ManagedDataAccess.Client;

namespace project_nanibono.member
{
    public class MemberDB
    { 
        string strconn = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.110)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=bono;Password=bono;";    
        public Member SelectId(string id)
        {   
            using (OracleConnection oc = new OracleConnection(strconn))
            {
                oc.Open();             
                string sql = $"select * from Member where id = '{id}'";              
                using (OracleCommand cmd = new OracleCommand(sql, oc))
                {
                    using (OracleDataReader oracleDataReader = cmd.ExecuteReader())
                    {
                        if (oracleDataReader.Read())
                        {
                            Member dbMember = new Member()
                            {
                                id = oracleDataReader["Id"].ToString(),
                                role = oracleDataReader["role"].ToString()
                            };
                            return dbMember;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public Member SelectPw(string pw)
        {
            using (OracleConnection oc = new OracleConnection(strconn))
            {        
                oc.Open();
                string sql = $"select * from Member where pw = '{pw}'";
                using (OracleCommand cmd = new OracleCommand(sql, oc))
                {
                    using (OracleDataReader oracleDataReader = cmd.ExecuteReader())
                    {                    
                        if (oracleDataReader.Read())
                        {
                            Member dbMember = new Member()
                            {
                                pw = oracleDataReader["PW"].ToString(),
                            };
                            return dbMember;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}
