using System;
using Microsoft.AspNetCore.Mvc;
using Mlpp.ApplicationService.Part;
using Mlpp.ApplicationService.Part.Command;
using Mlpp.QueryService.Part;

namespace Mlpp.Controllers
{
    [Route("api/[controller]")]
    public class PartController : Controller
    {
        private readonly IPartService _partService;
        private readonly IPartQueryService _partQueryService;

        public PartController(IPartService partService, IPartQueryService partQueryService)
        {
            _partService = partService;
            _partQueryService = partQueryService;
        }

        [HttpDelete("{id}")]
        public void Delete(Guid? partId)
        {
            _partService.When(new RemovePart(partId.GetValueOrDefault()));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_partQueryService.GetParts());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid? id)
        {
            return Ok(_partQueryService.GetPart(id.GetValueOrDefault()));
        }

        [HttpPost]
        public IActionResult Post([FromBody]string name)
        {
            var id = Guid.NewGuid();

            _partService.When(new CreatePart(id, name));

            return CreatedAtAction("Post", id);
        }
    }
}
