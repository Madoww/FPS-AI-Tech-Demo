using UnityEngine;

namespace FPS.HI.Player
{
    public interface IPlayerCameraController
    {
        void ProcessLook(Vector2 input);
    }
}