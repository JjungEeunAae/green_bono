
using Microsoft.VisualBasic.ApplicationServices;
using Oracle.ManagedDataAccess.Client;
using project_nanibono.member;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace project_nanibono
{
    public partial class FormSignUp : Form
    {
        Member member = new Member();
        int idCheckResult = 0;
        public FormSignUp()
        {
            InitializeComponent();
        }

        private void FormSignUp_Load(object sender, EventArgs e) // 회원가입하는 창 보노보노 이미지
        {
            //pictureBox1.Image = Properties.Resources.bonoImg;
        }
        private bool checkId() // id 중복 체크
        {
            member.id = userId.Text;
            bool check = true;
            try
            {
                using (OracleConnection con = new OracleConnection(DBINFO.getConnection()))
                {
                    con.Open();

                    DBINFO.sql = "select id from member";
                    using (OracleCommand cmd = new OracleCommand(DBINFO.sql, con))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["id"].ToString() == member.id)
                                {
                                    check = false;
                                    break;
                                }
                            }
                        }
                    }

                    if (check == false)
                    {
                        MessageBox.Show("아이디 중복입니다.");
                    }
                    else if (check == true && !string.IsNullOrEmpty(userId.Text.Trim()))
                    {
                        MessageBox.Show("사용할 수 있는 아이디 입니다.");
                    }
                    else
                    {
                        MessageBox.Show("아이디를 입력하세요.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 : " + ex.Message.ToString());
            }

            return check;
        }
        private void button1_Click(object sender, EventArgs e) // 회원가입 시 아이디 중복체크
        {
            idCheckResult = checkId() ? 1 : 0;
        }
        private bool textBoxValuesCheck() // 아아디, 비밀번호, 이름 빈값 확인하는 메서드
        {
            if (string.IsNullOrEmpty(userId.Text.Trim()))
            {
                MessageBox.Show("아이디를 입력하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(userPassword.Text.Trim()))
            {
                MessageBox.Show("비밀번호를 입력하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(userName.Text.Trim()))
            {
                MessageBox.Show("이름을 입력하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void signUpButton_Click(object sender, EventArgs e)   // 중복체크에 따라 회원가입 버튼 누르는 메서드(빈값 확인후 로그인 구현)
        {
            if (idCheckResult == 1)
            {
                bool sucess = textBoxValuesCheck() ? true : false;
                if (sucess)
                {
                    signUp();
                }
            }
            else
            {
                MessageBox.Show("아이디 중복 체크 해주세요");
            }
        }
        private void signUp() // 회원가입 하는 db
        {
            try
            {
                using (OracleConnection con = new OracleConnection(DBINFO.getConnection()))
                {
                    con.Open();

                    DBINFO.sql = "insert into member(id, pw, name, role, resign) " +
                        "values(:id, :pw, :name, 'USER', 'N')";
                    using (OracleCommand cmd = new OracleCommand(DBINFO.sql, con))
                    {
                        cmd.Parameters.Add("id", userId.Text);
                        cmd.Parameters.Add("pw", userPassword.Text);
                        cmd.Parameters.Add("name", userName.Text);

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("환영합니다. " + userId.Text + " 님 회원가입 되었습니다.");

                            FormLogin formLogin = new FormLogin();
                            formLogin.Show();
                            this.Hide();
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1)
                {
                    MessageBox.Show("아이디가 이미 사용 중입니다. 다른 아이디를 선택하세요.");
                }
                else
                {
                    MessageBox.Show("오류 : " + ex.Message.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test" + ex.Message);
            }
        }
    }
}
