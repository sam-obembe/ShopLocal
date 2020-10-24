using shopLocalApi.Data.Entities;
using shopLocalCommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopLocalApi.Data.Queries
{
    public class ShopQuery
    {
        private ShopLocalContext context;
        public ShopQuery(ShopLocalContext _context)
        {
            context = _context;
        }
        public async Task<ShopEntity> GetShopById(int id)
        {
            using (context)
            {
                try
                {
                    var shop = context.Shops.Where(shop => shop.Id.Equals(id)).FirstOrDefault();
                    if (shop != null)
                    {
                        return shop;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public IEnumerable<ItemEntity> GetShopItems(int shopId)
        {
            using (var db = new ShopLocalContext())
            {
                try
                {
                    List<ItemEntity> items =
                        db.Items.Where<ItemEntity>(item => item.ShopId == shopId)
                        .AsEnumerable().ToList();
                    return items;

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


        public ItemEntity AddStoreItem(ItemEntity item)
        {
            using (var db = new ShopLocalContext())
            {
                try
                {
                    db.Items.Add(item);
                    db.SaveChanges();
                    return item;
                }
                catch
                {
                    return null;
                }
            }

        }

        public ShopEntity EditShopDetails(int shopId, ShopModel shop)
        {
            using (var db = new ShopLocalContext())
            {
                try
                {
                    var existingShop = db.Shops.Single(s => s.Id == shopId);
                    existingShop.Email = shop.Email;
                    existingShop.StreetAddress = shop.StreetAddress;
                    existingShop.City = shop.City;
                    existingShop.State = shop.State;
                    existingShop.ZipCode = shop.ZipCode;
                    existingShop.Name = shop.Name;
                    existingShop.Latitude = shop.Latitude;
                    existingShop.Longitude = shop.Longitude;

                    db.SaveChanges();

                    return existingShop;

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
