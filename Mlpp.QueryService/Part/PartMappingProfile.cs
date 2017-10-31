using AutoMapper;
using Mlpp.Domain.Part.State;
using Mlpp.QueryService.Part.Models;

namespace Mlpp.QueryService.Part
{
    public class PartMappingProfile : Profile
    {
        public PartMappingProfile()
        {
            CreateMap<PartState, PartModel>();
        }
    }
}
