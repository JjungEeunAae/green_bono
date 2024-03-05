using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace project_nanibono
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuPanel = new Panel();
            menuSwitchPanel = new Panel();
            button_ct2 = new Button();
            button_ct1 = new Button();
            logoutButton = new Button();
            sdButton2 = new Button();
            sdButton1 = new Button();
            elfButton5 = new Button();
            elfButton4 = new Button();
            elfButton3 = new Button();
            elfButton2 = new Button();
            elfButton1 = new Button();
            topPanel = new Panel();
            elfButton = new Button();
            notifButton = new Button();
            sdButton = new Button();
            homeButton = new Button();
            centerPanel = new Panel();
            rightPanel = new Panel();
            menuPanel.SuspendLayout();
            topPanel.SuspendLayout();
            centerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuPanel
            // 
            menuPanel.BackColor = Color.FromArgb(224, 244, 255);
            menuPanel.Controls.Add(menuSwitchPanel);
            menuPanel.Controls.Add(button_ct2);
            menuPanel.Controls.Add(button_ct1);
            menuPanel.Controls.Add(logoutButton);
            menuPanel.Controls.Add(sdButton2);
            menuPanel.Controls.Add(sdButton1);
            menuPanel.Controls.Add(elfButton5);
            menuPanel.Controls.Add(elfButton4);
            menuPanel.Controls.Add(elfButton3);
            menuPanel.Controls.Add(elfButton2);
            menuPanel.Controls.Add(elfButton1);
            menuPanel.Location = new Point(0, 54);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(158, 396);
            menuPanel.TabIndex = 13;
            // 
            // menuSwitchPanel
            // 
            menuSwitchPanel.BackColor = Color.FromArgb(57, 167, 255);
            menuSwitchPanel.Location = new Point(0, 46);
            menuSwitchPanel.Name = "menuSwitchPanel";
            menuSwitchPanel.Size = new Size(10, 23);
            menuSwitchPanel.TabIndex = 11;
            // 
            // button_ct2
            // 
            button_ct2.BackColor = Color.Transparent;
            button_ct2.FlatAppearance.BorderSize = 0;
            button_ct2.FlatStyle = FlatStyle.Flat;
            button_ct2.Font = new Font("휴먼둥근헤드라인", 12F);
            button_ct2.ForeColor = Color.FromArgb(57, 167, 255);
            button_ct2.Location = new Point(3, 193);
            button_ct2.Name = "button_ct2";
            button_ct2.Size = new Size(145, 36);
            button_ct2.TabIndex = 16;
            button_ct2.Text = "SQLD";
            button_ct2.TextAlign = ContentAlignment.MiddleLeft;
            button_ct2.UseVisualStyleBackColor = false;
            button_ct2.Click += button_ct2_Click;
            // 
            // button_ct1
            // 
            button_ct1.BackColor = Color.Transparent;
            button_ct1.FlatAppearance.BorderSize = 0;
            button_ct1.FlatStyle = FlatStyle.Flat;
            button_ct1.Font = new Font("휴먼둥근헤드라인", 12F);
            button_ct1.ForeColor = Color.FromArgb(57, 167, 255);
            button_ct1.Location = new Point(0, 6);
            button_ct1.Name = "button_ct1";
            button_ct1.Size = new Size(148, 36);
            button_ct1.TabIndex = 11;
            button_ct1.Text = "정보처리기사";
            button_ct1.TextAlign = ContentAlignment.MiddleLeft;
            button_ct1.UseVisualStyleBackColor = false;
            button_ct1.Click += button_ct1_Click;
            // 
            // logoutButton
            // 
            logoutButton.FlatAppearance.BorderSize = 0;
            logoutButton.FlatStyle = FlatStyle.Flat;
            logoutButton.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            logoutButton.ForeColor = Color.Gray;
            logoutButton.Location = new Point(3, 370);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(64, 23);
            logoutButton.TabIndex = 15;
            logoutButton.Text = "로그아웃";
            logoutButton.TextAlign = ContentAlignment.BottomLeft;
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // sdButton2
            // 
            sdButton2.FlatAppearance.BorderSize = 0;
            sdButton2.FlatStyle = FlatStyle.Flat;
            sdButton2.Location = new Point(15, 259);
            sdButton2.Name = "sdButton2";
            sdButton2.Size = new Size(130, 23);
            sdButton2.TabIndex = 14;
            sdButton2.Text = "SQL 기본 및 활용";
            sdButton2.TextAlign = ContentAlignment.MiddleLeft;
            sdButton2.UseVisualStyleBackColor = true;
            sdButton2.Click += sdButton2_Click;
            // 
            // sdButton1
            // 
            sdButton1.FlatAppearance.BorderSize = 0;
            sdButton1.FlatStyle = FlatStyle.Flat;
            sdButton1.Location = new Point(15, 230);
            sdButton1.Name = "sdButton1";
            sdButton1.Size = new Size(130, 23);
            sdButton1.TabIndex = 13;
            sdButton1.Text = "데이터모델링의 이해";
            sdButton1.TextAlign = ContentAlignment.MiddleLeft;
            sdButton1.UseVisualStyleBackColor = true;
            sdButton1.Click += sdButton1_Click;
            // 
            // elfButton5
            // 
            elfButton5.FlatAppearance.BorderSize = 0;
            elfButton5.FlatStyle = FlatStyle.Flat;
            elfButton5.Location = new Point(12, 162);
            elfButton5.Name = "elfButton5";
            elfButton5.Size = new Size(133, 23);
            elfButton5.TabIndex = 12;
            elfButton5.Text = "정보시스템 구축관리";
            elfButton5.TextAlign = ContentAlignment.MiddleLeft;
            elfButton5.UseVisualStyleBackColor = true;
            elfButton5.Click += elfButton5_Click;
            // 
            // elfButton4
            // 
            elfButton4.FlatAppearance.BorderSize = 0;
            elfButton4.FlatStyle = FlatStyle.Flat;
            elfButton4.Location = new Point(12, 133);
            elfButton4.Name = "elfButton4";
            elfButton4.Size = new Size(133, 23);
            elfButton4.TabIndex = 11;
            elfButton4.Text = "프로그래밍 언어활용";
            elfButton4.TextAlign = ContentAlignment.MiddleLeft;
            elfButton4.UseVisualStyleBackColor = true;
            elfButton4.Click += elfButton4_Click;
            // 
            // elfButton3
            // 
            elfButton3.FlatAppearance.BorderSize = 0;
            elfButton3.FlatStyle = FlatStyle.Flat;
            elfButton3.Location = new Point(12, 104);
            elfButton3.Name = "elfButton3";
            elfButton3.Size = new Size(133, 23);
            elfButton3.TabIndex = 10;
            elfButton3.Text = "데이터베이스 구축";
            elfButton3.TextAlign = ContentAlignment.MiddleLeft;
            elfButton3.UseVisualStyleBackColor = true;
            elfButton3.Click += elfButton3_Click;
            // 
            // elfButton2
            // 
            elfButton2.FlatAppearance.BorderSize = 0;
            elfButton2.FlatStyle = FlatStyle.Flat;
            elfButton2.Location = new Point(12, 75);
            elfButton2.Name = "elfButton2";
            elfButton2.Size = new Size(133, 23);
            elfButton2.TabIndex = 9;
            elfButton2.Text = "소프트웨어 개발";
            elfButton2.TextAlign = ContentAlignment.MiddleLeft;
            elfButton2.UseVisualStyleBackColor = true;
            elfButton2.Click += elfButton2_Click;
            // 
            // elfButton1
            // 
            elfButton1.FlatAppearance.BorderSize = 0;
            elfButton1.FlatStyle = FlatStyle.Flat;
            elfButton1.ForeColor = SystemColors.ActiveCaptionText;
            elfButton1.Location = new Point(12, 46);
            elfButton1.Name = "elfButton1";
            elfButton1.Size = new Size(133, 23);
            elfButton1.TabIndex = 8;
            elfButton1.Text = "소프트웨어 설계";
            elfButton1.TextAlign = ContentAlignment.MiddleLeft;
            elfButton1.UseVisualStyleBackColor = true;
            elfButton1.Click += elfButton1_Click;
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(135, 196, 255);
            topPanel.Controls.Add(elfButton);
            topPanel.Controls.Add(notifButton);
            topPanel.Controls.Add(sdButton);
            topPanel.Controls.Add(homeButton);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(799, 54);
            topPanel.TabIndex = 12;
            // 
            // elfButton
            // 
            elfButton.BackColor = Color.Transparent;
            elfButton.FlatAppearance.BorderSize = 0;
            elfButton.FlatStyle = FlatStyle.Flat;
            elfButton.Font = new Font("휴먼둥근헤드라인", 12F);
            elfButton.ForeColor = Color.White;
            elfButton.Location = new Point(149, 0);
            elfButton.Name = "elfButton";
            elfButton.Size = new Size(139, 52);
            elfButton.TabIndex = 5;
            elfButton.Text = "정보처리기사";
            elfButton.UseVisualStyleBackColor = false;
            elfButton.Click += button2_Click;
            // 
            // notifButton
            // 
            notifButton.BackgroundImage = Properties.Resources.free_icon_notification_bell_6595746;
            notifButton.BackgroundImageLayout = ImageLayout.Stretch;
            notifButton.FlatAppearance.BorderSize = 0;
            notifButton.FlatStyle = FlatStyle.Flat;
            notifButton.Location = new Point(764, 11);
            notifButton.Name = "notifButton";
            notifButton.Size = new Size(26, 30);
            notifButton.TabIndex = 4;
            notifButton.UseVisualStyleBackColor = true;
            // 
            // sdButton
            // 
            sdButton.BackColor = Color.Transparent;
            sdButton.FlatAppearance.BorderSize = 0;
            sdButton.FlatStyle = FlatStyle.Flat;
            sdButton.Font = new Font("휴먼둥근헤드라인", 12F);
            sdButton.ForeColor = Color.White;
            sdButton.Location = new Point(294, -1);
            sdButton.Name = "sdButton";
            sdButton.Size = new Size(139, 52);
            sdButton.TabIndex = 2;
            sdButton.Text = "SQLD";
            sdButton.UseVisualStyleBackColor = false;
            sdButton.Click += sdButton_Click;
            // 
            // homeButton
            // 
            homeButton.BackColor = Color.Transparent;
            homeButton.FlatAppearance.BorderSize = 0;
            homeButton.FlatStyle = FlatStyle.Flat;
            homeButton.ForeColor = SystemColors.ControlText;
            homeButton.Image = Properties.Resources.bnonono_smll_smll;
            homeButton.Location = new Point(0, 0);
            homeButton.Name = "homeButton";
            homeButton.Size = new Size(148, 54);
            homeButton.TabIndex = 1;
            homeButton.UseVisualStyleBackColor = false;
            homeButton.Click += homeButton_Click;
            // 
            // centerPanel
            // 
            centerPanel.Controls.Add(rightPanel);
            centerPanel.Location = new Point(0, 54);
            centerPanel.Name = "centerPanel";
            centerPanel.Size = new Size(799, 396);
            centerPanel.TabIndex = 14;
            // 
            // rightPanel
            // 
            rightPanel.Location = new Point(164, 4);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(632, 390);
            rightPanel.TabIndex = 15;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(799, 450);
            Controls.Add(menuPanel);
            Controls.Add(centerPanel);
            Controls.Add(topPanel);
            Name = "FormMain";
            Text = "Form1";
            menuPanel.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            centerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel menuPanel;
        private Panel menuSwitchPanel;
        private Button button_ct2;
        private Button button_ct1;
        private Button logoutButton;
        private Button sdButton2;
        private Button sdButton1;
        private Button elfButton5;
        private Button elfButton4;
        private Button elfButton3;
        private Button elfButton2;
        private Button elfButton1;
        private Panel topPanel;
        private Button elfButton;
        private Button notifButton;
        private Button sdButton;
        private Button homeButton;
        private word.WordSearchResult wordSearchResult1;
        private Panel centerPanel;
        private word.WordSearch wordSearch1;
        private Panel rightPanel;
    }
}
