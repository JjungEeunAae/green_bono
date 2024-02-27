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
        public event EventHandler SearchButtonClicked;
        //private FormMain formMain;
        mainDB db = new mainDB();

        public WordSearch()
        {
            InitializeComponent();
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            OnSearchButtonClicked(EventArgs.Empty);
            /*formMain = new FormMain();
            formMain.ShowPanelAndControl2();*/
        }

        protected virtual void OnSearchButtonClicked(EventArgs e)
        {
            SearchButtonClicked?.Invoke(this, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // null이 들어올 수 있으니깐 null인지 아닌지 정확하게 형변환
            if (db.selectWord(textBox1, comboBox1) != null)
            {
                Dictionary<string, string> dictWord = db.selectWord(textBox1, comboBox1) as Dictionary<string, string>;
                WordSearchResult sw = new WordSearchResult(dictWord);
                sw.Show();
            };
        }

        private void WordSearch_Load(object sender, EventArgs e)
        {
            db.selectComoBox(comboBox1);
        }
    }
}
