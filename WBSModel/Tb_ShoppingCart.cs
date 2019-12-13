using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSModel
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class Tb_ShoppingCart
    {
       public int ShoppingCartID      { get; set; }
       public int GoodsID             { get; set; }
       public int ShoppingCartNum     { get; set; }
       public int MemberID            { get; set; }
       public DateTime EvaluaTime { get; set; }
    }
}
