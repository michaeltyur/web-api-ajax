using Exercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Exercise2.Controllers
{
    public class ShopItemController : ApiController
    {
        // GET api/items
        public IEnumerable<ShopItem> Get()
        {
            List<ShopItem> listItems = new List<ShopItem>();
            using (MyAppContext context = new MyAppContext())
            {
                listItems = context.ShopItems.ToList();
            }
            return listItems;
        }
        // GET item
        public ShopItem Get(int id)
        {
            ShopItem item = new ShopItem();

            using (MyAppContext context = new MyAppContext())
            {
                item = context.ShopItems.FirstOrDefault(i => i.Id == id);
            }
            return item;
        }

        // POST item
        public IEnumerable<ShopItem> Post([FromBody]ShopItem item)
        {
            using (MyAppContext context = new MyAppContext())
            {
                context.ShopItems.Add(item);
                context.SaveChanges();
            }
            return Get();
        }

        public IEnumerable<ShopItem> Put(int id, ShopItem item)
        {

            using (MyAppContext context = new MyAppContext())
            {
                ShopItem oldItem = context.ShopItems.FirstOrDefault(i => i.Id == id);
                if (item != null)
                {
                    oldItem.Image = item.Image;
                    oldItem.IsBought = item.IsBought;
                    oldItem.Name = item.Name;
                    oldItem.Description = item.Description;
                    oldItem.Amount = item.Amount;
                    context.SaveChanges();
                }
            }
            return Get();
        }

        [HttpPut]
        [Route("api/changeState/{id}")]
        public IEnumerable<ShopItem> ChangeState(int id)
        {

            using (MyAppContext context = new MyAppContext())
            {
                ShopItem item = context.ShopItems.FirstOrDefault(i => i.Id == id);
                if (item != null)
                {
                    item.IsBought = !item.IsBought;
                    if (item.IsBought&&item.Amount<1)
                    {
                        item.Amount = 1;
                    }
                    context.SaveChanges();
                }
            }
            return Get();
        }
        [HttpPut]
        [Route("api/changeStateAll/{id}")]
        public IEnumerable<ShopItem> ChangeStateAll(int id)
        {
            var _check = false;

            if (id == 1) _check = true;

            using (MyAppContext context = new MyAppContext())
            {
                List<ShopItem> itemList = context.ShopItems.ToList();
                if (_check)
                {
                    foreach (var item in itemList)
                    {
                        if (item != null)
                        {
                            item.IsBought = true;
                            if (item.Amount < 1)
                            {
                                item.Amount = 1;
                            }
                            context.SaveChanges();
                        }
                    }
                }
                else
                {
                    foreach (var item in itemList)
                    {
                        if (item != null)
                        {
                            item.IsBought = false;
                            context.SaveChanges();
                        }
                    }
                }
            }
            return Get();
        }
        // DELETE item
        public IEnumerable<ShopItem> Delete(int id)
        {
            using (MyAppContext context = new MyAppContext())
            {
                ShopItem item = context.ShopItems.FirstOrDefault(i => i.Id == id);

                if (item != null)
                {
                    context.ShopItems.Remove(item);
                    context.SaveChanges();
                }
            }
            return Get();
        }

        [HttpGet]
        [Route("api/clearAllAmount")]
        public IEnumerable<ShopItem> ClearAllAmount()
        {
            List<ShopItem> listItems = new List<ShopItem>();

            using (MyAppContext context = new MyAppContext())
            {
                listItems = context.ShopItems.ToList();
                foreach (var item in listItems)
                {
                    item.Amount = 0;
                    item.IsBought = false;
                }
                context.SaveChanges();
            }
            
            return Get();
        }

        [HttpGet]
        [Route("api/clearAllItems")]
        public IEnumerable<ShopItem> ClearAllItems()
        {
            List<ShopItem> listItems = new List<ShopItem>();

            using (MyAppContext context = new MyAppContext())
            {
                listItems = context.ShopItems.ToList();

                foreach (var item in listItems)
                {
                    context.ShopItems.Remove(item);
                }
                context.SaveChanges();
            }

            return Get();
        }
    }
}
