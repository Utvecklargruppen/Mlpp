using System;
using Mlpp.Domain;
using Mlpp.Infrastructure.Storage;

namespace Mlpp.ApplicationService
{
    public abstract class BaseApplicationService<TContext, TAggregate, TId>
    {
        private readonly IUnitOfWork<TContext> _uow;

        protected BaseApplicationService(IUnitOfWork<TContext> uow, IReadableRepository<TAggregate, TId> repo)
        {
            _uow = uow;
            Repo = repo;
        }

        protected IReadableRepository<TAggregate, TId> Repo { get; }

        protected void Execute<TCommand>(TCommand cmd, Action operation)
        {
            if (cmd == null) throw new ArgumentNullException();

            ExecuteInternal(cmd, operation);
        }

        protected void Execute<TCommand>(TCommand cmd, Action<TAggregate> operation) where TCommand : IAggregateCommand<TId>
        {
            if (cmd == null) throw new ArgumentNullException();

            var aggregate = Repo.SafeGetById(cmd.Id);

            ExecuteInternal(cmd, () => operation(aggregate));
        }

        private void ExecuteInternal<TCommand>(TCommand cmd, Action operation)
        {
            try
            {
                operation();

                _uow.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine("Command " + nameof(cmd) + " caused exception " + e.Message);
                throw new ApplicationServiceException(e.Message);
            }
        }
    }
}
