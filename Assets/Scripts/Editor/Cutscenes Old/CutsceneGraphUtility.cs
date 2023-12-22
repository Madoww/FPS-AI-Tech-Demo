using FPS.CutscenesOldOld;

namespace FPS.Editor.CutscenesOldOld
{
    internal static class CutsceneGraphUtility
    {
        private static readonly CutsceneGraphFactory defaultFactory = new CutsceneGraphFactory();

        public static StateMachineGraphView CreateGraph(CutsceneDefinition selectedCutscene, in GraphSettings graphSettings)
        {
            return defaultFactory.CreateGraph(selectedCutscene, graphSettings);
        }
        //
        //public static StateMachineGraphView CreateGraph(IStateMachine stateMachine, in GraphSettings graphSettings, StateMachineGraphView graphView)
        //{
        //    return defaultFactory.CreateGraph(stateMachine, in graphSettings, graphView);
        //}
    }
}