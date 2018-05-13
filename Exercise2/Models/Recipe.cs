using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise2.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsSelected { get; set; }

        public string Image { get; set; }

        public  string Ingredients { get; set; }

        //public virtual List<ShopItem> Ingredients { get; set; }

        public virtual User Owner { get; set; }

        public Recipe()
        {
            IsSelected = false;
            Image = "https://unamo.com/assets/camaleon_cms/image-not-found-4a963b95bf081c3ea02923dceaeb3f8085e1a654fc54840aac61a57a60903fef.png";
        }
        public Recipe(string name,string description)
        {
            Name = name;
            Description = description;
            IsSelected = false;
            Image = "https://unamo.com/assets/camaleon_cms/image-not-found-4a963b95bf081c3ea02923dceaeb3f8085e1a654fc54840aac61a57a60903fef.png";
        }
        public Recipe(string name, string description, string ingredients)
        {
            Name = name;
            Description = description;
            IsSelected = false;
            Ingredients = ingredients;
            Image = "https://unamo.com/assets/camaleon_cms/image-not-found-4a963b95bf081c3ea02923dceaeb3f8085e1a654fc54840aac61a57a60903fef.png";
        }

        public static List<string> GetIngrediensList(string ingredients)
        {
           return ingredients.Split(',').ToList();
        }
    }
}