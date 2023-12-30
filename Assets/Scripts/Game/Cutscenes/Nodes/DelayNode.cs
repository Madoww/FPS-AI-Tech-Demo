using FPS.Common;
using FPS.Core.Cutscenes;
using FPS.Core.Cutscenes.Data;
using System.Collections;
using UnityEngine;

namespace FPS.Game.Cutscenes.Nodes
{
    public class DelayNode : CutsceneNode<DelayNodeData>
    {
        public override void Execute()
        {
            CoroutineRunner.StartCoroutine(WaitToComplete());
        }

        private IEnumerator WaitToComplete()
        {
            var secondsToWait = Data.seconds;
            yield return new WaitForSeconds(secondsToWait);
            Complete();
        }
    }
}