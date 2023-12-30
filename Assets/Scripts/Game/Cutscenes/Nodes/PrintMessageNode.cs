using FPS.Core.Cutscenes;
using FPS.Core.Cutscenes.Data;
using UnityEngine;

namespace FPS.Game.Cutscenes.Nodes
{
    public class PrintMessageNode : CutsceneNode<PrintMessageNodeData>
    {
        public override void Execute()
        {
            Debug.Log(Data.message);
            Complete();
        }
    }
}