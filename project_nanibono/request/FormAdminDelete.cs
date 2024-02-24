using project_nanibono.common;

namespace project_nanibono.request
{
    public partial class FormAdminDelete : Form
    {
        private string request_no;

        public FormAdminDelete(string requestCode)
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
            List<TextBox> textBoxes = new List<TextBox>();

            textBoxes.Add(textBox_admin);
            textBoxes.Add(textBox_groupNo);
            textBoxes.Add(textBox_category);
            textBoxes.Add(textBox_wordMean);
            textBoxes.Add(textBox_id);
            textBoxes.Add(textBox_wordCode);
            textBoxes.Add(textBox_word);
            textBoxes.Add(textBox_requestContent);
            textBoxes.Add(textBox_date);

            Common.requestDetailRead("DELETE", requestCode, textBoxes);
        }

        private void comboBox_processDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox_processDivision.SelectedItem.ToString().Equals("N")) // 처리구분이 N이 아니면
            {
                requestForm(request_no);
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

                // 거절사유 라벨과 거절사유를 고를 수 있는 콤보박스를 컨트롤에서 지워버린다.
                Control[] foundControls = Controls.Find("label_deleteForm_reason", true);
                Control[] foundControls2 = Controls.Find("comboBox_reason", true);

                if (foundControls.Length > 0 && foundControls2.Length > 0)
                {
                    Label label_deleteForm_reason = (Label)foundControls[0];
                    Controls.Remove(label_deleteForm_reason);

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
                Controls.Add(label_deleteForm_reason);
                Controls.Add(comboBox_reason);
            }
        }

        private void successBtn_Click(object sender, EventArgs e)
        {
            string processDivision = comboBox_processDivision.Text;
            string groupDetailCode = Common.getGroupDetailNo(comboBox_reason.Text);

            bool frist = Common.requestUpdate(processDivision, groupDetailCode, request_no);

            if (frist)
            {
                Common.wordUpdate(processDivision, textBox_word.Text, textBox_wordMean.Text, textBox_wordCode.Text, this);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        // 닫기 버튼
        {
            this.Close();
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
            textBox_requestContent.ReadOnly = true;
            textBox_date.ReadOnly = true;

            textBox_admin.BackColor = Color.White;
            textBox_groupNo.BackColor = Color.White;
            textBox_category.BackColor = Color.White;
            textBox_id.BackColor = Color.White;
            textBox_wordCode.BackColor = Color.White;
            textBox_requestContent.BackColor = Color.White;
            textBox_date.BackColor = Color.White;

            textBox_word.BackColor = Color.White;
            textBox_wordMean.BackColor = Color.White;
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
    }
}
