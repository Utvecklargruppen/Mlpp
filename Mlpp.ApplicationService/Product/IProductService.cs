﻿using Mlpp.ApplicationService.Product.Command;

namespace Mlpp.ApplicationService.Product
{
    public interface IProductService
    {
        void When(CreateProduct command);
        void When(ChangeProductName command);
    }
}