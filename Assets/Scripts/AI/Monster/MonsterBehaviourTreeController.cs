using UnityEngine;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;

    public class MonsterBehaviourTreeController : MonoBehaviour
    {
        [SerializeReference, ReferencePicker]
        private IBehaviourTreeBuilder behaviourTreeBuilder;

        private BehaviourTree behaviourTree;

        private void Awake()
        {
            behaviourTree = behaviourTreeBuilder.Build();
        }

        private void Update()
        {
            behaviourTree.Tick();
        }
    }
}