using AutoMapper;
using Mlpp.Domain.Product.States;
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
