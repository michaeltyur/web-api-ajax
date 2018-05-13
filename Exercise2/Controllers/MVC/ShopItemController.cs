using Exercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Exercise2.Controllers.MVC
{
    public class ShopItemController : Controller
    {
        // GET: ShopItem
        public ActionResult Index()
        {
            List<ShopItem> listItems = new List<ShopItem>();
            return View();
        }

        public ActionResult ShopList()
        {
            ViewBag.Title = "Shopping Ingredients Page";

            List<ShopItem> listItems = new List<ShopItem>();

            using (MyAppContext context = new MyAppContext())
            {
                listItems = context.ShopItems.ToList();
            }
            return View(listItems);
        }
        //public ActionResult ShopList(int id)
        //{

        //    Recipe recipe = new Recipe();

        //    List<ShopItem> listIngrediens = new List<ShopItem>();

        //    using (MyAppContext context = new MyAppContext())
        //    {
        //        recipe = context.Recipes.Include(i => i.Ingredients).FirstOrDefault(r => r.Id == id);

        //        listIngrediens = recipe.Ingredients;
        //    }

        //     if(recipe!=null) ViewBag.Title = "Shopping Ingredients for " + recipe.Name;

        //    if (listIngrediens != null)
        //    {
        //        return View(listIngrediens);
        //    }
        //    else return RedirectToAction("Index", "Home");
            
        //}
    }
}
