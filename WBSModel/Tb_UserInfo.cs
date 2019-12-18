using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSModel
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class Tb_UserInfo
    {
     public int  UserInfoID         { get; set; }
     public string  UserInfoName       { get; set; }
     public string  UserInfoPwd        { get; set; }
     public string  UserInfoChinaName  { get; set; }
     public string  UserInfoSex        { get; set; }
     public string  UserInfoPhone      { get; set; }
     public string  UserInfoEmail      { get; set; }
     public string  UserInfoRemarks    { get; set; }
     public int RoleInfoID { get; set; }


    }
}
