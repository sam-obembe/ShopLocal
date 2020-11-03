using shopLocalApi.Data;
//using shopLocalApi.Data.Entities;
using shopLocalCommonModels.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopLocalApi.Data.Queries
{
    public class ItemQuery
    {
        private ShopLocalContext context;
        public ItemQuery(ShopLocalContext _context)
        {
            context = _context;
        }


        public async Task<ItemEntity> GetItemById(int id)
        {
            using (context)
            {
                try
                {
                    var item = context.Items.Where(item => item.Id.Equals(id));
                    return item.FirstOrDefault();

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        public IEnumerable<ItemEntity> GetItemsByName(string name)
        {
            using (var db = new ShopLocalContext())
            {
                try
                {
                    var items = db.Items.Where(item => item.Name.Contains(name));
                    return items.AsEnumerable();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
