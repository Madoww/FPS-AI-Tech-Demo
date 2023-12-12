using UnityEngine;

namespace FPS.HI.Player
{
    public interface IPlayerMovementController
    {
        void Move(Vector3 direction);
    }
}