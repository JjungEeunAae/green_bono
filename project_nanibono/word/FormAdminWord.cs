using Oracle.ManagedDataAccess.Client;
using project_nanibono.common;

namespace project_nanibono.word
{
    public partial class FormAdminWord : Form
    {
        GroupDetail groupDetail = new GroupDetail();
        Group group = new Group();

        public FormAdminWord()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0; // 0번째 실행시키는 코드   
        }
        public string selectGoup_no()  // 정처기, sqld 중에 선택해서 선택 값 리턴하는 콤보박스1
        {
            string check = "";
            try
            {
                using (OracleConnection con = new OracleConnection(DBINFO.getConnection()))
                {
                    con.Open();
                    string c = comboBox1.SelectedItem.ToString();
                    DBINFO.sql = $"select group_detail_no from group_detail where group_detail_name='{c}'";
                    using (OracleCommand cmd = new OracleCommand(DBINFO.sql, con))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                check = reader.GetString(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 : " + ex.Message.ToString());
            }
            return check;
        }
        private void selectComboBox2() // 콤보박스1 의 값에 따라 중분류 과목이 나오는 콤보박스2
        {
            string a = selectGoup_no();
            try
            {
                using (OracleConnection con = new OracleConnection(DBINFO.getConnection()))
                {
                    con.Open();
                    string c = comboBox1.SelectedItem.ToString();
                    DBINFO.sql = $"select group_detail_name from group_detail where group_detail_no like '{a}_%' and '{a}' is not null";
                    using (OracleCommand cmd = new OracleCommand(DBINFO.sql, con))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            List<string> list = new List<string>();

                            while (reader.Read())
                            {
                                comboBox2.Items.Clear();
                                comboBox2.Items.Add("== 선택하세요 ==");

                                list.Add(reader.GetString(0));
                            }

                            foreach (string s in list)
                            {
                                comboBox2.Items.Add(s);
                                comboBox2.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 : " + ex.Message.ToString());
            }
        }
        public void selectedetailName()
        {
            if (comboBox1.SelectedIndex != 0 & comboBox2.SelectedIndex != 0)
            {
                group.group_name = comboBox1.SelectedItem.ToString();
                groupDetail.group_detail_name = comboBox2.SelectedItem.ToString();

                MessageBox.Show("정처기 또는 sqld : " + group.group_name);
                MessageBox.Show("중분류 : " + groupDetail.group_detail_name);
            }
        }

        private void selectGroupName(object sender, EventArgs e) // 정처기 또는 sql  선택
        {
            selectGoup_no();
            selectComboBox2();
        }

        private void selectGroupCategory(object sender, EventArgs e) // 정처기, sql 관련 카테고리 선택
        {
            selectedetailName();
        }
    }
}
