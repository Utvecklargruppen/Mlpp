using Mlpp.ApplicationService.Part.Command;
using Mlpp.Domain.Part;
using Mlpp.Infrastructure.Storage.Mlpp;
using System;

namespace Mlpp.ApplicationService.Part
{
    public class PartService : BaseApplicationService<PartAggregate, Guid>, IPartService
    {
        private readonly IPartRepository _partRepo;

        public PartService(IMlppUnitOfWork uow, IPartRepository partRepo) : base(uow, partRepo)
        {
            _partRepo = partRepo;
        }

        public void When(CreatePart command)
        {
            Execute(command, () =>
            {
                var part = new PartAggregate(command.AggregateId, command.Name);
                _partRepo.Insert(part);
            });
        }

        public void When(RemovePart command)
        {
            Execute(command, part => part.Remove());
        }

        public void When(ChangePartName command)
        {
            Execute(command, part => part.SetName(command.Name));
        }
    }
}