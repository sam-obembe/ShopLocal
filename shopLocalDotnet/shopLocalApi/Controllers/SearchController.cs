using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopLocalApi.Data;
using shopLocalApi.Data.Entities;
using shopLocalApi.Data.Queries;
using shopLocalCommonModels;

namespace shopLocalApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        ItemQuery itemQuery;
        public SearchController(ShopLocalContext context)
        {
            itemQuery = new ItemQuery(context);
        }

        [HttpGet("GetItem/{itemId}")]
        public async Task<ActionResult<ItemModel>> GetItem(int itemId)
        {
            var item = await itemQuery.GetItemById(itemId);
            var itemModel = new ItemModel
            {
                Description = item.Description,
                Name = item.Name,
                Price = item.Price,
                Id = item.Id,
                Quantity = item.Quantity
            };
            return itemModel;
        }


        [HttpGet("Search/{searchString}")]
        public async Task<ActionResult> Search(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
