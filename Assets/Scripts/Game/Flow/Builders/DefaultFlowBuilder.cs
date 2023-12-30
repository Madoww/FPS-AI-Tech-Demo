using FPS.Game.Flow.Gameplay;
using System.Collections.Generic;

namespace FPS.Game.Flow.Builders
{
    public class DefaultFlowBuilder : IFlowBuilder
    {
        public MasterState[] Build(out List<BaseState> linkedStates)
        {
            linkedStates = new List<BaseState>();
            var gameplayStates = CreateGameplayStates();

            linkedStates.AddRange(gameplayStates);

            var masterStates = new MasterState[]
            {
                new MasterGameplayState(gameplayStates)
            };

            return masterStates;
        }

        private BaseState[] CreateGameplayStates()
        {
            var generalState = new GeneralState();
            generalState.AppendDestination<CutsceneState>();

            var cutsceneState = new CutsceneState();
            cutsceneState.AppendDestination<GeneralState>();

            return new BaseState[]
            {
                generalState,
                cutsceneState
            };
        }
    }
}