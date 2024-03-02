using project_nanibono.category;
using project_nanibono.main;
using project_nanibono.word;
using System.Data;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace project_nanibono
{
    public partial class FormMain : Form
    {
        //private WordSearch wordSearch = new WordSearch();
        public Button searchButton = null;

        mainDB db = new mainDB();
        CategoryDBManager manager = new CategoryDBManager();

        public FormMain()
        {
            InitializeComponent();

            //wordSearchResult1.Visible = false;  // 단어검색결과 사용자 정의 컨트롤 숨기기

            menuPanel.Visible = false;          // 메뉴패널 숨기기
            //panel1.BringToFront();

            //topPanel.Visible = true;
            //topPanel.BringToFront();

            centerPanel.Visible = true;
            centerPanel.BringToFront();
            wordSearch1.Visible = true;
            wordSearch1.BringToFront();

            searchButton = wordSearch1.getButton1();
            searchButton.Click += SearchButton_Click;
        }

        private void SearchButton_Click(object? sender, EventArgs e)
        {

            Dictionary<string, string> dictWord = db.selectWord(wordSearch1.getTextBox(), wordSearch1.getComboBox()) as Dictionary<string, string>;
            if (dictWord != null)
            {
                WordSearchResult sw = new WordSearchResult(dictWord);
                menuPanel.Visible = true;
                menuPanel.BringToFront();
                rightPanel.Visible = true;
                rightPanel.Controls.Add(sw);
                rightPanel.BringToFront();
                sw.BringToFront();
            };
        }

        private void button_ct1_Click(object sender, EventArgs e)
        {
            ct1select();
        }

        // elfButton
        private void button2_Click(object sender, EventArgs e)
        {
            menuPanel.Visible = true;
            rightPanel.Visible = true;
            menuPanel.BringToFront();
            rightPanel.BringToFront();
            wordSearch1.Visible = false;
            wordSearch1.SendToBack();

            ct1select();
        }

        private void sdButton_Click(object sender, EventArgs e)
        {
            menuPanel.Visible = true;
            rightPanel.Visible = true;
            menuPanel.BringToFront();
            rightPanel.BringToFront();
            wordSearch1.Visible = false;
            wordSearch1.SendToBack();

            ct2select();
        }


        public void selectCategory(DataTable dataTable)
        {
            rightPanel.Controls.Clear();

            DataGridView dgv = new DataGridView();
            dgv.BackgroundColor = Color.White;
            dgv.Dock = DockStyle.Fill;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;


            DataTable dt = dataTable;

            if (dt != null)
            {
                dgv.Columns.Clear();
                dgv.DataSource = null;
                dgv.AutoGenerateColumns = true;

                dgv.Columns.Add("word", "word");
                dgv.Columns.Add("word_mean", "word_mean");
                dgv.Columns.Add("insert_date", "insert_date");

                foreach (DataRow row in dt.Rows)
                {
                    dgv.Rows.Add(row["word"], row["word_mean"], row["insert_date"]);
                }
                dgv.Columns[0].Width = 30;
                dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns[2].Width = 30;
            }

            rightPanel.Controls.Add(dgv);
        }

        private void ct1select()
        {
            selectCategory(manager.SelectELF());
        }

        private void ct2select()
        {
            selectCategory(manager.SelectSD());
        }

        private void button_ct2_Click(object sender, EventArgs e)
        {
            selectCategory(manager.SelectSD());
        }


        private void elfButton1_Click(object sender, EventArgs e)
        {
            menuSwitchPanel.Location = new System.Drawing.Point(0, 47);
            selectCategory(manager.Select("CT1_CG1"));
        }

        private void elfButton2_Click(object sender, EventArgs e)
        {
            menuSwitchPanel.Location = new System.Drawing.Point(0, 75);
            selectCategory(manager.Select("CT1_CG2"));
        }

        private void elfButton3_Click(object sender, EventArgs e)
        {
            menuSwitchPanel.Location = new System.Drawing.Point(0, 105);
            selectCategory(manager.Select("CT1_CG3"));
        }

        private void elfButton4_Click(object sender, EventArgs e)
        {
            menuSwitchPanel.Location = new System.Drawing.Point(0, 132);
            selectCategory(manager.Select("CT1_CG4"));
        }

        private void elfButton5_Click(object sender, EventArgs e)
        {
            menuSwitchPanel.Location = new System.Drawing.Point(0, 160);
            selectCategory(manager.Select("CT1_CG5"));
        }
        private void sdButton1_Click(object sender, EventArgs e)
        {
            menuSwitchPanel.Location = new System.Drawing.Point(0, 200);
            selectCategory(manager.Select("CT2_CG1"));
        }

        private void sdButton2_Click(object sender, EventArgs e)
        {
            menuSwitchPanel.Location = new System.Drawing.Point(0, 230);
            selectCategory(manager.Select("CT2_CG2"));
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            menuPanel.Visible = false;
            rightPanel.Visible = false;
            /// menuPanel.BringToFront();
            // rightPanel.BringToFront();
            wordSearch1.Visible = true;
            wordSearch1.BringToFront();
        }

       
    }
}
