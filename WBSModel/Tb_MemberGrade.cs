using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSModel
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class Tb_MemberGrade
    {
        public int MemberID { get; set; }
        public string MemberAccount { get; set; }
        public string MemberCode { get; set; }
        public string MemberNickName { get; set; }
        public string MemberName { get; set; }
        public string MemberGender { get; set; }
        public string MemberPhone { get; set; }
        public int MemberState { get; set; }
        public int MemberBalance { get; set; }
    }
}
