using UnityEngine;

namespace FPS.Core.Cutscenes.Providers
{
    public class TransformProvider : ICutsceneDataProvider
    {
        [SerializeField]
        private Transform transform;

        public Transform Transform => transform;
    }
}