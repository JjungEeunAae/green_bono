using project_nanibono.main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_nanibono.word
{
    public partial class Search : Form
    {
        private WordSearch wordSearch = new WordSearch();
        mainDB db = new mainDB();
        string word; // 단어
        string wordMean; // 단어 뜻
        int panelY = 100; // 초기 Y 위치
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            db.selectComoBox(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // null이 들어올 수 있으니깐 null인지 아닌지 정확하게 형변환
            if (db.selectWord(textBox1, comboBox1) != null)
            {
                Dictionary<string, string> dictWord = db.selectWord(textBox1, comboBox1) as Dictionary<string, string>;
                WordSearchResult sw = new WordSearchResult(dictWord);
                sw.Show();
            };
        }
    }
}
