﻿namespace project_nanibono.word
{
    partial class AdminWordManagement
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            worddataGridView1 = new DataGridView();
            button_wordInsert = new Button();
            ((System.ComponentModel.ISupportInitialize)worddataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("휴먼둥근헤드라인", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label1.ForeColor = Color.FromArgb(57, 167, 255);
            label1.Location = new Point(-1, 8);
            label1.Name = "label1";
            label1.Size = new Size(120, 28);
            label1.TabIndex = 11;
            label1.Text = "단어관리";
            // 
            // worddataGridView1
            // 
            worddataGridView1.AllowUserToAddRows = false;
            worddataGridView1.AllowUserToDeleteRows = false;
            worddataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            worddataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            worddataGridView1.BorderStyle = BorderStyle.Fixed3D;
            worddataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            worddataGridView1.GridColor = SystemColors.ActiveBorder;
            worddataGridView1.Location = new Point(3, 80);
            worddataGridView1.Name = "worddataGridView1";
            worddataGridView1.ReadOnly = true;
            worddataGridView1.RightToLeft = RightToLeft.No;
            worddataGridView1.Size = new Size(649, 309);
            worddataGridView1.TabIndex = 12;
            // 
            // button_wordInsert
            // 
            button_wordInsert.BackColor = Color.FromArgb(135, 196, 255);
            button_wordInsert.FlatAppearance.BorderSize = 0;
            button_wordInsert.FlatStyle = FlatStyle.Flat;
            button_wordInsert.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_wordInsert.ForeColor = Color.White;
            button_wordInsert.Location = new Point(577, 397);
            button_wordInsert.Name = "button_wordInsert";
            button_wordInsert.Size = new Size(75, 23);
            button_wordInsert.TabIndex = 19;
            button_wordInsert.Text = "등록";
            button_wordInsert.UseVisualStyleBackColor = false;
            button_wordInsert.Click += button_wordInsert_Click;
            // 
            // AdminWordManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(button_wordInsert);
            Controls.Add(worddataGridView1);
            Controls.Add(label1);
            Name = "AdminWordManagement";
            Size = new Size(655, 450);
            ((System.ComponentModel.ISupportInitialize)worddataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView worddataGridView1;
        private Button button_wordInsert;
    }
}
