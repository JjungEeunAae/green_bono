using Oracle.ManagedDataAccess.Client;
using project_nanibono.common;

namespace project_nanibono.request
{
    public partial class AdminRequestManagement : UserControl
    {
        private Form parentForm;

        string[,] request_columns = { { "request_no", "요청코드" }
                                    , { "request_division", "요청구분" }
                                    , { "word_no", "단어코드" }
                                    , { "word", "단어" }
                                    , { "id", "요청자" }
                                    , { "request_content", "내용" }
                                    , { "request_date", "요청일" }
                                    , { "request_ryn", "구분" }
                                    };

        public AdminRequestManagement(Form parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
            comboBoxinit();
            updateRequestView();
            deleteRequestView();
        }

        public AdminRequestManagement()
        {
            InitializeComponent();
        }

        public void deleteRequestView()
        {
            view("DELETE", dataGridView2, "");
        }

        public void updateRequestView()
        {
            view("UPDATE", dataGridView1, "");
        }

        public void view(string request_division, DataGridView dataGridView, string requestRyn)
        {
            DataGridViewButtonColumn buttonColumn = null;
            List<Request> re = new List<Request>();

            // 요청구분 가공
            if (requestRyn.Equals("요청"))
            {
                requestRyn = "~중이다";
            }
            else if (requestRyn.Equals("승인"))
            {
                requestRyn = "그러하다";
            }
            else if (requestRyn.Equals("거절"))
            {
                requestRyn = "그러하지 않다";
            }
            else
            {
                requestRyn = "";
            }
            string requestRyn_name = Common.getGroupDetailNo(requestRyn);

            using (OracleConnection conn = new OracleConnection(DBINFO.strConnection))
            {
                conn.Open();
                string sql = "SELECT request_no" +
                             "     , request_division" +
                             "     , request_content" +
                             "     , request_date" +
                             "     , reason" +
                             "     , request_ryn" +
                             "     , id" +
                             "     , r.word_no" +
                             "     , word " +
                              "FROM request r JOIN word w " +
                                "ON r.word_no = w.word_no " +
                             "WHERE process_division LIKE '%' || :request_division || '%' " +
                             "  AND request_ryn LIKE '%' || :requestRyn || '%' " +
                             "ORDER BY 1 DESC";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(":request_division", request_division.ToUpper());
                    cmd.Parameters.Add(":requestRyn", requestRyn_name);

                    for (int i = 0; i < request_columns.GetLength(0); i++)
                    {
                        dataGridView.Columns.Add(request_columns[i, 0], request_columns[i, 1]);
                    }

                    using (OracleDataReader rdr = cmd.ExecuteReader())
                    {
                        string code;
                        while (rdr.Read())
                        {
                            Request request = new Request();
                            request.request_no = rdr["request_no"].ToString();

                            code = rdr["request_division"].ToString();
                            request.request_division = Common.getGroupDetailName(code);

                            code = rdr["request_ryn"].ToString();
                            request.request_ryn = Common.getGroupDetailName(code);

                            request.word_no = rdr["word_no"].ToString();
                            request.word = rdr["word"].ToString();
                            request.id = rdr["id"].ToString();
                            request.request_content = rdr["request_content"].ToString();
                            request.request_date = rdr["request_date"].ToString();

                            re.Add(request);
                        }
                    }
                }

                // DataGridView에 버튼 열 추가
                buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Name = "button";
                buttonColumn.HeaderText = "처리상태"; // 열의 헤더 텍스트 설정
                dataGridView.Columns.Add(buttonColumn);

                foreach (Request nvo in re)
                {
                    int rowIndex = dataGridView.Rows.Add(nvo.request_no
                                                        , nvo.request_division
                                                        , nvo.word_no
                                                        , nvo.word
                                                        , nvo.id
                                                        , nvo.request_content
                                                        , nvo.request_date
                                                        , nvo.request_ryn);

                    if (!nvo.request_ryn.Equals("요청"))
                    {
                        dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        dataGridView.Rows[rowIndex].Cells["button"].ReadOnly = true;
                        dataGridView.Rows[rowIndex].Cells["button"].Value = "처리완료"; // 버튼 셀에 값을 설정
                    }
                    else
                    {
                        dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(224, 244, 255);
                        dataGridView.Rows[rowIndex].Cells["button"].Value = "바로가기"; // 버튼 셀에 값을 설정
                    }
                }
            }
        }

