using Microsoft.VisualBasic.ApplicationServices;
using Oracle.ManagedDataAccess.Client;
using project_nanibono.member;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace project_nanibono.word
{
    public partial class AdminWordManagement : UserControl
    {
        private Form parentForm;

        public AdminWordManagement(Form parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
            wordList();
        }

        public AdminWordManagement()
        {
            InitializeComponent();
        }

        private void button_wordInsert_Click(object sender, EventArgs e)       // 단어등록 버튼
        {
            MessageBox.Show("단어 등록 페이지로 이동합니다.");
            if (parentForm != null)
            {
                FormAdminWord formAdminWord = new FormAdminWord(parentForm);
                parentForm.Hide();
                formAdminWord.Show();
                formAdminWord.FormClosed += (s, args) =>
                {
                    parentForm.Hide();
                    wordList();
                };
            }
        }
        private void wordList() // 단어리스트 보여주는 메서드
        {
            try
            {
                using (OracleConnection con = new OracleConnection(DBINFO.getConnection()))
                {
                    con.Open();
                    OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();
                    DBINFO.sql = "SELECT " +
                         "CASE " +
                         "    WHEN category LIKE 'CT1%' THEN '정보처리기사' " +
                         "    WHEN category LIKE 'CT2%' THEN 'SQLD' " +
                         "    ELSE category " +
                         "END AS 카테고리, " +
                         "word_no as " + "번호" + ", word as " + "단어" + ", word_mean as " + "뜻" + 
                         ", insert_date as " + "등록일" +
                         " FROM word WHERE category like 'CT1%' or category like 'CT2%'" +
                         " Order by insert_date desc";

                    using (OracleCommand cmd = new OracleCommand(DBINFO.sql, con))
                    {
                        oracleDataAdapter.SelectCommand = cmd;
                        using (DataSet dataSet = new DataSet())
                        {
                            oracleDataAdapter.Fill(dataSet);

                            if (dataSet.Tables.Count > 0)
                            {
                                worddataGridView1.DataSource = dataSet.Tables[0];
                            }
                            else
                            {
                                MessageBox.Show("데이터가 없습니다.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 : " + ex.Message.ToString());
            }
        }
    }
}
