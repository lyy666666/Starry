using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSModel
{
    /// <summary>
    /// 商品分类表
    /// </summary>
    public class Tb_CommodityType
    {
        public int CommodTypeID { get; set; }
        public int CommodTypeFatherID { get; set; }
        public string CommodTypeName { get; set; }
        public int CommodTypeOrder { get; set; }
        public int CommodTypeDisplay { get; set; }
    }
}
