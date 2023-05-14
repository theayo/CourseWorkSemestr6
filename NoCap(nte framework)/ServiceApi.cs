using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Alexeev.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Reflection;

namespace Alexeev
{
    public class ServiceApi
    {
        public ServiceApi() { }

        /*public async Task<List<Companion>> ServiceDialog(List<Companion> models)
        {
            var apiUrl = "https://example.com/api/endpoint"; 

            using (var httpClient = new HttpClient())
            {
                // Установка заголовков и сериализация модели в JSON
                var json = JsonConvert.SerializeObject(models);

                var content = new StringContent(json);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                // Отправка GET-запроса с моделью в теле
                var response = await httpClient.GetAsync(apiUrl, content);

                // Обработка ответа
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
                else
                {
                    Console.WriteLine("Ошибка при выполнении запроса.");
                }
            }
        }*/

        public async Task<ResponseCompanion> GenerateChatGptResponse(List<Companion> models)
        {
            var httpClient = new HttpClient();

            var requestBody = JsonSerializer.Serialize(
            
                models
            );

            var request = new HttpRequestMessage(HttpMethod.Post, AppSettings.ApiUrl)
            {
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };

            var response = await httpClient.SendAsync(request);

            string generatedText = string.Empty;

            ResponseCompanion res = new ResponseCompanion();

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var responseObject = JsonDocument.Parse(responseString);
                res.Answer =  JsonSerializer.Deserialize<Companion>(responseObject.RootElement.GetProperty("answer"));
                res.Context = JsonSerializer.Deserialize<List<Companion>>(responseObject.RootElement.GetProperty("context"));

            }
            else
            {
                var errorResponse = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                var errorMessage = errorResponse.RootElement.GetProperty("error");

                Console.WriteLine($"Request failed with status code {response.StatusCode} {response.ReasonPhrase} error = {errorMessage}");
            }

            return res;
        }

        public static async Task<string> GetMap()
        {
            var httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, AppSettings.ApiUrlMap);

            var response = await httpClient.SendAsync(request);

            string generatedText = string.Empty;

            string res = string.Empty;

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var responseObject = JsonDocument.Parse(responseString);
                res = responseObject.RootElement.GetProperty("map").ToString();

            }
            else
            {
                var errorResponse = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                var errorMessage = errorResponse.RootElement.GetProperty("error");

                Console.WriteLine($"Request failed with status code {response.StatusCode} {response.ReasonPhrase} error = {errorMessage}");
            }

            return res;
        }
    }
}
