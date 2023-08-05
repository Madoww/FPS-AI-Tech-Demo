using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace FPS.HI.Input.Handlers
{
    using FPS.HI.Input;
    using static FPS.HI.Input.PlayerControls;

    public class PlayerInputHandler : IPlayerInputHandler
    {
        private PlayerControls playerControls;
        private IPlayerMovementController playerMovementController;

        public void Enable()
        {
            playerControls.OnFoot.Enable();
        }

        public void Disable()
        {
            playerControls.OnFoot.Disable();
        }

        [Inject]
        internal void Bind(PlayerControls playerControls, IPlayerMovementController playerMovementController)
        {
            this.playerControls = playerControls;
            this.playerMovementController = playerMovementController;
            playerControls.OnFoot.SetCallbacks(this);
        }

        void IOnFootActions.OnMovement(InputAction.CallbackContext context)
        {
            Vector2 movementVector = context.ReadValue<Vector2>();
            Vector3 movementVector3D = new Vector3(movementVector.x, 0, movementVector.y);
            playerMovementController.Move(movementVector3D);
        }
    }
}