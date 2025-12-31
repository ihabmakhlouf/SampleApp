using MediatR;
using MyApp.Application.Events;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Commands
    {
    public record AddProductCommand(Product Product) : IRequest<Product>;

    public class AddProductCommandHandler(IProductRepository productRepository, IPublisher publisher) : IRequestHandler<AddProductCommand, Product>
        {
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
            {
             var product = await productRepository.AddProductAsync(request.Product);
             await publisher.Publish(new ProductCreatedEvent());
             return product;
            }
        }
    }
