using Mlpp.ApplicationService.Part.Command;
using Mlpp.Domain.Part;
using Mlpp.Infrastructure.Storage.Mlpp;
using System;

namespace Mlpp.ApplicationService.Part
{
    public class PartService : IPartService
    {
        private readonly IPartRepository _partRepo;

        public PartService(IMlppUnitOfWork uow, IPartRepository partRepo)
        {
            _partRepo = partRepo;
        }

        public void When(CreatePart command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var part = new PartAggregate(command.AggregateId, command.Name);
            _partRepo.Insert(part);
        }

        public void When(RemovePart command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var part = _partRepo.GetById(command.AggregateId);
            part.Remove();
        }

        public void When(ChangePartName command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var part = _partRepo.GetById(command.AggregateId);
            part.SetName(command.Name);
        }
    }
}