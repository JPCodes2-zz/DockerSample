using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DbRepository.Models
{
    public class Product
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [Required(ErrorMessage = "ProdutId is Must")]
        [JsonProperty(PropertyName = "ProductId")]
        public string ProdutId { get; set; }
        [Required(ErrorMessage = "ProductName is Must")]
        [JsonProperty(PropertyName = "ProductName")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Price is Must")]
        [JsonProperty(PropertyName = "Price")]
        public int Price { get; set; }
        [Required(ErrorMessage = "CategoryName is Must")]
        [JsonProperty(PropertyName = "CategoryName")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Manufacturer is Must")]
        [JsonProperty(PropertyName = "Manufacturer")]
        public string Manufacturer { get; set; }
    }
}
