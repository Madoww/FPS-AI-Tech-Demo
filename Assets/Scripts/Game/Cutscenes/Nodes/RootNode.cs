using FPS.Core.Cutscenes;
using FPS.Core.Cutscenes.Data;

namespace FPS.Game.Cutscenes.Nodes
{
    public class RootNode : CutsceneNode<RootNodeData>
    {
        public override void Execute()
        {
            ExecuteChildren();
        }
    }
}