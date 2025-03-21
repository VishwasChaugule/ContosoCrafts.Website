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

		public bool AddRating(string productId, int rating)
		{
			var products = GetProducts();
			var query = products.FirstOrDefault(x => x.Id == productId);
			if (query != null)
			{
				if (query.Ratings == null)
				{
					query.Ratings = new int[] { rating };
				}
				else
				{
					var ratings = query.Ratings.ToList();
					ratings.Add(rating);
					query.Ratings = ratings.ToArray();
				}

				using (var outstream = File.OpenWrite(GetJsonFileName()))
				{
					JsonSerializer.Serialize<IEnumerable<Product>>(
						new Utf8JsonWriter(outstream, new JsonWriterOptions
						{
							SkipValidation = true,
							Indented = true
						}),
						products
						);
				}

				return true;
			}

			return false;	
		}
	}
}

