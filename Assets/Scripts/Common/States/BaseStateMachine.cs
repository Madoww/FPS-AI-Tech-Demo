using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Common.States
{
    public class BaseStateMachine : IStateMachine
    {
        public BaseState CurrentState { get; private set; }

        private readonly BaseState startState;
        private readonly Dictionary<Type, BaseState> statesByType;

        public event Action<BaseState> OnStateChanged;

        public BaseStateMachine(List<BaseState> states, BaseState startState)
        {
            this.startState = startState;
            statesByType = new Dictionary<Type, BaseState>();
            for (int i = 0; i < states.Count; i++)
            {
                AppendState(states[i]);
            }
        }

        public void Start()
        {
            ChangeState(startState);
        }

        public void Tick()
        {
            if (CurrentState == null)
            {
                return;
            }

            CurrentState.Tick();
            if (!CurrentState.WantsToClose())
            {
                return;
            }

            var destinations = CurrentState.Destinations;
            foreach (var destination in destinations)
            {
                if (TryGetState(destination, out BaseState state))
                {
                    if (state.WantsToBegin())
                    {
                        ChangeState(state);
                    }
                }
                else
                {
                    Debug.LogWarning($"[States] Can't find state: {destination.Name}");
                }
            }
        }

        public void ChangeState(BaseState state)
        {
            ChangeState(state.Type);
        }

        public void ChangeState(Type newStateType)
        {
            if (!statesByType.TryGetValue(newStateType, out var newState))
            {
                return;
            }

            CurrentState?.Close();
            CurrentState = newState;
            CurrentState.Begin();
            OnStateChanged?.Invoke(CurrentState);
        }

        private void AppendState(BaseState state)
        {
            var stateType = state.Type;
            if (statesByType.ContainsKey(stateType))
            {
                Debug.LogWarning($"[States] state {stateType} already exists in state machine.");
                return;
            }

            statesByType.Add(stateType, state);
        }

        private bool TryGetState(Type stateType, out BaseState state)
        {
            return statesByType.TryGetValue(stateType, out state);
        }
    }
}