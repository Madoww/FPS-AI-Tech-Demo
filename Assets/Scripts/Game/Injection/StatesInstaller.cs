using FPS.Game.Flow;
using UnityEngine;
using Zenject;

namespace FPS.Game.Injection
{

    public class StatesInstaller : MonoInstaller
    {
        [SerializeReference, ReferencePicker]
        private IFlowBuilder flowBuilder;

        public override void InstallBindings()
        {
            Container.Bind<MasterState>().
                FromMethodMultiple((context) =>
                {
                    var states = flowBuilder.Build(out var linkedStates);
                    var container = context.Container;
                    foreach (var state in linkedStates)
                    {
                        container.QueueForInject(state);
                    }

                    return states;
                });
        }
    }
}