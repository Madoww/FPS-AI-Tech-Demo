using UnityEngine;

namespace FPS.HI.Input
{
    public interface IPlayerMovementController
    {
        void Move(Vector3 direction);
    }
}