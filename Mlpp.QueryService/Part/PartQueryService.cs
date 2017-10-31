using AutoMapper;
using Mlpp.Infrastructure.Storage.Mlpp;
using Mlpp.QueryService.Part.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mlpp.QueryService.Part
{
    public class PartQueryService : IPartQueryService
    {
        private readonly IReadOnlyMlppContext _context;
        private readonly IMapper _mapper;

        public PartQueryService(IReadOnlyMlppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PartModel GetPart(Guid id)
        {
            return _mapper.Map<PartModel>(_context.Parts.SingleOrDefault(x => x.Id == id));
        }

        public IEnumerable<PartModel> GetParts()
        {
            return _mapper.Map<IEnumerable<PartModel>>(_context.Parts.ToList());
        }
    }
}