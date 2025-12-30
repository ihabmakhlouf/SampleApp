using MediatR;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Queries
    {
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
    public class GetProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
        {
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
              return await productRepository.GetProductsAsync();
            }
        }
    }
