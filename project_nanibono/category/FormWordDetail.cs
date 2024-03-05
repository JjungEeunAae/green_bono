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
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
