using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using shopLocalApi.Data.Entities;
using shopLocalCommonModels.DbEntities;
using shopLocalApi.Data.Queries;
using shopLocalCommonModels;
using shopLocalApi.Data;

namespace shopLocalApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        ShopQuery shopQuery;
        public ShopController(ShopLocalContext context)
        {
            shopQuery = new ShopQuery(context);
        }

        [HttpGet("{shopId}")]
        public async Task<ActionResult<ShopEntity>> GetShopById(int shopId)
        {
            var shop = await shopQuery.GetShopById(shopId);
            if (shop != null)
            {
                return shop;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("EditShopDetails/{shopId}")]
        public async Task<ActionResult<ShopEntity>> EditShopDetails(int shopId, ShopModel shop)
        {
            var editedShop = shopQuery.EditShopDetails(shopId, shop);
            if (editedShop != null)
            {
                return editedShop;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetShopItems/{shopId}")]
        public async Task<ActionResult<IEnumerable<ItemEntity>>> GetShopItems(int shopId)
        {
            var shopItems = shopQuery.GetShopItems(shopId);
            if (shopItems != null)
            {
                return shopItems.ToArray();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("AddItem/{shopId}")]
        public async Task<ActionResult> AddItemToShop(string shopId)
        {
            throw new NotImplementedException();
        }


        [HttpPut("UpdateItem/{itemId}")]
        public async Task<ActionResult> UpdateItem(string itemId)
        {
            throw new NotImplementedException();
        }


        [HttpDelete("DeleteItem/{itemId}")]
        public async Task<ActionResult> DeleteItem(string itemId)
        {
            throw new NotImplementedException();
        }
    }
}
