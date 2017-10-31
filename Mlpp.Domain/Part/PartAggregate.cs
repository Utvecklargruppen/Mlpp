using Mlpp.Domain.Part.State;
using System;

namespace Mlpp.Domain.Part
{
    public class PartAggregate : IAggregate<PartState, Guid>
    {
        private readonly PartState _state;

        public PartAggregate(Guid id, string name)
        {
            _state = new PartState {Id = id};

            SetName(name);
        }

        public PartAggregate(PartState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public Guid Id => _state.Id;
        public string Name => _state.Name;

        public PartState GetInternalState()
        {
            return _state;
        }

        public void Remove()
        {
            if (_state.Removed)
            {
                throw new DomainValidationException("Part already removed.");
            }

            _state.Removed = true;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainValidationException("Part name is required.");
            }

            _state.Name = name;
        }
    }
}