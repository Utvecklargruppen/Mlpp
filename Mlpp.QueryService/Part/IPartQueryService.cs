using Mlpp.QueryService.Part.Models;
using System;
using System.Collections.Generic;

namespace Mlpp.QueryService.Part
{
    public interface IPartQueryService
    {
        PartModel GetPart(Guid id);

        IEnumerable<PartModel> GetParts();
    }
}