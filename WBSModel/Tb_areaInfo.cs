using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSModel
{
    public class Tb_areaInfo
    {
     public int   AreaInfoID            {get; set; }
     public string   AreaInfoName          {get; set; }
     public int   AreaInfoOrder         {get; set; }
     public int   AreaInfoFatherID      {get; set; }
     public int   AreaInfoDefault       {get; set; }
     public int AreaInfoState { get; set; }
    }
}
