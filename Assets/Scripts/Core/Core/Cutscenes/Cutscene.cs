using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Cutscenes
{
    public class Cutscene
    {
        public event Action OnComplete;

        private ICutsceneNode rootNode;
        private IList<ICutsceneNode> completeNodes;

        public Cutscene(ICutsceneNode rootNode, IList<ICutsceneNode> completeNodes)
        {
            this.rootNode = rootNode;
            this.completeNodes = completeNodes;
        }

        public void Play()
        {
            InitializeCompleteNodes();
            rootNode.Execute();
        }

        public void Complete()
        {
            Debug.Log("Completed cutscene");
            DeinitializeCompleteNodes();
            OnComplete?.Invoke();
        }

        private void InitializeCompleteNodes()
        {
            foreach (var node in completeNodes)
            {
                node.OnCompleted += Complete;
            }
        }

        private void DeinitializeCompleteNodes()
        {
            foreach (var node in completeNodes)
            {
                node.OnCompleted -= Complete;
            }
        }
    }
}