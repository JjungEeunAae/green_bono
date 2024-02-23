using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;
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

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }




        //       private void form3_load(object sender, eventargs e)
        //      {

        //    }


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


        //     private void idTextBox_TextChanged(object sender, EventArgs e)
        //   {

        // }
    }
}
