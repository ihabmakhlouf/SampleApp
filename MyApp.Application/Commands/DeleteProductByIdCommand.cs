using MediatR;
using MyApp.Domain.Interfaces;

namespace MyApp.Application.Commands
    {
     public record DeleteProductByIdCommand(Guid id) : IRequest<bool>;
    public class DeleteProductByIdCommandHandler(IProductRepository productRepository) :
        IRequestHandler<DeleteProductByIdCommand, bool>
        {
        public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
            {
               return await productRepository.DeleteProductByIdAsync(request.id);
            }
        }
    }
