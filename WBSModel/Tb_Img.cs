using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSModel
{
    /// <summary>
    /// 系统图片表
    /// </summary>
    public class Tb_Img
    { 
      public int  ImgID             { get; set; }
      public string  ImgUrl            { get; set; }
      public int  ImgMasterMap      { get; set; }
      public int  ImgType           { get; set; }
      public int PrimaryID { get; set; }
    }
}
