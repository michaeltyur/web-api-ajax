using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise2.Models
{
    public class ShopItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsBought { get; set; }

        public int Amount { get; set; }

        public string Image { get; set; }


        public ShopItem()
        {
            IsBought = false;
            Image = "https://unamo.com/assets/camaleon_cms/image-not-found-4a963b95bf081c3ea02923dceaeb3f8085e1a654fc54840aac61a57a60903fef.png";
        }
        public ShopItem(string name)
        {
            Name = name;
            IsBought = false;
            Image = "https://unamo.com/assets/camaleon_cms/image-not-found-4a963b95bf081c3ea02923dceaeb3f8085e1a654fc54840aac61a57a60903fef.png";
        }
    }
}