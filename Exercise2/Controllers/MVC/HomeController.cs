using Exercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Exercise2.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //Get ingrediens list for buy
        //public ActionResult SelectNeedItem(int id)
        //{

        //    Recipe recipe = new Recipe();
        //    using (MyAppContext context = new MyAppContext())
        //    {
        //        recipe = context.Recipes.Include(i => i.Ingredients).FirstOrDefault(r => r.Id == id);
        //        List<ShopItem> listIngrediens = recipe.Ingredients;
        //        foreach (var item in listIngrediens)
        //        {
        //            item.IsBought = true;
        //        }
        //        context.SaveChanges();
            
        //    }
        //    return RedirectToAction("ShopList", "ShopItem");
        //}
    }
}
