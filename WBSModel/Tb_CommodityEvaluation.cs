using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSModel
{
    /// <summary>
    /// 评价表
    /// </summary>
    public class Tb_CommodityEvaluation
    {
      public int  CommodityID             { get; set; }
      public int  GoodsID                 { get; set; }
      public string  CommodEvaluaContent     { get; set; }
      public int  OrderInfoID             { get; set; }
      public DateTime  CommodEvaluaTime        { get; set; }
      public int CommodevaluaOrder { get; set; }
    }
}