        private void comboBoxinit()
        {
            // 처리구분
            comboBox_processDivision.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_processDivision.BackColor = Color.White;
            comboBox_processDivision.Items.Add("전체");
            comboBox_processDivision.Items.Add("수정");
            comboBox_processDivision.Items.Add("삭제");
            comboBox_processDivision.SelectedIndex = 0;

            // 요청상태
            comboBox_requestRyn.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_requestRyn.BackColor = Color.White;
            comboBox_requestRyn.Items.Add("전체");
            comboBox_requestRyn.Items.Add("요청");
            comboBox_requestRyn.Items.Add("승인");
            comboBox_requestRyn.Items.Add("거절");
            comboBox_requestRyn.SelectedIndex = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 클릭된 셀이 버튼 열인지 확인
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int rowIndex = e.RowIndex;  // 버튼이 클릭된 행 인덱스 가져오기
                string buttonValue = dataGridView1.Rows[rowIndex].Cells["button"].Value.ToString();
                string request_no = dataGridView1.Rows[rowIndex].Cells["request_no"].Value.ToString();

                if (!buttonValue.Equals("처리완료"))
                {
                    // 버튼이 클릭된 행에 대한 처리 수행
                    MessageBox.Show("수정 페이지로 이동합니다");
                    if (parentForm != null)
                    {
                        FormAdminUpdate updateForm = new FormAdminUpdate(request_no);
                        parentForm.Hide();
                        updateForm.Show();
                        updateForm.FormClosed += (s, args) =>
                        { // 수정 페이지가 닫힐 때 부모 폼을 다시 표시
                            parentForm.Show();

                            dataGridViewClear(dataGridView1);   // 해당 dataGridView의 행과 컬럼 값을 모두 삭제
                            view("UPDATE", dataGridView1, "");      // 초기화된 dataGridView에 SQL 결과를 전달
                        };
                    };
                }
                else
                {
                    dataGridView1.Rows[rowIndex].Cells["button"].ReadOnly = true;
                    dataGridView1.Rows[rowIndex].Cells["button"].Selected = false;
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 클릭된 셀이 버튼 열인지 확인
            if (e.ColumnIndex >= 0 && dataGridView2.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int rowIndex = e.RowIndex;  // 버튼이 클릭된 행 인덱스 가져오기
                string buttonValue = dataGridView2.Rows[rowIndex].Cells["button"].Value.ToString();           // button value
                string request_no = dataGridView2.Rows[rowIndex].Cells["request_no"].Value.ToString();  // request_no Text

                if (!buttonValue.Equals("처리완료"))
                {
                    // 버튼이 클릭된 행에 대한 처리 수행
                    MessageBox.Show("삭제 페이지로 이동합니다");
                    if (parentForm != null)
                    {
                        FormAdminDelete deleteForm = new FormAdminDelete(request_no);
                        parentForm.Hide();  // Form1 숨기고,
                        deleteForm.Show();  // DeleteForm 나와라.
                        deleteForm.FormClosed += (s, args) =>
                        { // 삭제 페이지가 닫힐 때 부모 폼을 다시 표시
                            parentForm.Show();

                            dataGridViewClear(dataGridView2);       // 해당 dataGridView의 행과 컬럼 값을 모두 삭제
                            view("DELETE", dataGridView2, "");      // 초기화된 dataGridView에 SQL 결과를 전달
                        };
                    }
                }
                else
                {
                    // 클릭된 버튼 비활성화
                    dataGridView2.Rows[rowIndex].Cells["button"].ReadOnly = true;
                    dataGridView2.Rows[rowIndex].Cells["button"].Selected = false;
                }
            }
        }

        private void dataGridViewClear(DataGridView dataGridView)
        // DataGridView의 행과 컬럼의 값을 모두 삭제
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
        }

        private void button_requestSearch_Click(object sender, EventArgs e)
        {
            string requestRyn = comboBox_requestRyn.SelectedItem.ToString();
            string proccessDivision = comboBox_processDivision.SelectedItem.ToString();

            // 수정, 전체면?
            if (requestRyn.Equals("전체") && proccessDivision.Equals("수정"))
            {
                dataGridViewClear(dataGridView1);
                view("UPDATE", dataGridView1, requestRyn);
                // 삭제, 전체면?
            }
            else if (requestRyn.Equals("전체") && proccessDivision.Equals("삭제"))
            {
                dataGridViewClear(dataGridView2);
                view("DELETE", dataGridView2, requestRyn);
                // 수정, 승인or거절or요청이면?
            }
            else if ((requestRyn.Equals("승인") || (requestRyn.Equals("거절")) || (requestRyn.Equals("요청"))) && proccessDivision.Equals("수정"))
            {
                dataGridViewClear(dataGridView1);
                view("UPDATE", dataGridView1, requestRyn);
                // 삭제, 승인or거절or요청이면?  
            }
            else if ((requestRyn.Equals("승인") || (requestRyn.Equals("거절")) || (requestRyn.Equals("요청"))) && proccessDivision.Equals("삭제"))
            {
                dataGridViewClear(dataGridView2);
                view("DELETE", dataGridView2, requestRyn);
            }
            // 위의 상황이 모두 아니라면?
            // (전체, 전체)
            else
            {
                dataGridViewClear(dataGridView1);
                view("UPDATE", dataGridView1, requestRyn);

                dataGridViewClear(dataGridView2);
                view("DELETE", dataGridView2, requestRyn);
            }
        }
    }
}
