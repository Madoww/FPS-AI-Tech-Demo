using UnityEngine;
using Zenject;

namespace FPS.Game.Flow
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
        internal void Bind(MasterState[] states)
        {
            stateMachine = new GeneralStateMachine(states);
        }
    }
}