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
        public Button searchButton = null;
        private WordSearch wordSearch1 = null;

        mainDB db = new mainDB();
        CategoryDBManager manager = new CategoryDBManager();

        public FormMain()
        {
            InitializeComponent();

            wordSearch1 = new WordSearch(this);

            menuPanel.Visible = false;

            centerPanel.Visible = true;
            centerPanel.BringToFront();

            centerPanel.Controls.Add(wordSearch1);

            wordSearch1.Visible = true;
            wordSearch1.BringToFront();

            searchButton = wordSearch1.getButton1();
            searchButton.Click += SearchButton_Click;

            if (!string.IsNullOrEmpty(GlobalVariables.LoggedInUserId))
            {
                logoutButton.Visible = true;
            }
            else
            {
                logoutButton.Visible = false;
            }
        }
        private void SearchButton_Click(object? sender, EventArgs e)
        {
            serchResult();
            wordSearch1.getTextBox().Clear();
        }

        private void serchResult()
        {
            Dictionary<string, string> dictWord = db.selectWord(wordSearch1.getTextBox(), wordSearch1.getComboBox()) as Dictionary<string, string>;

            if (dictWord != null)
            {
                WordSearchResult sw = new WordSearchResult(dictWord);

                sw.Size = new Size(620, 390);
                sw.AutoScroll = true;
                sw.VerticalScroll.Enabled = true;
                sw.HorizontalScroll.Enabled = false;

                menuPanel.Visible = true;
                menuPanel.BringToFront();

                rightPanel.Size = new Size(620, 390);
                rightPanel.AutoScroll = false;
                rightPanel.HorizontalScroll.Enabled = false;

                rightPanel.Visible = true;
                rightPanel.Controls.Add(sw);

                rightPanel.BringToFront();
                sw.BringToFront();
            }
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

                dgv.CellClick += (sender, e) =>
                {
                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];
                        string word = selectedRow.Cells["word"].Value.ToString();
                        string wordMean = selectedRow.Cells["word_mean"].Value.ToString();

                        FormWordDetail formWordDetail = new FormWordDetail(word, wordMean);
                        formWordDetail.Show();
                    }
                };
            }
            rightPanel.Controls.Add(dgv);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menuPanel.Visible = true;
            rightPanel.Visible = true;

            menuPanel.BringToFront();
            rightPanel.BringToFront();

            wordSearch1.Visible = false;
            wordSearch1.SendToBack();

            selectCategory(manager.Select("CT1%"));
        }

        // 상단 패널 버튼
        private void sdButton_Click(object sender, EventArgs e)
        {
            menuPanel.Visible = true;
            rightPanel.Visible = true;

            menuPanel.BringToFront();
            rightPanel.BringToFront();

            wordSearch1.Visible = false;
            wordSearch1.SendToBack();

            selectCategory(manager.Select("CT2%"));
        }

        // 좌측 메뉴 패널 버튼
        private void button_ct1_Click(object sender, EventArgs e)
        {
            selectCategory(manager.Select("CT1%"));
        }

        private void button_ct2_Click(object sender, EventArgs e)
        {
            selectCategory(manager.Select("CT2%"));
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
            menuSwitchPanel.Location = new System.Drawing.Point(0, 162);
            selectCategory(manager.Select("CT1_CG5"));
        }

        private void sdButton1_Click(object sender, EventArgs e)
        {
            menuSwitchPanel.Location = new System.Drawing.Point(0, 231);
            selectCategory(manager.Select("CT2_CG1"));
        }
        private void sdButton2_Click(object sender, EventArgs e)
        {
            menuSwitchPanel.Location = new System.Drawing.Point(0, 259);
            selectCategory(manager.Select("CT2_CG2"));
        }
        private void homeButton_Click(object sender, EventArgs e)
        {
          if (String.IsNullOrEmpty(GlobalVariables.LoggedInUserId))
          {
            logoutButton.Visible = false;
            wordSearch1.getLoginButton().Visible = true;
          }
          else
         {
          logoutButton.Visible = true;
          wordSearch1.getLoginButton().Visible = false;
         }

         menuPanel.Visible = false;
         rightPanel.Visible = false;
         wordSearch1.Visible = true;
         wordSearch1.BringToFront();
        }
     public void logoutButton_Click(object sender, EventArgs e)
     {
       MessageBox.Show("로그아웃에 성공했습니다.");

       GlobalVariables.LoggedInUserId = null;

       Console.WriteLine("id = " + GlobalVariables.LoggedInUserId);
       logoutButton.Visible = false;

       FormMain formMain = new FormMain();  
       formMain.Show();
      }
   }
}
