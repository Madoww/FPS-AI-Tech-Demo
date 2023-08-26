using Zenject;

namespace FPS.AI
{
    using FPS.Common.Injection;

    public class AiInstaller : ExposableInstaller
    {
        //[SerializeReference, ReferencePicker]
        //private IPatrolDataProvider patrolDataProvider;
        //
        protected override void InstallBindings(DiContainer container)
        {
            //    container.Bind<IPatrolDataProvider>()
            //        .FromInstance(patrolDataProvider)
            //        .AsSingle();
        }
    }
}