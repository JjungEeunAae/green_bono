using project_nanibono.request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace project_nanibono.word
{
    public partial class WordSearchResult : UserControl
    {
        string word = "";
        string wordMean = "";
        string id = GlobalVariables.LoggedInUserId;

        int panelY = 50; // �ʱ� Y ��ġ

        public WordSearchResult(){ }

        public WordSearchResult(Dictionary<string, string> dictWord)
        {
            InitializeComponent();

            foreach (var kvp in dictWord)
            {
                word = kvp.Key;
                wordMean = kvp.Value;

                Panel panel = new Panel();
                panel.Location = new Point(60, panelY);
                panel.Size = new Size(530, 150);
                panel.BackColor = Color.Transparent;
                Controls.Add(panel);
                if (!String.IsNullOrEmpty(id))
                {
                    Button button_requestEdit = new Button();
                    button_requestEdit.Name = "button_requestEdit";
                    button_requestEdit.Location = new Point(400, 95); // �г��� �ʺ� ���� ��ġ�ϵ��� X ��ǥ ����
                    button_requestEdit.Size = new Size(100, 30);
                    button_requestEdit.BackColor = Color.FromArgb(135, 196, 255);
                    button_requestEdit.FlatAppearance.BorderSize = 0;
                    button_requestEdit.FlatStyle = FlatStyle.Flat;
                    button_requestEdit.Font = new Font("���� ���", 9F, FontStyle.Bold);
                    button_requestEdit.ForeColor = Color.White;
                    button_requestEdit.Text = "������û";
                    button_requestEdit.UseVisualStyleBackColor = false;
                    button_requestEdit.Tag = new Request { word = word, wordMean = wordMean };
                    button_requestEdit.Click += Button_Click;

                    panel.Controls.Add(button_requestEdit);
                }
                Label label_word = new Label();
                label_word.Name = "label_word";
                label_word.Location = new Point(15, 30);
                label_word.Text = word;
                label_word.AutoSize = true;
                label_word.Font = new Font("���� ���", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
                label_word.ForeColor = Color.FromArgb(57, 167, 255);
                panel.Controls.Add(label_word);

                Label label2 = new Label();
                label2.AutoSize = false; 
                label2.Size = new Size(450, 100); 
                label2.ForeColor = Color.FromArgb(64, 64, 64);
                label2.Location = new Point(15, 70);
                label2.Text = wordMean;
                panel.Controls.Add(label2);

                // �г� ���� ����
                panelY += 130;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Request rqvo = (Request)btn.Tag;  // ��ư�� Tag �Ӽ��� �̿��Ͽ� ���� ��������

            Console.WriteLine("��ư " + rqvo.word);
            FormEdit rq = new FormEdit(rqvo.word);
            rq.Show();
        }
    }
}
