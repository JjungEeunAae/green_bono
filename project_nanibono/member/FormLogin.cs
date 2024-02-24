using Oracle.ManagedDataAccess.Client;
using project_nanibono.member;

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
            Member member = memberDB.SelectMember(memberId, password);

            Member memberr = memberDB.SelectId(memberId);
            Member memberrr = memberDB.SelectPw(password);

            if (memberr == null)
            {

                MessageBox.Show("존재하지 않는 회원입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (memberrr == null)
            {
                MessageBox.Show("비밀번호가 올바르지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            // 로그인 성공  // ++++++++로그인유지시켜 

            GlobalVariables.LoggedInUserId = memberId;

            // WordSearch폼은 만들어지는중 
            // FormWordSearch formWordSearch = new FormWordSearch();
            //  formWordSearch.Show();


            this.Hide();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }





        private void SignUpButton_Click(object sender, EventArgs e)
        {
            // 회원가입 페이지로 이동

            //FormSignUp formSignUp = new FormSignUp();
            // formSignUp.Show();
            //this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 프로그램 종료
            Application.Exit();


        }

        private void pwTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void homeButton_Click(object sender, EventArgs e)
        {

            // FormWordSearch formWordSearch = new FormWordSearch();
            //formWordSearch.Show();

            // this.Hide();
        }
    }
}
