using Oracle.ManagedDataAccess.Client;
using project_nanibono.member;
using project_nanibono.word;

namespace project_nanibono
{
    public partial class FormLogin : Form
    {

        string strConnection = "DATA SOURCE = 192.168.0.110; User Id = bono; Password=bono";

        OracleConnection conn;
        OracleCommand cmd;

        

        public FormLogin()
        {
            InitializeComponent();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string memberId = idTextBox.Text.Trim();
            string password = pwTextBox.Text.Trim();

            if (string.IsNullOrEmpty(memberId))
            {
                MessageBox.Show("아이디를 입력하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("비밀번호를 입력하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MemberDB memberDB = new MemberDB();

            Member member_id = memberDB.SelectId(memberId);
            Member member_pw = memberDB.SelectPw(password);

            if (member_id == null)
            {

                MessageBox.Show("존재하지 않는 회원입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (member_id.role == "admin")
            {
                GlobalVariables.LoggedInUserId = memberId;

                main.FormAdminMain formAdminMain = new main.FormAdminMain();
                formAdminMain.Show();
                this.Hide();
            }


            else if (member_pw == null)
            {
                MessageBox.Show("비밀번호가 올바르지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }           
            else
            {
                // 로그인 정보 저장
                GlobalVariables.LoggedInUserId = memberId;

                word.FormSearch formSearch = new word.FormSearch();
                formSearch.Show();

                this.Hide();
            }

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }





        private void SignUpButton_Click(object sender, EventArgs e)
        {
            // 회원가입 페이지로 이동

            FormSignUp formSignUp = new FormSignUp();
            formSignUp.Show();
            this.Hide();
        }



        private void pwTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void homeButton_Click(object sender, EventArgs e)
        {

            word.FormSearch formSearch = new word.FormSearch();
            formSearch.Show();
            this.Hide();
        }

    }
}
