namespace project_nanibono.request
{
    public class Request
    {
        public string request_no { get; set; }
        public string process_division { get; set; }
        public string request_division { get; set; }
        public string request_content { get; set; }
        public string request_date { get; set; }
        public string reason { get; set; }
        public string request_ryn { get; set; }
        public string id { get; set; }
        public string word_no { get; set; }
        public string word { get; set; }

        public override string ToString()
        {
            return $"request_no: {request_no}, process_division: {process_division}," +
                $"request_division: {request_division}, request_content: {request_content}, request_date: {request_date}" +
                $"reason: {reason}, request_ryn: {request_ryn}, id: {id}, word_no: {word_no}, word: {word}";
        }
    }
}
