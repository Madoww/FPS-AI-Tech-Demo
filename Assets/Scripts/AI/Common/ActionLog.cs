namespace FPS.AI.Common
{
    using FPS.AI.Behaviour;

    public class ActionLog : Node
    {
        private string message;

        public ActionLog(string message)
        {
            this.message = message;
        }

        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            //Debug.Log(message);
            return NodeState.Running;
        }
    }
}