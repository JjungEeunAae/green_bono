using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_nanibono.member
{
    public class Member
    {
        // 회원
        public string id { get; set; }
        public string pw { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public string resign { get; set; }
        public string rn { get; set; }


        public override string ToString()
        {
            return $"id: {id}, pw: {pw}, name: {name}, role: {role}, resign: {resign}, rn: {rn}";
        }
    }
}
