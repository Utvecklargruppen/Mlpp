using System;

namespace Mlpp.ApplicationService.Part.Command
{
    public class RemovePart : PartCommand
    {
        public RemovePart(Guid id) : base(id)
        {
        }
    }
}