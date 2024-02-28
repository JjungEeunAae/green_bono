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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace project_nanibono.word
{
    public partial class WordSelect : UserControl

    {
        WordDB wordDB = new WordDB();

        public WordSelect(Form parentForm)
        {
            
            InitializeComponent();
           // DataTable dt = wordDB.SelectWord();
            //if (dt != null)
           // {
            //    C.DataSource = dt;
           // }
        }


        private void WordSelect_Load(object sender, EventArgs e)
        {
           
           
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
