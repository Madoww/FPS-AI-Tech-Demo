using UnityEngine;

namespace FPS.HI.Player
{
    public class PlayerMovementController : MonoBehaviour, IPlayerMovementController
    {
        [SerializeReference]
        private CharacterController characterController;
        [SerializeField]
        private float speed;

        public void Move(Vector3 direction)
        {
            Vector3 movementVector3D = new Vector3(direction.x, 0, direction.y);
            var playerTransform = characterController.transform;
            var actualDirection = playerTransform.TransformDirection(movementVector3D);
            characterController.Move(actualDirection * speed * Time.deltaTime);
        }
    }
}