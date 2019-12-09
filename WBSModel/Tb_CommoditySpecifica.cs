using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSModel
{
    /// <summary>
    /// 商品规格参考表
    /// </summary>
    public class Tb_CommoditySpecifica
    {
     public int  CommodSpeciID        { get; set; }
     public string  CommodSpeciName      { get; set; }
     public int  CommodSpeciOrder     { get; set; }
     public int  CommodSpeciDisplay   { get; set; }
     public int CommodTypeID { get; set; }
    }
}
