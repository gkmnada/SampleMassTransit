using AutoMapper;
using Catalog.API.Context;
using Catalog.API.Models;
using MassTransit;
using Product.Contracts.Events;

namespace Catalog.API.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public ProductService(ApplicationDbContext context, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task CreateProductAsync(CreateProductModel createProductModel)
        {
            var entity = _mapper.Map<Entities.Product>(createProductModel);

            _context.products.Add(entity);
            await _publishEndpoint.Publish(_mapper.Map<ProductCreated>(entity));
            await _context.SaveChangesAsync();
        }
    }
}
