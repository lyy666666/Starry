using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSModel
{
    /// <summary>
    /// 订单表
    /// </summary>
    public class Tb_OrderInfo
    {
       public int OrderInfoID     { get; set; }
       public int OrderInfoTime   { get; set; }
       public int  MemberID       { get; set; }
       public int  OrderInfoStat  { get; set; }
       public int ConsigneeID { get; set; }
    }
}
