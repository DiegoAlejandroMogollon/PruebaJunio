using Microsoft.AspNetCore.Mvc;
using InventoryFrontend.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace InventoryFrontend.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: /Product
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("JWTToken");
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Auth");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("http://localhost:5116/api/product");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return View(products);
            }

            ViewBag.Error = "No se pudieron obtener los productos.";
            return View(new List<Product>());
        }

        // GET: /Product/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Product/Create
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            var client = _httpClientFactory.CreateClient();
            var token = HttpContext.Session.GetString("JWTToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Auth");
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:5116/api/product", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Hubo un error al crear el producto.";
                return View(product);
            }
        }
    }
}
