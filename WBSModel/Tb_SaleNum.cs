using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSModel
{
    /// <summary>
    /// 订单明细表
    /// </summary>
    public class Tb_SaleNum
    {
        public int SaleNumID { get; set; }
        public int OrderInfoID { get; set; }
        public int GoodsID { get; set; }
        public int SaleNumState { get; set; }
    }
}
