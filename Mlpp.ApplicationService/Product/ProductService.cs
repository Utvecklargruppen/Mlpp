using Mlpp.ApplicationService.Product.Command;
using Mlpp.Domain.Part;
using Mlpp.Domain.Product;
using Mlpp.Infrastructure.Storage.Mlpp;
using System;

namespace Mlpp.ApplicationService.Product
{
    public class ProductService : BaseApplicationService<ProductAggregate, Guid>, IProductService
    {
        private readonly IPartRepository _partRepo;
        private readonly IProductRepository _productRepo;

        public ProductService(IMlppUnitOfWork uow, IProductRepository productRepo, IPartRepository partRepo)
            : base(uow, productRepo)
        {
            _productRepo = productRepo;
            _partRepo = partRepo;
        }

        public void When(CreateProduct command)
        {
            Execute(command, () =>
            {
                var product = new ProductAggregate(command.AggregateId, command.Name);
                _productRepo.Insert(product);
            });
        }

        public void When(ChangeProductName command)
        {
            Execute(command, product => product.SetName(command.Name));
        }

        public void When(RemoveProduct command)
        {
            Execute(command, product => product.Remove());
        }

        public void When(AddPart command)
        {
            Execute(command, product =>
            {
                var part = _partRepo.SafeGetById(command.PartId);
                product.AddPart(part);
            });
        }

        public void When(RemovePart command)
        {
            Execute(command, product =>
            {
                var part = product.SafeGetPart(command.PartId);
                product.RemovePart(part);
            });
        }
    }
}