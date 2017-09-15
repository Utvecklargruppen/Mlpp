using System;
using System.Linq;
using Mlpp.Domain.Product.Events;
using Mlpp.Domain.Product.States;

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

        public void AddPart(Part part)
        {
            if (_state.Parts.Any(x => x.Name == part.Name))
            {
                throw new DomainValidationException($"Part {part.Name} already exists.");
            }

            _state.Parts.Add(part.GetInternalState());

            DomainEvents.Raise(new PartAdded(this, part));
        }

        public ProductState GetInternalState()
        {
            return _state;
        }
    }
}
