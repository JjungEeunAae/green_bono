using Oracle.ManagedDataAccess.Client;
using project_nanibono.common;

namespace project_nanibono.request
{
    public partial class FormAdminUpdate : Form
    {
        private string request_no;

        public FormAdminUpdate(string requestCode)
        {
            InitializeComponent();

            request_no = requestCode;
            textbox_init();
            comboBox_init();
            requestForm(request_no);
        }

        private void requestForm(string requestCode)
        // textBox에 값 모두 넣어주는 메소드, requestCode는 요청코드이다.
        {
            string code;

            using (OracleConnection conn = new OracleConnection(DBINFO.strConnection))
            {
                conn.Open();
                string sql = "SELECT request_no, process_division, request_division" +
                             "     , request_content, request_date" +
                             "     , reason, id, r.word_no, word, word_mean, category " +
                               "FROM request r JOIN word w " +
                                 "ON r.word_no = w.word_no " +
                              "WHERE request_no = '" + requestCode + "'";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    using (OracleDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            textBox_admin.Text = "admin";       // 수정자
                            code = rdr["category"].ToString();
                            textBox_groupNo.Text = Common.getGroupDetailName(code.Split("_")[0].Substring(0, 3));  // 분류
                            textBox_category.Text = Common.getGroupDetailName(code);                               // 카테고리
                            textBox_wordMean.Text = rdr["word_mean"].ToString();                            // 단어설명
                            textBox_id.Text = rdr["id"].ToString();                                         // 아이디(요청자)
                            textBox_wordCode.Text = rdr["word_no"].ToString();                              // 단어코드
                            textBox_word.Text = rdr["word"].ToString();                                     // 단어명
                            textBox_requestContent.Text = rdr["request_content"].ToString();                // 요청내용
                            textBox_date.Text = rdr["request_date"].ToString();                             // 요청일

                            code = rdr["request_division"].ToString();
                            textBox_requestDivision.Text = Common.getGroupDetailName(code);                 // 요청구분
                        }
                        rdr.Close(); // OracleDataReader를 닫음
                    }
                }
            }
        }

        private void comboBox_processDivision_SelectedIndexChanged(object sender, EventArgs e)
        // 처리구분에서 N을 누르면 거절사유 선택란이 튀어나옴
        {
            if (!comboBox_processDivision.SelectedItem.ToString().Equals("N")) // 처리구분이 N이 아니면
            {
                if (comboBox_processDivision.SelectedItem.ToString() == "선택해주세요")
                {
                    requestForm(request_no);
                    textBox_word.ReadOnly = true;     // 단어명 못고치게
                    textBox_wordMean.ReadOnly = true; // 단어설명 못고치게
                }
                else
                {
                    textBox_word.ReadOnly = false;     // 단어명 고치게
                    textBox_wordMean.ReadOnly = false; // 단어설명 고치게
                }

                Control[] foundControls = Controls.Find("label_reason", true);
                Control[] foundControls2 = Controls.Find("comboBox_reason", true);

                if (foundControls.Length > 0 && foundControls2.Length > 0)
                {
                    Label label_reason = (Label)foundControls[0];
                    Controls.Remove(label_reason);

                    ComboBox comboBox_reqson = (ComboBox)foundControls2[0];
                    Controls.Remove(comboBox_reqson);
                    comboBox_reqson.SelectedIndex = 0;
                }
            }
            else
            {
                requestForm(request_no);
                textBox_word.ReadOnly = true;     // 단어명 못고치게
                textBox_wordMean.ReadOnly = true; // 단어설명 못고치게
                Controls.Add(label_reason);
                Controls.Add(comboBox_reason);
            }
        }

        private void comboBox_init()
        // 콤보박스에 값 집어넣기
        {
            List<string> list;
            //comboBox1
            list = Common.getGroupDetailNameList("RR");
            comboBox_reason.Items.Add("선택해주세요");
            for (int i = 0; i < list.Count; i++)
            {
                comboBox_reason.Items.Add(list[i]);
            }
            comboBox_reason.SelectedIndex = 0;

            comboBox_processDivision.Items.Add("선택해주세요");
            comboBox_processDivision.Items.Add("N");
            comboBox_processDivision.Items.Add("Y");
            comboBox_processDivision.SelectedIndex = 0;
        }

        private void textbox_init()
        // textBox에 대한 내용, ReadOnly으로 하면 textBox가 회색이 되는 바람에 백그라운드 색상도 따로 설정해줌
        {
            //text ReadOnly = true;
            textBox_admin.ReadOnly = true;
            textBox_groupNo.ReadOnly = true;
            textBox_category.ReadOnly = true;
            textBox_id.ReadOnly = true;
            textBox_wordCode.ReadOnly = true;
            textBox_requestDivision.ReadOnly = true;
            textBox_requestContent.ReadOnly = true;
            textBox_date.ReadOnly = true;

            textBox_admin.BackColor = Color.White;
            textBox_groupNo.BackColor = Color.White;
            textBox_category.BackColor = Color.White;
            textBox_id.BackColor = Color.White;
            textBox_wordCode.BackColor = Color.White;
            textBox_requestDivision.BackColor = Color.White;
            textBox_requestContent.BackColor = Color.White;
            textBox_date.BackColor = Color.White;

            textBox_word.BackColor = Color.White;
            textBox_wordMean.BackColor = Color.White;
        }

        public bool cilent()
        // 수정요청건 > 요청 내용에 대한 SQL 처리건
        {
            bool result = false;

            using (OracleConnection conn = new OracleConnection(DBINFO.strConnection))
            {
                string processDivision = comboBox_processDivision.Text;
                string groupDetailCode = Common.getGroupDetailNo(comboBox_reason.Text);
                if (processDivision.Equals("선택해주세요"))
                {
                    MessageBox.Show("처리구분을 선택해주세요");
                    return result;
                }

                string sql = "UPDATE request SET request_ryn = '"
                            + processDivision
                            + "', reason = '" + groupDetailCode
                            + "' WHERE request_no = '"
                            + request_no + "'";

                if (processDivision.Equals("N"))
                {
                    if (groupDetailCode == null)
                    {
                        MessageBox.Show("거절사유를 입력해주세요");
                        return result;
                    }

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        try
                        {
                            conn.Open();                              // 데이터베이스 연결 열기
                            int rowsAffected = cmd.ExecuteNonQuery(); // 쿼리 실행 및 영향 받은 행 수 가져오기

                            if (rowsAffected > 0)
                            {
                                return result = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                    }
                }
                else
                {
                    // 쿼리 실행
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        try
                        {
                            conn.Open();                              // 데이터베이스 연결 열기
                            int rowsAffected = cmd.ExecuteNonQuery(); // 쿼리 실행 및 영향 받은 행 수 가져오기

                            if (rowsAffected > 0)
                            {
                                return result = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                    }
                }
            }
            return result;
        }

        private void successBtn_Click(object sender, EventArgs e)
        // 처리완료 버튼
        {
            bool frist = cilent();

            if (frist)
            {
                using (OracleConnection conn = new OracleConnection(DBINFO.strConnection))
                {
                    // 성공하면 단어수정 진행하기
                    string sql = "UPDATE word SET word = '" + textBox_word.Text
                                    + "', word_mean = '" + textBox_wordMean.Text
                                    + "' WHERE word_no = '" + textBox_wordCode.Text + "'";
                    // 쿼리 실행
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        try
                        {
                            conn.Open();                              // 데이터베이스 연결 열기
                            int rowsAffected = cmd.ExecuteNonQuery(); // 쿼리 실행 및 영향 받은 행 수 가져오기

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("처리가 완료되었습니다.");
                                this.Close();                            // 현재 Form 닫기
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
