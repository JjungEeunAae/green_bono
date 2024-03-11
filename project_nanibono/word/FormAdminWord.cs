using Microsoft.VisualBasic.ApplicationServices;
using Oracle.ManagedDataAccess.Client;
using project_nanibono.common;
using project_nanibono.main;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace project_nanibono.word
{
    public partial class FormAdminWord : Form
    {
        private Form parentForm;

        GroupDetail groupDetail = new GroupDetail();
        Group group = new Group();
        Word word = new Word();
        public FormAdminWord(Form parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();

            comboBox1.SelectedIndex = 0; // comboBox1의 0번째 보여주는 코드
        }
        public string selectGoup_no()  // 정처기, sqld 중에 선택해서 선택 값 리턴하는 콤보박스1
        {
            string check = "";
            try
            {
                using (OracleConnection con = new OracleConnection(DBINFO.getConnection()))
                {
                    con.Open();
                    string c = comboBox1.SelectedItem.ToString();
                    DBINFO.sql = $"select group_detail_no from group_detail where group_detail_name='{c}'";
                    using (OracleCommand cmd = new OracleCommand(DBINFO.sql, con))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                check = reader.GetString(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 : " + ex.Message.ToString());
            }
            return check;
        }
        private void selectGroupName(object sender, EventArgs e) // 정처기 또는 sql 선택값에 따른 중분류 나오는 콤보박스2
        {
            string a = selectGoup_no();
            try
            {
                using (OracleConnection con = new OracleConnection(DBINFO.getConnection()))
                {
                    con.Open();
                    string c = comboBox1.SelectedItem.ToString();
                    DBINFO.sql = $"select group_detail_name from group_detail where group_detail_no like '{a}_%' and '{a}' is not null";
                    using (OracleCommand cmd = new OracleCommand(DBINFO.sql, con))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            List<string> list = new List<string>();

                            while (reader.Read())
                            {
                                comboBox2.Items.Clear();
                                comboBox2.Items.Add("== 선택하세요 ==");

                                list.Add(reader.GetString(0));
                            }

                            foreach (string s in list)
                            {
                                comboBox2.Items.Add(s);
                                comboBox2.SelectedIndex = 0;
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
        private void closeBtn_Click(object sender, EventArgs e) // 닫기 버튼  
        {
            MessageBox.Show("단어 페이지로 돌아갑니다.");
            this.Close();
            parentForm.Show();
        }
        private void successBtn_Click(object sender, EventArgs e) // 등록 버튼
        {
            if (textBoxValuesCheck())
            {
                insertWord();
                this.Close();
                parentForm.Show();
            }
        }
        private string selectGroupDetailNo() // 중분류 가져와서 group_detail_no 로 바꾸기
        {
            string result = "";
            string a = comboBox2.SelectedItem.ToString();
            try
            {
                using (OracleConnection con = new OracleConnection(DBINFO.getConnection()))
                {
                    con.Open();

                    DBINFO.sql = $"select group_detail_no from group_detail where group_detail_name like '{a}' and '{a}' is not null";
                    using (OracleCommand cmd = new OracleCommand(DBINFO.sql, con))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result = reader.GetString(0);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 : " + ex.Message.ToString());
            }
            return result;
        }
        private string sequenceSql() // 시퀀스 사용해서 insert 쿼리 넣는다.
        {
            string a = selectGoup_no();
            string b = "";

            if (a.Equals("CT1"))
            {
                b = "insert into word(word_no, word, word_mean, insert_date, delete_yn, category) " +
                        "values('ELF' || (ELF.nextval), :word, :word_mean, CURRENT_TIMESTAMP, 'N', :category)";

            }
            else if (a.Equals("CT2"))
            {
                b = "insert into word(word_no, word, word_mean, insert_date, delete_yn, category) " +
                        "values('SD' || (SD.nextval), :word, :word_mean, CURRENT_TIMESTAMP, 'N', :category)";
            }
            return b;
        }
        private void insertWord() // 단어 등록되는 전체 코드
        {
            word.word = textBox_word.Text;
            word.word_mean = textBox_wordMean.Text;
            word.category = selectGroupDetailNo();
            try
            {
                using (OracleConnection con = new OracleConnection(DBINFO.getConnection()))
                {
                    con.Open();

                    DBINFO.sql = sequenceSql();

                    using (OracleCommand cmd = new OracleCommand(DBINFO.sql, con))
                    {
                        cmd.Parameters.Add("word", word.word);
                        cmd.Parameters.Add("word_mean", word.word_mean);
                        cmd.Parameters.Add("category", word.category);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("단어가 성공적으로 등록되었습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test" + ex.Message);
            }
        }
        private bool textBoxValuesCheck() // 분류, 카테고리, 단어명, 단어설명 빈값 확인하는 메서드
        {
            if (string.IsNullOrEmpty(selectGoup_no()))
            {
                MessageBox.Show("분류를 선택하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(selectGroupDetailNo()))
            {
                MessageBox.Show("카테고리 선택하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(textBox_word.Text.Trim()))
            {
                MessageBox.Show("단어명을 입력하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(textBox_wordMean.Text.Trim()))
            {
                MessageBox.Show("단어 설명을 입력하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
    }
}
