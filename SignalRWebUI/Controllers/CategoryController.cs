using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); //İstemci oluşturdum
            var responseMessage = await client.GetAsync("https://localhost:7029/api/Category");  // İstek sonucu dönecek response ve adresi vereceğiz 

            if(responseMessage.IsSuccessStatusCode) //eğer başarılı dönerse 200 201 202 204 gibi 299 a gider 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //jsonData dan gelen içeriği oku
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData); //Jsondatayı çözüp normal metine çevirdik
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
        {
            categoryDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryDto);
            StringContent stringContent = new StringContent(jsonData , Encoding.UTF8 , "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7029/api/Category", stringContent);

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient(); //istemci oluşturduk
            var responseMessage = await client.DeleteAsync($"https://localhost:7029/api/Category/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();   //istemci oluşturduk
            var responseMessage = await client.GetAsync($"https://localhost:7029/api/Category/{id}");  //Nereye gideceğini verdik ve get dedik
            if(responseMessage.IsSuccessStatusCode) //Başarılıysa gir 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();  //Jsondan gelen içeriği oku
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values); //Döneceksin
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient(); 
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData , Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7029/api/Category", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }


    }
}
