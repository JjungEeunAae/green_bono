namespace project_nanibono.category
{
    partial class FormWordDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titleLabel = new Label();
            wordLabel = new Label();
            panel2 = new Panel();
            panel1 = new Panel();
            wordPanel = new Panel();
            wordMeanLabel = new Label();
            label8 = new Label();
            closeBtn = new Button();
            requestButton = new Button();
            wordPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("휴먼둥근헤드라인", 29F);
            titleLabel.ForeColor = Color.FromArgb(57, 167, 255);
            titleLabel.Location = new Point(259, 55);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(292, 41);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "단어 상세 조회";
            // 
            // wordLabel
            // 
            wordLabel.AutoSize = true;
            wordLabel.Font = new Font("맑은 고딕", 19F, FontStyle.Bold);
            wordLabel.ForeColor = Color.FromArgb(57, 167, 255);
            wordLabel.Location = new Point(202, 183);
            wordLabel.Name = "wordLabel";
            wordLabel.Size = new Size(67, 36);
            wordLabel.TabIndex = 2;
            wordLabel.Text = "단어";
            // 
            // panel2
            // 
            panel2.BackgroundImage = Properties.Resources.bonoback;
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(630, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(170, 450);
            panel2.TabIndex = 168;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.bonoback;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(170, 450);
            panel1.TabIndex = 169;
            // 
            // wordPanel
            // 
            wordPanel.AutoScroll = true;
            wordPanel.Controls.Add(wordMeanLabel);
            wordPanel.Location = new Point(202, 245);
            wordPanel.Name = "wordPanel";
            wordPanel.Size = new Size(400, 120);
            wordPanel.TabIndex = 170;
            // 
            // wordMeanLabel
            // 
            wordMeanLabel.AutoEllipsis = true;
            wordMeanLabel.Dock = DockStyle.Fill;
            wordMeanLabel.Font = new Font("맑은 고딕", 13F);
            wordMeanLabel.Location = new Point(0, 0);
            wordMeanLabel.Name = "wordMeanLabel";
            wordMeanLabel.Size = new Size(400, 120);
            wordMeanLabel.TabIndex = 0;
            wordMeanLabel.Text = "(단어뜻)";
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(224, 244, 255);
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.Location = new Point(202, 138);
            label8.Name = "label8";
            label8.Size = new Size(400, 2);
            label8.TabIndex = 171;
            // 
            // closeBtn
            // 
            closeBtn.BackColor = Color.FromArgb(135, 196, 255);
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold);
            closeBtn.ForeColor = Color.White;
            closeBtn.Location = new Point(526, 384);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(76, 36);
            closeBtn.TabIndex = 173;
            closeBtn.Text = "닫기";
            closeBtn.UseVisualStyleBackColor = false;
            closeBtn.Click += closeBtn_Click;
            // 
            // requestButton
            // 
            requestButton.BackColor = Color.FromArgb(135, 196, 255);
            requestButton.FlatAppearance.BorderSize = 0;
            requestButton.FlatStyle = FlatStyle.Flat;
            requestButton.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold);
            requestButton.ForeColor = Color.White;
            requestButton.Location = new Point(426, 384);
            requestButton.Name = "requestButton";
            requestButton.Size = new Size(81, 36);
            requestButton.TabIndex = 174;
            requestButton.Text = "편집요청";
            requestButton.UseVisualStyleBackColor = false;
            requestButton.Click += requestButton_Click;
            // 
            // FormWordDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(800, 450);
            Controls.Add(requestButton);
            Controls.Add(closeBtn);
            Controls.Add(label8);
            Controls.Add(wordPanel);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(wordLabel);
            Controls.Add(titleLabel);
            Name = "FormWordDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "7";
            Load += FormWordDetail_Load;
            wordPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label titleLabel;
        private Label wordLabel;
        private Panel panel2;
        private Panel panel1;
        private Panel wordPanel;
        private Label wordMeanLabel;
        private Label label8;
        private Button closeBtn;
        private Button requestButton;
    }
}