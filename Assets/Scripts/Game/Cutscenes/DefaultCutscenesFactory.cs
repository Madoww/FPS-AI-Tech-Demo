using FPS.Core.Cutscenes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Game.Cutscenes
{
    public class DefaultCutscenesFactory : ICutsceneFactory
    {
        [SerializeReference, ReferencePicker, ReorderableList]
        private List<ICutsceneNode> cutsceneNodes;
        [SerializeReference, ReferencePicker]
        private IDataProvidersHandler providersHandler;

        public Cutscene CreateCutscene(CutsceneDefinition cutsceneDefinition)
        {
            var rootNodeData = cutsceneDefinition.rootNodeData;
            var rootNodeInstance = GetInstanceForData(rootNodeData);
            var rootNodeChildren = CreateNodesChildNodes(rootNodeData);
            rootNodeInstance.AddChildren(rootNodeChildren);

            Cutscene cutscene = new Cutscene(rootNodeInstance);
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

        private List<ICutsceneNode> CreateNodesChildNodes(CutsceneNodeData nodeData)
        {
            var childNodeDatas = nodeData.childNodes;
            var nodes = new List<ICutsceneNode>();
            foreach (CutsceneNodeData childNodeData in childNodeDatas)
            {
                var nodeInstance = GetInstanceForData(childNodeData);
                var instanceChildren = CreateNodesChildNodes(childNodeData);
                foreach (var childNode in instanceChildren)
                {
                    nodeInstance.AddChild(childNode);
                }

                nodeInstance.Setup(childNodeData);
                nodeInstance.Setup(providersHandler);
                nodes.Add(nodeInstance);
            }

            return nodes;
        }
    }
}