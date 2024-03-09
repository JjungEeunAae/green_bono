using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_nanibono.category
{
    public partial class FormWordDetail : Form
    {
        private string word;
        private string wordMean;
        
        public FormWordDetail(string word, string wordMean)
        {
            InitializeComponent();
            this.word = word;
            this.wordMean = wordMean;
        }
        private void FormWordDetail_Load(object sender, EventArgs e)
        {
            wordLabel.Text = word;
            wordMeanLabel.Text = wordMean;

            requestButton.Visible = !string.IsNullOrEmpty(GlobalVariables.LoggedInUserId);  // 로그인 되어있으면 버튼 보여주는 코드
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void requestButton_Click(object sender, EventArgs e) //편집요청 버튼
        {
                FormEdit formEdit = new FormEdit(wordLabel.Text);
                formEdit.Show();
                this.Hide();
        }
    }
}
