using UnityEngine;

namespace FPS.Core.Barks.Processors
{
    public abstract class TestBarkProcessor : BarkProcessor
    {
        public override void Process()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Trigger();
            }
        }
    }
}