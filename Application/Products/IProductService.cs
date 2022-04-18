using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Application.Products
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetProducts();
    }
}
