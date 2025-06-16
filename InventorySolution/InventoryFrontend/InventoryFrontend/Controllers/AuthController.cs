using Microsoft.AspNetCore.Mvc;
using InventoryFrontend.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace InventoryFrontend.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5116/api/auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                HttpContext.Session.SetString("JWTToken", token.Replace("\"", "")); 

                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Error = "Credenciales incorrectas.";
                return View(model);
            }
        }
    }
}
