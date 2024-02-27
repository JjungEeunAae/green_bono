using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_nanibono.word
{
    public partial class WordSelect : UserControl

    {

        private Form parentForm;

        string[,] word_columms =
        { {"WORD","단어"} , {"WORD_MEAN", "정의"}
        };

        public WordSelect(Form parentForm)
        {
            this.parentForm = parentForm;   
            InitializeComponent();
        }


        private void WordSelect_Load(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(DBINFO.strConnection))
            {
                conn.Open();
                string sql = "SELECT word" +
                            "     , word_mean" +
                             "FROM word" +       
                            "ORDER BY 1 DESC";
            }
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
