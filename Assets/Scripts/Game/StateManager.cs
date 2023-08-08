using FPS.Common.States;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FPS.Game
{
    public class StateManager : MonoBehaviour
    {
        private GeneralStateMachine stateMachine;

        private void Start()
        {
            stateMachine.Start();
        }

        private void Update()
        {
            stateMachine.Tick();
        }

        [Inject]
        internal void Bind(BaseState[] states)
        {
            stateMachine = new GeneralStateMachine(new List<BaseState>(states), states[0]);
        }
    }
}