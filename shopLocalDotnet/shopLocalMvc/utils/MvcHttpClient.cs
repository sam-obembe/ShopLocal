using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace shopLocalMvc.utils
{
    /// <summary>
    /// Static class for handling basic crud http requests
    /// </summary>
    /// <typeparam name="T">Represents the return class of the method</typeparam>
    /// <typeparam name="M">Represents the outgoing class of the method, i.e request body</typeparam>
    public static class MvcHttpClient<T, M>
    {
        private static HttpClient GetClient()
        {
            return new HttpClient();
        }

        public static async Task<ActionResult<T>> GetAsync(Uri uri)
        {
            var client = GetClient();
            var response = await (client.GetAsync(uri));

            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                T resultObject = JsonSerializer.Deserialize<T>(resultString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                client.Dispose();
                return resultObject;
            }
            else
            {
                return null;
            }
        }

        public static async Task<ActionResult<T>> PutAsync(Uri uri, M editModel)
        {
            var client = GetClient();
            var content = new StringContent(JsonSerializer.Serialize<M>(editModel, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }));

            var response = await client.PutAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                T result = JsonSerializer.Deserialize<T>(resultString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                client.Dispose();
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
