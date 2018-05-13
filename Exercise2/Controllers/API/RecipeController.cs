using Exercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exercise2.ViewModels;

namespace Exercise2.Controllers
{

    public class RecipeController : ApiController
    {

        // GET: api/Recipe
        public IHttpActionResult Get()
        {
            //ViewBag.Message=
            List<Recipe> listRecepes = new List<Recipe>();
            using (MyAppContext context = new MyAppContext())
            {
                listRecepes = context.Recipes.Include(r => r.Owner).ToList();
            }
            return Ok(listRecepes);
        }

        // GET: api/Recipe/5
        public IHttpActionResult Get(int id)
        {
            Recipe recipe = new Recipe();

            using (MyAppContext context = new MyAppContext())
            {
                recipe = context.Recipes.Include(r => r.Owner).FirstOrDefault(r => r.Id == id);
            }
            return Ok(recipe);
        }

        // POST: api/Recipe
        //[Authorize]
        public IHttpActionResult Post([FromBody]RecipeViewModel recipe)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Content(HttpStatusCode.BadRequest, "You do not have access rights. Please, sign in");
            }
            using (MyAppContext context = new MyAppContext())
            {


                //var test = GetShopItemsList(recipe.Ingredients);
                var newRecipe = new Recipe()
                {
                    Name = recipe.Name,
                    Description = recipe.Description,
                    IsSelected = false,
                    Owner = context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name),
                    Ingredients = recipe.Ingredients
                };
                if (recipe.Image != null) newRecipe.Image = recipe.Image;

                context.Recipes.Add(newRecipe);
                context.SaveChanges();
            }
            return Get();
        }

        // PUT: api/Recipe/5
        //[Authorize]
        public IHttpActionResult Put(int id, [FromBody]Recipe recipe)
        {
            using (MyAppContext context = new MyAppContext())
            {
                Recipe oldRecipe = context.Recipes.Include(r => r.Owner).FirstOrDefault(r => r.Id == id);
                if (User.Identity.Name == oldRecipe.Owner.UserName)
                {
                    oldRecipe.Image = recipe.Image;
                    oldRecipe.Ingredients = recipe.Ingredients;
                    oldRecipe.IsSelected = recipe.IsSelected;
                    oldRecipe.Name = recipe.Name;
                    context.SaveChanges();
                }
                else return Content(HttpStatusCode.BadRequest, "You do not have access rights");
            }
            return Get();
        }

        //
        [Route("api/buyIngrediens/{id:int}")]
        public IHttpActionResult BuyIngrediens(int id)
        {

            using (MyAppContext context = new MyAppContext())
            {
                Recipe recipe = context.Recipes.Include(r => r.Owner).FirstOrDefault(r => r.Id == id);

                List<ShopItem> listShopItems = context.ShopItems.ToList();

                List<string> ingredients = Recipe.GetIngrediensList(recipe.Ingredients);

                bool isExist = false;

                foreach (var name in ingredients)
                {
                    foreach (var item in listShopItems)
                    {
                        if (name == item.Name)
                        {
                            item.Amount = 1;
                            item.IsBought = true;
                            isExist = true;
                        }
                    }
                    if (!isExist)
                    {
                        ShopItem newItem = new ShopItem
                        {
                            Name = name,
                            IsBought = true,
                            Amount = 1,
                            Description= "Not Description"
                        };
                        context.ShopItems.Add(newItem);
                    }
                }
                context.SaveChanges();
            }
            return Get();
        }

        // DELETE Recipe
        //[Authorize]
        public IHttpActionResult Delete(int id)
        {
            using (MyAppContext context = new MyAppContext())
            {
                Recipe recipe = context.Recipes.Include(r => r.Owner).FirstOrDefault(r => r.Id == id);

                if (User.Identity.Name == recipe.Owner.UserName)
                {
                    if (recipe != null)
                    {
                        context.Recipes.Remove(recipe);
                        context.SaveChanges();
                    }
                }
                else return Content(HttpStatusCode.BadRequest, "You do not have access rights");
            }
            return Get();
        }

        //private List<string> GetIngrediensList(string ingrediens)
        //{
        //    List<string> itemsList = ingrediens.Split(',').ToList();

        //    using (MyAppContext context = new MyAppContext())
        //    {
        //        List<ShopItem> existingIngredients = context.ShopItems.ToList();

        //        bool isExist = false;

        //        foreach (var name in itemsList)
        //        {
        //            foreach (var exItem in existingIngredients)
        //            {
        //                if (name == exItem.Name)
        //                {
        //                    //itemsList.Add(exItem);
        //                    isExist = true;
        //                    break;
        //                }
        //            }
        //            if (!isExist)
        //            {
        //                var newItem = new ShopItem(name);
        //                //itemsList.Add(newItem);
        //                context.ShopItems.Add(newItem);
        //                context.SaveChanges();
        //            }
        //        }
        //    }
        //    return itemsList;
        //}
    }
}
