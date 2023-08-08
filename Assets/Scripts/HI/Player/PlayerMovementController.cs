using UnityEngine;

namespace FPS.HI.Input
{
    public class PlayerMovementController : MonoBehaviour, IPlayerMovementController
    {
        [SerializeReference]
        private CharacterController characterController;
        [SerializeField]
        private float speed;

        public void Move(Vector3 direction)
        {
            characterController.Move(direction * speed);
        }
    }
}