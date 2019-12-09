using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSModel
{
    /// <summary>
    /// 商品表
    /// </summary>
    public class Tb_GoodsInfo
    {
       public int GoodsID           {get;set;}
       public string GoodsName         {get;set;}
       public string  GoodsTitle       {get;set;}
       public int  GoodsDisplay     {get;set;}
       public decimal  GoodsPrice       {get;set;}
       public int  GoodsWeight      {get;set;}
       public string  GoodsRemark      {get;set;}
       public int  GoodsState       {get;set;}
       public int  GoodsBorwseNum   {get;set;}
       public int  GoodsSaleNum     {get;set;}
       public int  GoodsEvaluaNum   {get;set;}
       public int  CommodTypeID     {get;set;}
       public int GoodsFreight { get; set; }
    }
}
