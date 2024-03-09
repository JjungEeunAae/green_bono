using project_nanibono.request;

namespace project_nanibono
{
    public partial class FormEdit : Form
    {
        RequestDB db = new RequestDB();
        public FormEdit(string word)
        {
            InitializeComponent();

            // 아이디랑 단어코드 가져와야한다
            // 여기서 다 조회한다.
            Console.WriteLine(word);
            db.select(label15, label16, label17, label18, comboBox_proccessDivision, comboBox3, word);

        }

        private void successBtn_Click(object sender, EventArgs e)
        {
            // 데이터들이 insert된다.
            // 아이디 - labe9, 단어코드 - label10, 단어명 - label11, 처리구분 - comboBox1
            // , 요청구분 - comboBox2, 요청내용 - textBox1
            db.insert(label15, label16, comboBox_proccessDivision, comboBox3, textBox_requestContent);
            this.Close();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_proccessDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox_proccessDivision.SelectedItem.ToString().Equals("수정")) // 처리구분이 수정이 아니라면
            {
                Control[] foundControls = Controls.Find("label14", true);
                Control[] foundControls2 = Controls.Find("comboBox3", true);

                if (foundControls.Length > 0 && foundControls2.Length > 0)
                {
                    Label label14 = (Label)foundControls[0];
                    Controls.Remove(label14);

                    ComboBox comboBox3 = (ComboBox)foundControls2[0];
                    Controls.Remove(comboBox3);
                }
            }
            else
            {
                Controls.Add(label14);
                Controls.Add(comboBox3);
            }
        }
    }
}
