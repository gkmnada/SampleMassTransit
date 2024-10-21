using MassTransit;
using Nest;
using Product.Contracts.Events;

namespace Filter.API.Consumers
{
    public class ProductCreatedConsumer : IConsumer<ProductCreated>
    {
        private readonly IElasticClient _elasticClient;

        public ProductCreatedConsumer(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task Consume(ConsumeContext<ProductCreated> context)
        {
            var product = context.Message;
            await _elasticClient.IndexDocumentAsync(product);
        }
    }
}
