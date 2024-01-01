using FPS.Core.Cutscenes.Data;

namespace FPS.Core.Cutscenes.Nodes
{
    public class CompleteCutsceneNode : CutsceneNode<CompleteCutsceneNodeData>
    {
        public override void Execute()
        {
            Complete();
        }
    }
}
