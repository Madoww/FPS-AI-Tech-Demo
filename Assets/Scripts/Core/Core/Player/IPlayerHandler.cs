using FPS.Common;

namespace FPS.Core.Player
{
    public interface IPlayerHandler : IInitializable<PlayerModel>, IDeinitializable
    {
        void Update();
    }
}