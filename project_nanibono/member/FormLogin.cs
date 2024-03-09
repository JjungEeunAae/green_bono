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
        private void loginButton_Click(object sender, EventArgs e)
        {
            loginCheck();  
        }
        private void homeButton_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Hide();
        }

        private void pwTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                loginCheck();
            }
        }

        private void loginCheck()
        {
            string inputMemberId = idTextBox.Text.Trim();
            string inputMemberPw = pwTextBox.Text.Trim();

            if (string.IsNullOrEmpty(inputMemberId))
            {
                MessageBox.Show("아이디를 입력하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrEmpty(inputMemberPw))
            {
                MessageBox.Show("비밀번호를 입력하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MemberDB memberDB = new MemberDB();

            Member DBMemberId = memberDB.SelectId(inputMemberId);
            Member DBMemberPw = memberDB.SelectPw(inputMemberPw);

            if (DBMemberId == null)
            {
                MessageBox.Show("존재하지 않는 회원입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (DBMemberId.role == "ADMIN")
            {
                GlobalVariables.LoggedInUserId = DBMemberId.id;
                MessageBox.Show("로그인에 성공했습니다.");
                main.FormAdminMain formAdminMain = new main.FormAdminMain();
                formAdminMain.Show();
                this.Hide();
            }
            else if (DBMemberPw == null)
            {
                MessageBox.Show("비밀번호가 올바르지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (inputMemberId == DBMemberId.id && inputMemberPw == DBMemberPw.pw)
            {
                GlobalVariables.LoggedInUserId = DBMemberId.id;

                MessageBox.Show("로그인에 성공했습니다.");
                FormMain formMain = new FormMain();
                Hide();
                formMain.ShowDialog();
                Show();
            }
        }

        private void SignUpButton_Click_1(object sender, EventArgs e)
        {
            FormSignUp formSignUp = new FormSignUp();
            formSignUp.Show();
            this.Hide();
        }
    }
}
