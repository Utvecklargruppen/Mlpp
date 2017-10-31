using System;
using System.Linq;
using Mlpp.Domain.Part;
using Mlpp.Domain.Product.Events;
using Mlpp.Domain.Product.State;

namespace Mlpp.Domain.Product
{
    public class ProductAggregate : IAggregate<ProductState, Guid>
    {
        private readonly ProductState _state;

        public ProductAggregate(Guid id, string name)
        {
            if (id == Guid.Empty)
            {
                throw new DomainValidationException("Id is required.");
            }

            _state = new ProductState
            {
                Id = id
            };

            SetName(name);

            DomainEvents.Raise(new ProductCreated(this));
        }

        public ProductAggregate(ProductState state)
        {
            _state = state;
        }

        public Guid Id => _state.Id;

        public string Name => _state.Name;

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new DomainValidationException("Name is required.");
            }

            _state.Name = name;

            DomainEvents.Raise(new ProductNameChanged(this));
        }

        public void Remove()
        {
            if (_state.Removed)
            {
                throw new DomainValidationException("Product already removed.");
            }

            _state.Removed = true;

            DomainEvents.Raise(new ProductRemoved(this));
        }

        public void AddPart(PartAggregate part)
        {
            if (part == null)
            {
                throw new ArgumentNullException(nameof(part));
            }

            _state.Parts.Add(new ProductPartState
            {
                ProductId = Id,
                Product = GetInternalState(),
                PartId = part.Id,
                Part = part.GetInternalState()
            });

            DomainEvents.Raise(new PartAdded(this, part));
        }

        public void RemovePart(Part part)
        {
            if (part == null)
            {
                throw new ArgumentNullException(nameof(part));   
            }

            var existing = SafeGetPart(part.Id);

            var productPartState = _state.Parts.Single(x => x.PartId == part.Id);
            _state.Parts.Remove(productPartState);

            DomainEvents.Raise(new PartRemoved(this, existing));
        }

        public Part SafeGetPart(Guid partId)
        {
            var productPartState = _state.Parts.Select(x => x.Part).SingleOrDefault(x => x.Id == partId);
            if (productPartState == null)
            {
                throw new DomainValidationException($"Product does not have a part with id {partId}.");
            }

            return new Part(productPartState);
        }

        public ProductState GetInternalState()
        {
            return _state;
        }
    }
}
