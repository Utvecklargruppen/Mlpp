using Mlpp.ApplicationService.Product.Command;
using Mlpp.Domain.Product;
using Mlpp.Infrastructure.Storage;
using Mlpp.Infrastructure.Storage.Mlpp;
using System;

namespace Mlpp.ApplicationService.Product
{
    public class ProductService : BaseApplicationService<MlppContext, ProductAggregate, Guid>, IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IUnitOfWork<MlppContext> uow, IProductRepository repo)
            : base(uow, repo)
        {
            _repo = repo;
        }

        public void When(CreateProduct command)
        {
            Execute(command, () =>
            {
                var product = new ProductAggregate(command.Id, command.Name);

                _repo.Insert(product);
            });
        }

        public void When(ChangeProductName command)
        {
            Execute(command, product => product.SetName(command.Name));
        }
    }
}
