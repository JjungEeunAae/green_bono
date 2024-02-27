using project_nanibono.main;
using project_nanibono.word;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace project_nanibono
{
    public partial class FormMain : Form
    {
        //private WordSearch wordSearch = new WordSearch();
        public Button searchButton = null;

        mainDB db = new mainDB();

        public FormMain()
        {
            InitializeComponent();
            //wordSearchResult1.Visible = false;  // �ܾ�˻���� ����� ���� ��Ʈ�� �����

            //menuPanel.Visible = false;          // �޴��г� �����

            centerPanel.BringToFront();
            wordSearch1.Visible = true;
            wordSearch1.BringToFront();

            // �ܾ�˻� ����� ���� ��Ʈ��
            //Controls.Add(wordSearch);               // ��Ʈ�ѿ� ����

            //wordSearch.Visible = true;              // �ܾ�˻� ����� ���� ��Ʈ�� ���̰� �ϱ�
            //wordSearch.Location = new Point(0, 54); // ������ ��� �������ֱ�

            // �ܾ�˻� ����� ���� ��Ʈ�� ��ư Ŭ�� �̺�Ʈ
            //wordSearch.SearchButtonClicked += wordSearch1_SearchButtonClicked;

            searchButton = wordSearch1.getButton1();
            searchButton.Click += SearchButton_Click;

        }

        private void SearchButton_Click(object? sender, EventArgs e)
        {

            //OnSearchButtonClicked(EventArgs.Empty);
            /*formMain = new FormMain();
            formMain.ShowPanelAndControl2();*/
            // null�� ���� �� �����ϱ� null���� �ƴ��� ��Ȯ�ϰ� ����ȯ
            Dictionary<string, string> dictWord = db.selectWord(wordSearch1.getTextBox(), wordSearch1.getComboBox()) as Dictionary<string, string>;
            if (dictWord != null)
            {
                WordSearchResult sw = new WordSearchResult(dictWord);
                menuPanel.BringToFront();
                rightPanel.Controls.Add(sw);
                rightPanel.BringToFront();
                sw.BringToFront();
            };
        }

        public void ShowPanelAndControl2()
        {
            MessageBox.Show("�������");
            //wordSearch.Visible = false;       // ����� ���� ��Ʈ��1 ���̱�
            //menuPanel.Visible = true;         // �г� ���̱�
            //wordSearchResult1.Visible = true; // ����� ���� ��Ʈ��2 ���̱�
        }

        private void wordSearch1_SearchButtonClicked(object sender, EventArgs e)
        {
            //ShowPanelAndControl2(); // �˻� ��ư�� Ŭ���ϸ� �гΰ� ����� ���� ��Ʈ��2�� ������
        }

        private void searchTerm_Click(object sender, EventArgs e)
        {

            /*WordDB wordDB = new WordDB();
            Word result = wordDB.SelectWord(searchBox.Text);

            if (result != null) { 
                Hide();
                new FormResult(result).ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("�˻��Ǵ� ����� �����ϴ�.");
            }*/
            // + ����â ����� 


            // 1. �� database�� word Table �� word attribute�� ������ ���
            // 2. �������� ���� ���  

            //  FormResult�� label1�� �ش� word�� ��������
            //  FormResult�� label2�� word Table �� world_MEAN�� �����´�. 

            //         string searchTerm = searchBox.Text;
            //      if ((searchTerm)) // �� ������
            //       {
            //         Search(searchTerm);
            //       FormResult formResult = new FormResult();
            //     formResult.Show();
            //   this.Hide();
            //       }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void button_ct1_Click(object sender, EventArgs e)
        {

        }

        private void wordSearch1_Load(object sender, EventArgs e)
        {

        }
    }
}
