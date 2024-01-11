using UnityEngine;

namespace FPS.Core.Barks
{
    public abstract class BarkPresenter : MonoBehaviour
    {
        [SerializeField]
        private BarksController barksController;

        protected BarksController BarksController => barksController;

        private void Awake()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            Deinitialize();
        }

        protected abstract void OnTriggerBark(BarkData barkData);

        private void Initialize()
        {
            barksController.OnBarkTriggered += OnTriggerBark;
        }

        private void Deinitialize()
        {
            barksController.OnBarkTriggered -= OnTriggerBark;
        }
    }
}