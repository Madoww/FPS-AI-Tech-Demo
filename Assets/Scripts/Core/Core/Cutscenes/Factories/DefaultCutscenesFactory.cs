using FPS.Core.Cutscenes.Data;
using FPS.Core.Cutscenes.Nodes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Cutscenes.Factories
{
    public class DefaultCutscenesFactory : ICutsceneFactory
    {
        [SerializeReference, ReferencePicker, ReorderableList]
        private List<ICutsceneNode> cutsceneNodes;
        [SerializeReference, ReferencePicker]
        private IDataProvidersHandler providersHandler;

        public Cutscene CreateCutscene(CutsceneDefinition cutsceneDefinition)
        {
            if (!cutsceneDefinition.GetNode<RootNodeData>(out var rootNodeData))
            {
                Debug.LogError("CutsceneDefinition doesn't have a root node.");
                return null;
            }

            var rootNodeInstance = GetInstanceForData(rootNodeData);
            var completeNodes = new List<ICutsceneNode>();
            var rootNodeChildren = CreateNodesChildNodes(rootNodeData, completeNodes);
            rootNodeInstance.AddChildren(rootNodeChildren);

            Cutscene cutscene = new Cutscene(rootNodeInstance, completeNodes);
            return cutscene;
        }

        private ICutsceneNode GetInstanceForData(CutsceneNodeData nodeData)
        {
            var nodeDataType = nodeData.GetType();
            foreach (ICutsceneNode cutsceneNode in cutsceneNodes)
            {
                if (cutsceneNode.DataType == nodeDataType)
                {
                    var cutsceneNodeType = cutsceneNode.GetType();
                    var nodeInstance = Activator.CreateInstance(cutsceneNodeType) as ICutsceneNode;
                    nodeInstance.Setup(nodeData);
                    return nodeInstance;
                }
            }

            return null;
        }

        private List<ICutsceneNode> CreateNodesChildNodes(CutsceneNodeData nodeData, in List<ICutsceneNode> completeNodes)
        {
            var childNodeDatas = nodeData.childNodes;
            var nodes = new List<ICutsceneNode>();
            foreach (CutsceneNodeData childNodeData in childNodeDatas)
            {
                var nodeInstance = GetInstanceForData(childNodeData);
                var instanceChildren = CreateNodesChildNodes(childNodeData, completeNodes);
                foreach (var childNode in instanceChildren)
                {
                    nodeInstance.AddChild(childNode);
                }

                nodeInstance.Setup(childNodeData);
                nodeInstance.Setup(providersHandler);
                nodes.Add(nodeInstance);
                if (nodeInstance is CompleteCutsceneNode)
                {
                    completeNodes.Add(nodeInstance);
                }
            }

            return nodes;
        }
    }
}