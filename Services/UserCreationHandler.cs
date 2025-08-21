using SessionService.Interfaces;
using SessionService.Models;

namespace SessionService.Services
{
    public class UserCreationHandler : IUserCreationHandler
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IDMRepository _dungeonMasterRepository;

        public UserCreationHandler(IPlayerRepository playerRepository, IDMRepository dungeonMasterRepository)
        {
            _playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            _dungeonMasterRepository = dungeonMasterRepository ?? throw new ArgumentNullException(nameof(dungeonMasterRepository));
        }

        public void CreatePlayerAndDm(UserReceivedDto userDto)
        {
            var player = new Player()
            {
                Name = userDto.UserName,
                UserId = userDto.UserId,
            };

            var dm = new DungeonMaster()
            {
                Name = userDto.UserName,
                UserId = userDto.UserId,
            };

            _playerRepository.AddPlayer(player);
            _dungeonMasterRepository.AddDM(dm);
        }
    }
}
