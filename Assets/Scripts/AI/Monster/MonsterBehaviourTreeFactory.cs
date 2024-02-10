using UnityEngine;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;
    using FPS.AI.Behaviour.Data;
    using System;
    using System.Collections.Generic;

    public class MonsterBehaviourTreeFactory : IBehaviourTreeFactory
    {
        //[SerializeField]
        //private AiBrain aiBrain;
        //[SerializeField]
        //private NavMeshAgent navMeshAgent;
        //[SerializeField]
        //private Transform playerTransform;
        //[SerializeField]
        //private Transform selfTransform;
        //[SerializeField]
        //private PatrolDataProvider patrolDataProvider;

        [SerializeField]
        private BehaviourTreeDefinition treeDefinition;
        [SerializeField]
        private NodeImplementationsHolder implementationsHolder;

        public BehaviourTree Build()
        {
            if (!treeDefinition.GetNode<RootNodeData>(out var rootNodeData))
            {
                Debug.LogError($"{nameof(BehaviourTreeDefinition)} doesn't have a root node.");
                return null;
            }

            var rootNodeInstance = GetInstanceForData(rootNodeData);
            var rootNodeChildren = CreateNodesChildNodes(rootNodeData);
            rootNodeInstance.AddChildren(rootNodeChildren);

            BehaviourTree behaviourTree = new BehaviourTree(rootNodeInstance);
            return behaviourTree;
        }

        private IBehaviourNode GetInstanceForData(BehaviourNodeData nodeData)
        {
            var nodeDataType = nodeData.GetType();
            var implementations = implementationsHolder.NodeImplementations;
            foreach (IBehaviourNode cutsceneNode in implementations)
            {
                if (cutsceneNode.DataType == nodeDataType)
                {
                    var cutsceneNodeType = cutsceneNode.GetType();
                    var nodeInstance = Activator.CreateInstance(cutsceneNodeType) as IBehaviourNode;
                    nodeInstance.Setup(nodeData);
                    //nodeInstance.Setup(providersHandler);
                    return nodeInstance;
                }
            }

            return null;
        }

        private List<IBehaviourNode> CreateNodesChildNodes(BehaviourNodeData nodeData)
        {
            var childNodeDatas = nodeData.childNodes;
            var nodes = new List<IBehaviourNode>();
            foreach (BehaviourNodeData childNodeData in childNodeDatas)
            {
                var nodeInstance = GetInstanceForData(childNodeData);
                var instanceChildren = CreateNodesChildNodes(childNodeData);
                foreach (var childNode in instanceChildren)
                {
                    nodeInstance.AddChild(childNode);
                }

                nodes.Add(nodeInstance);
            }

            return nodes;
        }
    }
}