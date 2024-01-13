using UnityEngine;

namespace FPS.Core.Player
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField]
        private PlayerEntity playerEntity;

        public PlayerEntity PlayerEntity => playerEntity;
    }
}