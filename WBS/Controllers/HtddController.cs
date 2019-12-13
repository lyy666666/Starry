using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.IO;
using WBSModel;
using Newtonsoft.Json;

namespace WBS.Controllers
{
    public class HtddController : Controller
    {
        // GET: Htdd
        #region 后台订单显示
        public ActionResult Show()
        {
            string url="";
            HttpClient  http = new HttpClient();
            HttpResponseMessage message = http.GetAsync(url).Result;
            string sql = message.Content.ReadAsStringAsync().Result;
            List<Tb_OrderInfo> list = JsonConvert.DeserializeObject<List<Tb_OrderInfo>>(sql);
            return View(list);
        }
        #endregion
        #region 订单明细
        public ActionResult MxShow()
        {
            string url = "";
            HttpClient http = new HttpClient();
            HttpResponseMessage message = http.GetAsync(url).Result;
            string sql = message.Content.ReadAsStringAsync().Result;
            List<Tb_SaleNum> list = JsonConvert.DeserializeObject<List<Tb_SaleNum>>(sql);
            return View(list);
        }
        #endregion
    }
}