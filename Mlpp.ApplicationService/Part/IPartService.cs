using Mlpp.ApplicationService.Part.Command;

namespace Mlpp.ApplicationService.Part
{
    public interface IPartService
    {
        void When(CreatePart command);

        void When(RemovePart command);

        void When(ChangePartName command);
    }
}