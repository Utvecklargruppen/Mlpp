using System;

namespace Mlpp.ApplicationService.Part.Command
{
    public class ChangePartName : PartCommand
    {
        public ChangePartName(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; }
    }
}