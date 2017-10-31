using System;
using Mlpp.Domain.Part.State;
using Mlpp.Domain.Product.State;

namespace Mlpp.Domain.Product
{
    public class Part : IStateObject<PartState>
    {
        private readonly PartState _state;

        public Part(PartState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public Guid Id => _state.Id;
        public string Name => _state.Name;

        public PartState GetInternalState()
        {
            return _state;
        }
    }
}
