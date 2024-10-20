using Catalog.API.Models;

namespace Catalog.API.Services
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateProductModel createProductModel);
    }
}
