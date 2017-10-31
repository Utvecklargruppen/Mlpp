using System;

namespace Mlpp.ApplicationService.Part.Command
{
    public class CreatePart : PartCommand
    {
        public CreatePart(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; }
    }
}