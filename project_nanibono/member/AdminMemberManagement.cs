using Oracle.ManagedDataAccess.Client;
using project_nanibono.member;

namespace project_nanibono.request
{
    public partial class AdminMemberManagement : UserControl
    {
        public AdminMemberManagement()
        {
            InitializeComponent();
            LoadMembers();
            comboxBox_init();
        }

        private void comboxBox_init()
        {
            comboBox_search.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_search.Items.Add("선택해주세요");
            comboBox_search.Items.Add("아이디");
            comboBox_search.Items.Add("이름");
            comboBox_search.SelectedIndex = 0;
        }

        private void LoadMembers()
        {
            string[,] member_columns = { { "rn", "no" }, { "id", "아이디" }, { "pw", "패스워드" }, { "name", "이름" }, { "role", "권한" }, { "resign", "탈퇴여부" } };
            for (int i = 0; i < member_columns.GetLength(0); i++)
            {
                dataGridView1.Columns.Add(member_columns[i, 0], member_columns[i, 1]);
            }
            List<Member> member = new List<Member>();

            DBINFO.conn.Open();
            string sql = "SELECT ROWNUM, id, pw, name, role, resign FROM member ORDER BY 1";
            DBINFO.cmd_eunae = new OracleCommand(sql, DBINFO.conn);
            DBINFO.rdr_eunae = DBINFO.cmd_eunae.ExecuteReader();


            while (DBINFO.rdr_eunae.Read())
            {
                Member memberVO = new Member();
                memberVO.rn = DBINFO.rdr_eunae["ROWNUM"].ToString();
                memberVO.id = DBINFO.rdr_eunae["id"].ToString();
                memberVO.pw = DBINFO.rdr_eunae["pw"].ToString();
                memberVO.name = DBINFO.rdr_eunae["name"].ToString();
                memberVO.role = DBINFO.rdr_eunae["role"].ToString();
                memberVO.resign = DBINFO.rdr_eunae["resign"].ToString();

                member.Add(memberVO);
            }

            DBINFO.rdr_eunae.Close();
            DBINFO.conn.Close();

            // member 리스트를 DataGridView에 바인딩
            foreach (Member memberVO in member)
            {
                dataGridView1.Rows.Add(memberVO.rn, memberVO.id, memberVO.pw, memberVO.name, memberVO.role, memberVO.resign);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            memberSearch();
        }

        private void memberSearch()
        // 검색기능
        {
            string currentComboBoxCode = "";
            List<Member> member = new List<Member>();
            dataGridView1.Rows.Clear();

            string currentComboBoxText = comboBox_search.SelectedItem.ToString();
            if (currentComboBoxText.Equals("선택하세요"))
            {
                currentComboBoxCode = "";
            }
            else if (currentComboBoxText.Equals("아이디"))
            {
                currentComboBoxCode = "WHERE id LIKE '%" + textBox_search.Text + "%'";
            }
            else if (currentComboBoxText.Equals("이름"))
            {
                currentComboBoxCode = "WHERE name LIKE '%" + textBox_search.Text + "%'";
            }

            DBINFO.conn.Open();
            try
            {
                string sql = "SELECT ROWNUM, id, pw, name, role, resign  FROM member " + currentComboBoxCode;
                DBINFO.cmd_eunae = new OracleCommand(sql, DBINFO.conn);
                DBINFO.rdr_eunae = DBINFO.cmd_eunae.ExecuteReader();
                while (DBINFO.rdr_eunae.Read())
                {
                    Member memberVO = new Member();
                    memberVO.rn = DBINFO.rdr_eunae["ROWNUM"].ToString();
                    memberVO.id = DBINFO.rdr_eunae["id"].ToString();
                    memberVO.pw = DBINFO.rdr_eunae["pw"].ToString();
                    memberVO.name = DBINFO.rdr_eunae["name"].ToString();
                    memberVO.role = DBINFO.rdr_eunae["role"].ToString();
                    memberVO.resign = DBINFO.rdr_eunae["resign"].ToString();

                    member.Add(memberVO);
                }

                foreach (Member members in member)
                {
                    dataGridView1.Rows.Add(members.rn, members.id, members.pw, members.name, members.role, members.resign);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
                try
                {
                    DBINFO.conn.Close();
                    DBINFO.rdr_eunae.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e.Message);
                    member = null;
                }
            }
        }

    }
}
