using AutoMapper;
using Mlpp.Domain.Part.State;
using Mlpp.Domain.Product.State;
using Mlpp.QueryService.Product.Models;

namespace Mlpp.QueryService.Product
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductState, ProductModel>();
            CreateMap<PartState, PartModel>();
        }
    }
}
