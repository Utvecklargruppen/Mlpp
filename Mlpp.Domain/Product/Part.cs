using Mlpp.Domain.Product.Events;
using Mlpp.Domain.Product.States;
using Mlpp.Domain;

namespace Mlpp.Domain.Product
{
    public class Part : IStateObject<PartState>
    {
        private readonly PartState _state;

        public Part(string name)
        {
            _state = new PartState();

            SetName(name);
        }

        public string Name => _state.Name;

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new DomainValidationException("Part name is required.");
            }

            _state.Name = name;

            DomainEvents.Raise(new PartNameChanged(this));
        }

        public PartState GetInternalState()
        {
            return _state;
        }
    }
}
