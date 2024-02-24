using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_nanibono.request
{
    internal class RequestDB
    {
        string strConnection = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));User Id=bono;Password=bono;";

        public void select(Label label9, Label label10, Label label11, Label label12, ComboBox comboBox1, ComboBox comboBox2, String word)
        {
            OracleConnection conn = new OracleConnection(strConnection);
            conn.Open();
            Console.WriteLine(word);
            // 아이디 자동조회
            OracleCommand cmd = new OracleCommand($"SELECT ID FROM member WHERE ID = 'test'", conn);
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                label9.Text = reader.GetString(0);
            }

            // 단어코드 자동조회
            cmd = new OracleCommand($"SELECT word_no FROM word WHERE word = :word", conn);
            cmd.Parameters.Add(":word", OracleDbType.Varchar2).Value = word;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                label10.Text = reader.GetString(0);
            }


            // 단어명 자동조회
            cmd = new OracleCommand($"SELECT word FROM word WHERE word = :word", conn);
            cmd.Parameters.Add(":word", OracleDbType.Varchar2).Value = word;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                label11.Text = reader.GetString(0);
            }


            // 요청일 자동조회
            DateTime nowDate = DateTime.Now;
            string rqDate = DateTime.Now.ToString("yyyy-MM-dd");
            label12.Text = rqDate;

            // 처리구분 콤보박스 조회 RQ
            cmd = new OracleCommand($"SELECT group_detail_name FROM group_detail WHERE GROUP_NO = 'RQ'", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0));
            }
            comboBox1.SelectedIndex = 0;

            // 요청구분 콤보박스 조회 RC
            cmd = new OracleCommand($"SELECT group_detail_name FROM group_detail WHERE GROUP_NO = 'RC'", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader.GetString(0));
            }
            comboBox2.SelectedIndex = 0;
            reader.Close();
            conn.Close();
        }

        public void insert(Label label9, Label label10, ComboBox comboBox1, ComboBox comboBox2, TextBox textBox1)
        {
            // 관리자한테 수정이나 삭제 요청하기
            // 요청코드, 아이디, 단어코드, 처리구분, 요청구분, 요청내용, 편입요청일(sysdate)
            // 아이디 - label9, 단어코드 - label10, 처리구분 - comboBox1
            // , 요청구분 - comboBox2, 요청내용 - textBox1
            string combo1 = "";
            string combo2 = "";

            if (comboBox1.Text.Equals("삭제"))
            {
                combo1 = "DELETE";
            }
            else
            {
                combo1 = "UPDATE";

            }
            if (comboBox2.Text.Equals("용어"))
            {
                combo2 = "RC1";
            }
            else
            {
                combo2 = "RC2";
            }

            OracleConnection conn = new OracleConnection(strConnection);
            conn.Open();
            OracleCommand cmd = new OracleCommand("INSERT INTO request (REQUEST_NO, PROCESS_DIVISION, REQUEST_DIVISION, REQUEST_CONTENT, REQUEST_DATE, REQUEST_RYN, ID, WORD_NO) " +
                                       "VALUES('RE' || RE.NEXTVAL, :processDivision, :requestDivision, :requestContent, SYSDATE, 'r', :id, :wordNo)", conn);

            cmd.Parameters.Add(":processDivision", OracleDbType.Varchar2).Value = combo1;
            cmd.Parameters.Add(":requestDivision", OracleDbType.Varchar2).Value = combo2;
            cmd.Parameters.Add(":requestContent", OracleDbType.Varchar2).Value = textBox1.Text;
            cmd.Parameters.Add(":id", OracleDbType.Varchar2).Value = label9.Text;
            cmd.Parameters.Add(":wordNo", OracleDbType.Varchar2).Value = label10.Text;

            int rowId = cmd.ExecuteNonQuery();
            if (rowId != 0)
            {
                Console.WriteLine($"{rowId}행을 삽입했습니다");
                MessageBox.Show("요청을 성공했습니다.");
            }
            else
            {
                MessageBox.Show("요청을 실패했습니다.");
            }
            conn.Close();

        }
    }
}
