using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using System.Text.Json;
//using shopLocalDataAccess.Entities;
using shopLocalCommonModels;
using Microsoft.AspNetCore.Authorization;
using shopLocalMvc.utils;
using shopLocalMvc.Models;

namespace shopLocalMvc.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly ILogger _logger;
        private readonly IConfiguration configuration;
        private string Api;
        private HttpClient client;

        public ProductController(ILogger<ProductController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            configuration = _configuration;
            Api = configuration.GetSection("Api").Value;
            client = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var endPoint = new UriBuilder(Api);
            string route = "api/Shop/GetStoreItems";
            return View();
        }

        public async Task<IActionResult> Product(int id)
        {
            string route = $"api/Product/GetItem/{id}";
            var endPoint = new UriBuilder(Api);
            endPoint.Path = route;

            ItemModel item = (await MvcHttpClient<ItemModel, dynamic>.GetAsync(endPoint.Uri)).Value;
           
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> EditProduct(int id)
        {
            ItemModel item = GetProductInformation(id).Result.Value;
            return View(item);
        }


        private async Task<ActionResult<ItemModel>> GetProductInformation(int id)
        {
            string route = $"api/Product/GetItem/{id}";
            var endPoint = new UriBuilder(Api);
            endPoint.Path = route;

            try
            {
                ItemModel item = (await MvcHttpClient<ItemModel, dynamic>.GetAsync(endPoint.Uri)).Value;
                return item;

            }
            catch(Exception ex)
            {
                return new ItemModel();
            }



        }
    }
}