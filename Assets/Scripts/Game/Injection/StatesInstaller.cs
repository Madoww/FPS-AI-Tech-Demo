using Zenject;

namespace FPS.Game.Injection
{
    using FPS.Common.States;
    //TODO: Add flow builder
    using FPS.Game.Flow.Gameplay;

    public class StatesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //TODO: add a flow builder
            BaseState[] states =
            {
                new GeneralState()
            };

            Container.Bind<BaseState>().
                FromMethodMultiple((context) =>
                {
                    var container = context.Container;
                    foreach (var state in states)
                    {
                        container.QueueForInject(state);
                    }

                    return states;
                });
        }
    }
}