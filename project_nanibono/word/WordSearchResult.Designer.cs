﻿namespace project_nanibono.word
{
    partial class WordSearchResult
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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("휴먼둥근헤드라인", 21.75F);
            label1.ForeColor = Color.FromArgb(57, 167, 255);
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(129, 30);
            label1.TabIndex = 16;
            label1.Text = "검색결과";
            // 
            // WordSearchResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(label1);
            Name = "WordSearchResult";
            Size = new Size(651, 396);

            Load += WordSearchResult_Load;

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}
