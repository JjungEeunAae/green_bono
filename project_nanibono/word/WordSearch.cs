using project_nanibono.main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_nanibono.word
{
    public partial class WordSearch : UserControl
    {
        // Form 객체 초기화
        private Form parentForm;

        public event EventHandler SearchButtonClicked;
        mainDB db = new mainDB();

        public WordSearch()
        {

        }
        public WordSearch(Form parentForm)
        {
            // 초기화된 객체에 매개변수에 담기는 MainForm 그 자체를 집어넣음
            this.parentForm = parentForm;

            InitializeComponent();

            if (!string.IsNullOrEmpty(GlobalVariables.LoggedInUserId))
            {
                // 사용자가 로그인한 상태
                // 버튼을 숨김
                button2.Visible = false;
            }
            else
            {
                // 사용자가 로그인하지 않은 상태
                // 버튼을 보이게 함
                button2.Visible = true;
            }
        }


        public Button getButton1()
        {
            return button1;
        }

        public TextBox getTextBox()
        {
            return textBox1;
        }

        public ComboBox getComboBox()
        {
            return comboBox1;
        }
        //private void searchButton_Click(object sender, EventArgs e)
        //{
        //    // null이 들어올 수 있으니깐 null인지 아닌지 정확하게 형변환
        //    Dictionary<string, string> dictWord = db.selectWord(textBox1, comboBox1) as Dictionary<string, string>;
        //    if (dictWord != null)
        //    {
        //        WordSearchResult sw = new WordSearchResult(dictWord);
        //        this.Controls.Add(sw);
        //        sw.BringToFront();
        //    };
        //}

        protected virtual void OnSearchButtonClicked(EventArgs e)
        {
            //SearchButtonClicked?.Invoke(this, e);
        }


        private void WordSearch_Load(object sender, EventArgs e)
        {
            db.selectComoBox(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // FormLogin 객체 선언
            FormLogin formLogin = new FormLogin();

            parentForm.Hide();  // WordSearch를 품은 FormMain을 숨기고,
            formLogin.Show();   // FormLogin 나와라.

            // FormMain이 있으면,
            if (parentForm != null)
            {
                // formLogin을 닫을 때 마다
                formLogin.FormClosed += (s, args) =>
                {
                    // MainForm을 띄운다.
                    parentForm.Show();
                };

            }

        }
    }
}
