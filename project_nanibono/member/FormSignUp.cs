
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

        private void FormSignUp_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image = Properties.Resources.bonoImg;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 회원가입 시 아이디 중복체크
            if (checkId() == true)   // 1 이면 중복 , 2 이면 중복 아니라서 아이디 사용가능
            {
                idCheckResult = 2;
            }
            else
            {
                idCheckResult = 1;
            }
        }
        private bool checkId() // 아이디 중복체크하는 메서드
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
        private void loginButton_Click(object sender, EventArgs e)
        {
            signUpCheck();
        }
        private string signUpCheck()
        {
            string result = "";
            Console.WriteLine(idCheckResult);
            // 회원가입 완료 후 로그인 페이지로 이동
            if (idCheckResult == 2)
            {
                if (string.IsNullOrEmpty(userId.Text.Trim()))
                {
                    MessageBox.Show("아이디를 입력하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(userPassword.Text.Trim()))
                {
                    MessageBox.Show("비밀번호를 입력하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(userName.Text.Trim()))
                {
                    MessageBox.Show("이름을 입력하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (checkId() == false)
                    {
                        MessageBox.Show("아이디 중복 체크 해주세요");
                    }
                    /*                    else
                                        {
                                            MessageBox.Show("회원가입에 성공했습니다!");
                                            FormLogin formLogin = new FormLogin();
                                            formLogin.Show();
                                            this.Hide();
                                        }*/
                }
            }
            else
            {
                MessageBox.Show("아이디 중복 체크 해주세요");
            }
            return result;
        }
    }
}
