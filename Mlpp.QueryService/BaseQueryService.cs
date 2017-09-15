using System.Collections.Generic;
using AutoMapper;
using Mlpp.Infrastructure.Storage.Mlpp;

namespace Mlpp.QueryService
{
    public abstract class BaseQueryService
    {
        private readonly IReadOnlyMlppContext _context;
        private readonly IMapper _mapper;

        protected BaseQueryService(IReadOnlyMlppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected TModel Execute<TModel>(IQuery<TModel> query)
        {
            return query.Execute(_context);
        }

        protected TMappedResult Execute<TMappedResult, TQueryResult>(IQuery<TQueryResult> query)
        {
            var result = query.Execute(_context);
            return _mapper.Map<TQueryResult, TMappedResult>(result);
        }

        protected IEnumerable<TMappedResult> Execute<TMappedResult, TQueryResult>(IQuery<IEnumerable<TQueryResult>> query)
        {
            var result = query.Execute(_context);
            return _mapper.Map<IEnumerable<TQueryResult>, IEnumerable<TMappedResult>>(result);
        }
    }
}
