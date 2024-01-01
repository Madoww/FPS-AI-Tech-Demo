using FPS.Core.Cutscenes.Data;

namespace FPS.Core.Cutscenes.Nodes
{
    public class RootNode : CutsceneNode<RootNodeData>
    {
        public override void Execute()
        {
            ExecuteChildren();
        }
    }
}