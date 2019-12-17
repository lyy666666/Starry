using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

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
        public void DengLu(string Phone)
        {
            //HttpCookie cookie = Request.Cookies["Cooks"];
            //if (cookie==null)
            //{
            //     cookie = new HttpCookie("Cooks");
            //}
            string code = WBSDAL.PhoneCode.Code(Phone);
            Session["code"] = code;
            //cookie.Value = code;
            //cookie.Expires = DateTime.Now.AddMinutes(5);
            //Response.Cookies.Add(cookie);
            //return Json(code);
        }

        [HttpPost]
        public void Login(string phone, string pnum)
        {
            //HttpCookie cookie = Request.Cookies["Cooks"];
            //string Code =cookie.Value;
          string c=  Session["code"].ToString();
            if (pnum.Equals(c))
            {
                Response.Write("<script>alert('登录成功');location.href='/Administrator/Index';</script>");
            }
        }
    }
}
