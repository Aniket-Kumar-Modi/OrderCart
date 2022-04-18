using Application.Products;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public sealed class ProductService : IProductService
    {
        private string BaseUrl;
        private List<Product> _products = new List<Product>();


        public ProductService(IConfiguration configuration)
        {
            BaseUrl = configuration.GetValue<string>("APIUrl");
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            if (_products.Count() == 0)
            {
                using (var httpClient = new HttpClient())
                {
                    _products = await httpClient.GetFromJsonAsync<List<Product>>("https://fakestoreapi.com/products");

                }
            }

            return _products;
        }
    }
}
