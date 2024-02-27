using Microsoft.VisualBasic.ApplicationServices;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace project_nanibono.word
{
    public partial class AdminWordManagement : UserControl
    {
        private Form parentForm;

        public AdminWordManagement(Form parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_wordInsert_Click(object sender, EventArgs e) // 단어등록 버튼
        {
            MessageBox.Show("단어 등록 페이지로 이동합니다.");
            parentForm.Hide();
            FormAdminWord formAdminWord = new FormAdminWord(parentForm);
            formAdminWord.Show();
        }

        private void wordlistGridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(DBINFO.getConnection()))
                {
                    con.Open();
                    OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();
                    DBINFO.sql = "select word_no, word, word_mean, insert_date from word";
                    using (OracleCommand cmd = new OracleCommand(DBINFO.sql, con))
                    {
                        oracleDataAdapter.SelectCommand = cmd;
                        using (DataSet dataSet = new DataSet())
                        {
                            oracleDataAdapter.Fill(dataSet);

                            dataGridView1.DataSource = dataSet.Tables[0];
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
