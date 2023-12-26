using FPS.Core.Cutscenes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Game.Cutscenes
{
    public class DefaultCutscenesFactory : ICutscenesFactory
    {
        [SerializeReference, ReferencePicker]
        private List<ICutsceneNode> cutsceneNodes;

        public Cutscene CreateCutscene(CutsceneDefinition cutsceneDefinition)
        {
            var runtimeNodes = new List<ICutsceneNode>();
            var nodeDatas = cutsceneDefinition.Nodes;
            foreach (var nodeData in nodeDatas)
            {
                var node = GetInstanceForData(nodeData);
                runtimeNodes.Add(node);
            }

            Cutscene cutscene = new Cutscene(runtimeNodes[0]);
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
    }
}