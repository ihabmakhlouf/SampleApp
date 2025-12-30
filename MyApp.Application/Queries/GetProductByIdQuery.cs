using MediatR;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;

namespace MyApp.Application.Queries
    {
    public record GetProductByIdQuery(Guid id) : IRequest<Product>;

    public class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Product>
        {
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                return await productRepository.GetProductByIdAsync(request.id);
            }
        }
    }
