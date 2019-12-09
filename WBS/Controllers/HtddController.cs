using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.IO;

namespace WBS.Controllers
{
    public class HtddController : Controller
    {
        // GET: Htdd
        #region 后台订单显示
        public ActionResult Show()
        {
            string Url="";
            HttpClient  http = new HttpClient();
            HttpResponseMessage message = http.GetAsync(Url);
            string sql = message.Content.ReadAsByteArrayAsync().Result;

            return View();
        }
	    #endregion
        
    }
}