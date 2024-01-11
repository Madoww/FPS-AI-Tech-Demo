using UnityEngine;

namespace FPS.Core.Barks.Presenters
{
    //TODO: Add proper ui presenter for barks.
    public class BarkUiPresenter : BarkPresenter
    {
        protected override void OnTriggerBark(BarkData barkData)
        {
            var barkText = barkData.LocalizedText;
            Debug.Log($"Bark: {barkText}");
        }
    }
}