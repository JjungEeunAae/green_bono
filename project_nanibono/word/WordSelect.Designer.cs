namespace project_nanibono.word
{
    partial class WordSelect
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
            C = new DataGridView();
            category = new Label();
            ((System.ComponentModel.ISupportInitialize)C).BeginInit();
            SuspendLayout();
            // 
            // C
            // 
            C.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            C.Location = new Point(22, 121);
            C.Name = "C";
            C.Size = new Size(588, 263);
            C.TabIndex = 0;
            C.CellContentClick += dataGridView1_CellContentClick;
            // 
            // category
            // 
            category.AutoSize = true;
            category.Location = new Point(22, 45);
            category.Name = "category";
            category.Size = new Size(133, 15);
            category.TabIndex = 1;
            category.Text = "categoryM > categoryS";
            // 
            // WordSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(category);
            Controls.Add(C);
            Name = "WordSelect";
            Size = new Size(651, 396);
            Load += WordSelect_Load;
            ((System.ComponentModel.ISupportInitialize)C).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView C;
        private Label category;
    }
}
