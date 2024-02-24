namespace project_nanibono
{
    partial class FormEdit
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
            label9 = new Label();
            label_requestContent = new Label();
            label_proccessDivision = new Label();
            label_wordName = new Label();
            label_wordCode = new Label();
            label_id = new Label();
            label_requestDate = new Label();
            textBox_requestContent = new TextBox();
            comboBox_proccessDivision = new ComboBox();
            panel1 = new Panel();
            closeBtn = new Button();
            successBtn = new Button();
            label8 = new Label();
            comboBox3 = new ComboBox();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("휴먼둥근헤드라인", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label9.Location = new Point(310, 9);
            label9.Name = "label9";
            label9.Size = new Size(184, 39);
            label9.TabIndex = 12;
            label9.Text = "편집 요청";
            // 
            // label_requestContent
            // 
            label_requestContent.AutoSize = true;
            label_requestContent.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            label_requestContent.Location = new Point(193, 259);
            label_requestContent.Name = "label_requestContent";
            label_requestContent.Size = new Size(55, 15);
            label_requestContent.TabIndex = 15;
            label_requestContent.Text = "요청내용";
            // 
            // label_proccessDivision
            // 
            label_proccessDivision.AutoSize = true;
            label_proccessDivision.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            label_proccessDivision.Location = new Point(193, 196);
            label_proccessDivision.Name = "label_proccessDivision";
            label_proccessDivision.Size = new Size(55, 15);
            label_proccessDivision.TabIndex = 16;
            label_proccessDivision.Text = "처리구분";
            // 
            // label_wordName
            // 
            label_wordName.AutoSize = true;
            label_wordName.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            label_wordName.Location = new Point(208, 155);
            label_wordName.Name = "label_wordName";
            label_wordName.Size = new Size(43, 15);
            label_wordName.TabIndex = 17;
            label_wordName.Text = "단어명";
            // 
            // label_wordCode
            // 
            label_wordCode.AutoSize = true;
            label_wordCode.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            label_wordCode.Location = new Point(196, 119);
            label_wordCode.Name = "label_wordCode";
            label_wordCode.Size = new Size(55, 15);
            label_wordCode.TabIndex = 18;
            label_wordCode.Text = "단어코드";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            label_id.Location = new Point(208, 80);
            label_id.Name = "label_id";
            label_id.Size = new Size(43, 15);
            label_id.TabIndex = 19;
            label_id.Text = "아이디";
            // 
            // label_requestDate
            // 
            label_requestDate.AutoSize = true;
            label_requestDate.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            label_requestDate.Location = new Point(208, 360);
            label_requestDate.Name = "label_requestDate";
            label_requestDate.Size = new Size(43, 15);
            label_requestDate.TabIndex = 20;
            label_requestDate.Text = "요청일";
            // 
            // textBox_requestContent
            // 
            textBox_requestContent.Location = new Point(260, 259);
            textBox_requestContent.Multiline = true;
            textBox_requestContent.Name = "textBox_requestContent";
            textBox_requestContent.Size = new Size(325, 84);
            textBox_requestContent.TabIndex = 25;
            // 
            // comboBox_proccessDivision
            // 
            comboBox_proccessDivision.FormattingEnabled = true;
            comboBox_proccessDivision.Location = new Point(260, 192);
            comboBox_proccessDivision.Name = "comboBox_proccessDivision";
            comboBox_proccessDivision.Size = new Size(325, 23);
            comboBox_proccessDivision.TabIndex = 27;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.bonoback;
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(630, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(170, 450);
            panel1.TabIndex = 168;
            // 
            // closeBtn
            // 
            closeBtn.BackColor = Color.FromArgb(135, 196, 255);
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold);
            closeBtn.ForeColor = Color.White;
            closeBtn.Location = new Point(407, 402);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(212, 38);
            closeBtn.TabIndex = 170;
            closeBtn.Text = "닫기";
            closeBtn.UseVisualStyleBackColor = false;
            // 
            // successBtn
            // 
            successBtn.BackColor = Color.FromArgb(135, 196, 255);
            successBtn.FlatAppearance.BorderSize = 0;
            successBtn.FlatStyle = FlatStyle.Flat;
            successBtn.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold);
            successBtn.ForeColor = Color.White;
            successBtn.Location = new Point(189, 402);
            successBtn.Name = "successBtn";
            successBtn.Size = new Size(212, 38);
            successBtn.TabIndex = 169;
            successBtn.Text = "요청완료";
            successBtn.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(224, 244, 255);
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.Location = new Point(198, 62);
            label8.Name = "label8";
            label8.Size = new Size(400, 2);
            label8.TabIndex = 171;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(260, 224);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(325, 23);
            comboBox3.TabIndex = 173;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            label14.Location = new Point(193, 228);
            label14.Name = "label14";
            label14.Size = new Size(55, 15);
            label14.TabIndex = 172;
            label14.Text = "요청구분";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(260, 80);
            label15.Name = "label15";
            label15.Size = new Size(46, 15);
            label15.TabIndex = 174;
            label15.Text = "label15";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(260, 119);
            label16.Name = "label16";
            label16.Size = new Size(46, 15);
            label16.TabIndex = 175;
            label16.Text = "label16";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(260, 155);
            label17.Name = "label17";
            label17.Size = new Size(46, 15);
            label17.TabIndex = 176;
            label17.Text = "label17";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(260, 360);
            label18.Name = "label18";
            label18.Size = new Size(46, 15);
            label18.TabIndex = 177;
            label18.Text = "label18";
            // 
            // panel2
            // 
            panel2.BackgroundImage = Properties.Resources.bonoback;
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(170, 450);
            panel2.TabIndex = 167;
            // 
            // FormEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(800, 450);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(comboBox3);
            Controls.Add(label14);
            Controls.Add(label8);
            Controls.Add(closeBtn);
            Controls.Add(successBtn);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(comboBox_proccessDivision);
            Controls.Add(textBox_requestContent);
            Controls.Add(label_requestDate);
            Controls.Add(label_requestContent);
            Controls.Add(label_proccessDivision);
            Controls.Add(label_wordName);
            Controls.Add(label_wordCode);
            Controls.Add(label_id);
            Controls.Add(label9);
            Name = "FormEdit";
            Text = "FormEdit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label9;
        private Label label_requestContent;
        private Label label_proccessDivision;
        private Label label_wordName;
        private Label label_wordCode;
        private Label label_id;
        private Label label_requestDate;
        private TextBox textBox_requestContent;
        private ComboBox comboBox_proccessDivision;
        private Panel panel1;
        private Button closeBtn;
        private Button successBtn;
        private Label label8;
        private ComboBox comboBox3;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Panel panel2;
    }
}