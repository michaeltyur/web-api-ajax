using Exercise2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exercise2.DbInitializer
{
    public class AppDbInitializer : DropCreateDatabaseAlways<MyAppContext>
    {
        List<ShopItem> _ingridiens = new List<ShopItem>();

        List<User> _users = new List<User>();

        protected override void Seed(MyAppContext context)
        {
            #region Users

            _users.Add(
                new User
                {
                    UserName = "admin",
                    Password = "123"
                });
            _users.Add(
                 new User
                 {
                     UserName = "superadmin",
                     Password = "1"
                 });
            _users.Add(
                 new User
                 {
                     UserName = "user",
                     Password = "12345"
                 });

            #endregion

            #region ShopItem
            _ingridiens.Add(
                new ShopItem
                {
                    Name = "salt",
                    Description = "Being the basic ingredient of any cuisine, Salt is bound to have a large demand in the markets and we cater to the demands with remarkable efficiency"

                });
            _ingridiens.Add(new ShopItem
            {
                Name = "white sugar",
                Description = "Irresistibles Organic Pure Sugar",
            });
            _ingridiens.Add(new ShopItem
            {
                Name = "flour",
                Description = "Wheat flour is made from the grinding of wheat used for human consumption. Soft flour is comparatively low in gluten"
            });
            _ingridiens.Add(new ShopItem
            {
                Name = "egg",
                Description = "Egg white is the clear liquid (also called the albumen or the glair/glaire) contained within an egg"
            });
            _ingridiens.Add(new ShopItem
            {
                Name = "lemon juice",
                Description = "Clarified lemon and lime juices are used as natural acidulants, culinary ingredients and widely utilized bar supplies"
            });
            _ingridiens.Add(new ShopItem
            {
                Name = "vanilla extract",
                Description = ""
            });
            _ingridiens.Add(new ShopItem
            {
                Name = "black olives",
                Description = "The olive is a fruit that grows on trees. When fully ripened, it turns a black color; however, not all ripe olives are naturally black"
            });
            _ingridiens.Add(new ShopItem
            {
                Name = "dark chocolate",
                Description = "Dark chocolate (also known as black chocolate[1] or plain chocolate)[2] is a form of chocolate which contains a higher percentage of cocoa solids and cocoa butter than milk chocolate"
            });
            _ingridiens.Add(new ShopItem
            {
                Name = "orange",
                Description = "The orange is the fruit of the citrus species Citrus × sinensis in the family Rutaceae"
            });
            _ingridiens.Add(new ShopItem
            {
                Name = "cornstarch",
                Description = "The cornstarch is a thickening agent that is made from refined maize starch"
            });
            #endregion

            #region Recipes
            context.Recipes.Add(
            new Recipe
            {
                Name = "Strawberry Pie",
                Description = "Renee's Strawberry Rhubarb Pie",
                Owner = _users[0],
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTdv9V7fNxQxlu-3f3oaJL845jAF8jRgClxOjapOeZlV2X3UPgy",
                Ingredients = "cornstarch,cups diced rhubarb,sliced fresh strawberries,white sugar,lemon juice,vanilla extract"
            });
            context.Recipes.Add(
            new Recipe
            {
                Name = "Paska Bread",
                Description = "This traditional Polish egg bread is wonderfully light with a slightly sweet flavor.",
                Owner = _users[1],
                Image = "http://www.frugalmomeh.com/wp-content/uploads/2013/08/IMG_5357.jpg",
                Ingredients = "white sugar,warm milk,flour,egg,butter,salt",
            });

            context.Recipes.Add(
            new Recipe
            {
                Name = "Cajun Chicken Pasta",
                Description = "Cajun cooking is a combination of French and Southern cuisine.",
                Owner = _users[2],
                Image = "https://images.media-allrecipes.com/userphotos/720x405/606388.jpg",
                Ingredients = "linguine pasta,skinless,red pepper,mushrooms,linguine pasta,cheese",
            });

            context.Recipes.Add(
            new Recipe
            {
                Name = "Yakisoba Chicken",
                Description = "Japanese buckwheat flour noodles with chicken at their best!",
                Owner = _users[1],
                Image = "https://images.media-allrecipes.com/userphotos/720x405/2220105.jpg",
                Ingredients = "sesame oil,canola oil,chile paste,chicken halves,soba noodles,soy sauce",
            });

            context.Recipes.Add(
            new Recipe
            {
                Name = "Dessert Crepes",
                Description = "Essential crepe recipe. Sprinkle warm crepes with sugar and lemon, or serve with cream or ice cream and fruit",
                Owner = _users[2],
                Image = "http://everydaydishes.com/wp-content/uploads/2016/04/nutella-crepes-recipe-video-everydaydishes_com-H.jpg",
                Ingredients = "flour,milk,butter,sugar,salt"
            });

            #endregion


            foreach (var item in _ingridiens)
            {
                context.ShopItems.Add(item);
            }



            foreach (var user in _users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();

            base.Seed(context);

        }


    }
}