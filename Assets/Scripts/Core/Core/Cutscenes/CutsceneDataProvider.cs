using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Cutscenes
{
    public class CutsceneDataProvider : ICutsceneDataProvider
    {
        [SerializeField]
        private string referenceGuid;

        public bool IsGuidSpecific => !string.IsNullOrEmpty(referenceGuid);
        public string ReferenceGuid => referenceGuid;
    }
}