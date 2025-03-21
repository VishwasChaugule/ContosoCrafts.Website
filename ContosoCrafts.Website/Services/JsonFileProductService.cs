using System;
using System.Text.Json;
using ContosoCrafts.Website.Models;

namespace ContosoCrafts.Website.Services
{
	public class JsonFileProductService
	{
		public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
		{
			WebHostEnvironment = webHostEnvironment;
		}

		public IWebHostEnvironment WebHostEnvironment { get; set; }

		private string GetJsonFileName()
		{
			return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");
		}

        public IEnumerable<Product> GetProducts()
		{
			using(var jsonFileReader = File.OpenText(GetJsonFileName()))
			{
				return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
					new JsonSerializerOptions
					{
                        PropertyNameCaseInsensitive = true
					});

            }
			
		}
	}
}

