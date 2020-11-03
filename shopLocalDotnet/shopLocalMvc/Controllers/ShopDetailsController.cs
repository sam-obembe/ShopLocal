using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using shopLocalCommonModels;
using shopLocalCommonModels.DbEntities;
//using shopLocalDataAccess.Entities;
using shopLocalMvc.utils;

namespace shopLocalMvc.Controllers
{
    [AllowAnonymous]
    public class ShopDetailsController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly ILogger _logger;
        private string Api;
        private HttpClient client;

        public ShopDetailsController(ILogger<ProductController> logger, IConfiguration _configuration)
        {
            configuration = _configuration;
            _logger = logger;
            Api = configuration.GetSection("Api").Value;
            client = new HttpClient();

        }

        //useless for now
        public async Task<IActionResult> Index(int id)
        {

            string route = $"api/Shop/{id}";
            UriBuilder endPoint = new UriBuilder(Api);
            endPoint.Path = route;

            ShopModel shopModel = (await MvcHttpClient<ShopModel, dynamic>.GetAsync(endPoint.Uri)).Value;
            if (shopModel != null)
            {
                return View(shopModel);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Shop(int id)
        {
            string route = $"api/Shop/{id}";
            UriBuilder endPoint = new UriBuilder(Api);
            endPoint.Path = route;

            ShopModel shopModel = (await MvcHttpClient<ShopModel, dynamic>.GetAsync(endPoint.Uri)).Value;
            if (shopModel != null)
            {
                return View(shopModel);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> EditShop(int id)
        {
            string route = $"api/Shop/{id}";
            UriBuilder endPoint = new UriBuilder(Api);
            endPoint.Path = route;

            ShopModel shopModel = (await MvcHttpClient<ShopModel, dynamic>.GetAsync(endPoint.Uri)).Value;
            return View(shopModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditShop(int id, [Bind("Email,StreetAddress,City,State,ZipCode,Name,Longitude,Latitude")] ShopModel shop)
        {
            string route = $"api/Shop/EditShopDetails/{id}";
            UriBuilder endPoint = new UriBuilder(Api);
            endPoint.Path = route;

            try
            {
                var edited = (await MvcHttpClient<ShopEntity, ShopModel>.PutAsync(endPoint.Uri, shop)).Value;
                ShopModel editedModel = new ShopModel
                {
                    Email = edited.Email,
                    StreetAddress = edited.StreetAddress,
                    City = edited.City,
                    State = edited.State,
                    ZipCode = edited.ZipCode,
                    Name = edited.Name,
                    Latitude = edited.Latitude,
                    Longitude = edited.Longitude
                };
                return RedirectToAction("Shop", id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
