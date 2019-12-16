using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSBLL
{
    public class GoodsInfoBll
    {
        public static List<WBSModel.Tb_GoodsInfo> GoodsInfoShow(int pageindex, int pagesize, string Name, out int Count)
        {
            Dictionary<string, object> keys = new Dictionary<string, object>();
            keys.Add("@pageindex", pageindex);
            keys.Add("@pagesize", pagesize);
            keys.Add("@Name", Name);
            keys.Add("@outcount", 1);
            List<WBSModel.Tb_GoodsInfo> list = WBSDAL.DBHelper.ExecProcGetResult<WBSModel.Tb_GoodsInfo>("P_FYShowGoods", keys, out Count);
            return list;

        }
    }
}
