using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.Website.Models
{
	public class Product
	{
		public Product()
		{
            //"Id": "selinazawacki-moon",
            //"Maker": "selinazawacki",
            //"img": "https://user-images.githubusercontent.com/41929050/61567057-142c1c80-aa33-11e9-9781-9e442418eaab.png",
            //"Url": "https://www.instagram.com/p/BFktVYPinKQ/",
            //"Title": "Holographic Dark Moon Necklace",
            //"Description": "Not sure if I\u0027ll be making more, get it while I have it in the store.",
            //"Ratings": null

            

            

        }

        public string Id { get; set; }

        public string Maker { get; set; }

        [JsonPropertyName("img")]
        public string Image { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}

