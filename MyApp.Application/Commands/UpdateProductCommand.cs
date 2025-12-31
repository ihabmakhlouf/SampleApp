using MediatR;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Commands
    {
     public record UpdateProductCommand(Guid id, Product Product) : IRequest<bool>;

    public class UpdateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductCommand, bool>
        {

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
             return await productRepository.UpdateProductAsync(request.Product, request.id);
            }
        }
    }
