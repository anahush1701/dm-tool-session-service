using SessionService.Models;

namespace SessionService.Interfaces
{
    public interface IUserCreationHandler
    {
        void CreatePlayerAndDm(UserReceivedDto userDto);
    }
}
