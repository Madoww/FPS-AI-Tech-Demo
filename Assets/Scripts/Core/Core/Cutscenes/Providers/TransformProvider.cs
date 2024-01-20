using UnityEngine;

namespace FPS.Core.Cutscenes.Providers
{
    public class TransformProvider : CutsceneDataProvider
    {
        [SerializeField]
        private Transform transform;

        public Transform Transform => transform;
    }
}