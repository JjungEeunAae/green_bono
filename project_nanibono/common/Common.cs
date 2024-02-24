using Oracle.ManagedDataAccess.Client;

namespace project_nanibono.common
{
    public static class Common
    {
        // 공통으로 쓸 메소드를 저장
        public static List<string> getGroupDetailNameList(string code)
        // comboBox에 DB에 있는 값 넣어줄려고 만든 메소드, code는 group_detail_name를 가져오기 위한 상위분류코드이다.
        {
            List<string> list = new List<string>();

            using (OracleConnection conn = new OracleConnection(DBINFO.strConnection))
            {
                conn.Open();
                string sql = "SELECT group_detail_name FROM group_detail WHERE group_no = :code";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("code", code.ToUpper());
                    using (OracleDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            list.Add(rdr["group_detail_name"].ToString());
                        }
                    }
                }
            }
            return list;
        }

        public static string getGroupDetailName(string code)
        {
            string result = null;
            using (OracleConnection conn = new OracleConnection(DBINFO.strConnection))
            {
                conn.Open();
                string sql = "SELECT group_detail_name FROM group_detail WHERE group_detail_no = :code";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("code", code.ToUpper());
                    using (OracleDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            result = rdr["group_detail_name"].ToString();

                            if (rdr["group_detail_name"].ToString().Equals("~중이다"))
                            {
                                result = "요청";
                            }
                            else if (rdr["group_detail_name"].ToString().Equals("그러하다"))
                            {
                                result = "승인";
                            }
                            else if (rdr["group_detail_name"].ToString().Equals("그러하지 않다"))
                            {
                                result = "거절";
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static string getGroupDetailNo(string reason)
        // 거절사유를 받아서 group_detail_no를 반환한다(request 테이블에 update할 목적)
        {
            using (OracleConnection conn = new OracleConnection(DBINFO.strConnection))
            {
                conn.Open();
                string sql = "SELECT group_detail_no FROM group_detail where group_detail_name = :reason";
                // 쿼리 실행
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("reason", reason);
                    using (OracleDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            return rdr["group_detail_no"].ToString();
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static void requestDetailRead(string type, string requestCode, List<TextBox> textBoxs)
        {
            string code;

            using (OracleConnection conn = new OracleConnection(DBINFO.strConnection))
            {
                conn.Open();
                string sql = "SELECT request_no, process_division, request_division" +
                             "     , request_content, request_date" +
                             "     , reason, id, r.word_no, word, word_mean, category " +
                               "FROM request r JOIN word w " +
                                 "ON r.word_no = w.word_no " +
                              "WHERE request_no = :requestCode";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add("requestCode", requestCode);
                    using (OracleDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            textBoxs[0].Text = "admin";       // 수정자
                            code = rdr["category"].ToString();
                            textBoxs[1].Text = getGroupDetailName(code.Split("_")[0].Substring(0, 3)); // 분류
                            textBoxs[2].Text = getGroupDetailName(code);                               // 카테고리
                            textBoxs[3].Text = rdr["word_mean"].ToString();                            // 단어설명
                            textBoxs[4].Text = rdr["id"].ToString();                                   // 아이디(요청자)
                            textBoxs[5].Text = rdr["word_no"].ToString();                              // 단어코드
                            textBoxs[6].Text = rdr["word"].ToString();                                 // 단어명
                            textBoxs[7].Text = rdr["request_content"].ToString();                      // 요청내용
                            textBoxs[8].Text = rdr["request_date"].ToString();                         // 요청일

                            if (type.Equals("UPDATE"))
                            {
                                code = rdr["request_division"].ToString();
                                textBoxs[9].Text = getGroupDetailName(code);                           // 요청구분
                            }
                        }
                    }
                }
            }
        }

        public static void wordUpdate(string processDivision, string word, string wordMean, string wordCode, Form form)
        {
            using (OracleConnection conn = new OracleConnection(DBINFO.strConnection))
            {
                conn.Open();
                string sql = "UPDATE word " +
                                "SET word = :word " +
                                    ", word_mean = :wordMean " +
                                    ", delete_yn = :processDivision " +
                                "WHERE word_no = :wordCode";
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    try
                    {
                        cmd.Parameters.Add("word", word);
                        cmd.Parameters.Add("wordMean", wordMean);
                        cmd.Parameters.Add("processDivision", processDivision.ToUpper());
                        cmd.Parameters.Add("wordCode", wordCode);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("처리가 완료되었습니다.");
                            form.Close();                            // 현재 Form 닫기
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Common.wordUpdate 메소드에서 에러가 났다. >> An error occurred: " + ex.Message);
                    }
                }
            }
        }

        public static bool requestUpdate(string processDivision, string groupDetailCode, string request_no)
        {
            bool result = false;

            //string processDivision = comboBox_processDivision.Text;
            //string groupDetailCode = Common.getGroupDetailNo(comboBox_reason.Text);
            string sql = "UPDATE request " +
                            "SET request_ryn = :processDivision " +
                              ", reason = :groupDetailCode" +
                         " WHERE request_no = :request_no";

            if (processDivision.Equals("선택해주세요"))
            {
                MessageBox.Show("처리구분을 선택해주세요");
                return result;
            }

            using (OracleConnection conn = new OracleConnection(DBINFO.strConnection))
            {

                if (processDivision.Equals("N"))
                {
                    if (groupDetailCode == null)
                    {
                        MessageBox.Show("거절사유를 입력해주세요");
                        return result;
                    }
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        try
                        {
                            cmd.Parameters.Add("processDivision", processDivision);
                            cmd.Parameters.Add("groupDetailCode", groupDetailCode);
                            cmd.Parameters.Add("request_no", request_no);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                return result = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                    }
                }
                else
                {
                    conn.Open();
                    // 쿼리 실행
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        try
                        {
                            cmd.Parameters.Add("processDivision", processDivision);
                            cmd.Parameters.Add("groupDetailCode", groupDetailCode);
                            cmd.Parameters.Add("request_no", request_no);

                            int rowsAffected = cmd.ExecuteNonQuery(); // 쿼리 실행 및 영향 받은 행 수 가져오기

                            if (rowsAffected > 0)
                            {
                                return result = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                    }
                }
            }
            return result;
        }
    }
}
