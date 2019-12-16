using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WBS.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult Index(int pageindex=1,int pagesize=5,string Name="")
        {
          
            if (string.IsNullOrEmpty(Name))
            {
                Name = "";
            }
          List<WBSModel.Tb_GoodsInfo> list=  WBSBLL.GoodsInfoBll.GoodsInfoShow(pageindex, pagesize, Name, out int Count);
            int pagecount = Count; //(list == null || list.Count == 0) ? 0 : list[0].Rows;//总页数
            int z = (int)Math.Ceiling((decimal)pagecount / pagesize);
            ViewBag.PagePro = pageindex <= 1 ? 1 : pageindex - 1;
            ViewBag.PageNext = pageindex >= z ? z : pageindex + 1;
            ViewBag.PageList = z;
            return View(list);
        }


        public  ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public JsonResult  DengLu(string Phone)
        {
            object code = WBSDAL.PhoneCode.Code(Phone);
            
            return Json(code);
        }
    }
}