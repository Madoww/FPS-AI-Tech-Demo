using UnityEngine;
using Zenject;

namespace FPS.Gameplay
{
    using FPS.HI.Input;

    public class TemporaryState : MonoBehaviour
    {
        private IPlayerInputHandler inputHandler;

        [Inject]
        internal void Bind(IPlayerInputHandler inputHandler)
        {
            this.inputHandler = inputHandler;
            inputHandler.Enable();
        }
    }
}