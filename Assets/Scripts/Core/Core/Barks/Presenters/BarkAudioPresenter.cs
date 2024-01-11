using FPS.Audio;
using Zenject;

namespace FPS.Core.Barks.Presenters
{
    //TODO: Support spacial barks.
    public class BarkAudioPresenter : BarkPresenter
    {
        private IDialogueAudioPlayer dialogueAudioPlayer;

        [Inject]
        internal void Bind(IDialogueAudioPlayer dialogueAudioPlayer)
        {
            this.dialogueAudioPlayer = dialogueAudioPlayer;
        }

        protected override void OnTriggerBark(BarkData barkData)
        {
            var audioName = barkData.audioName;
            dialogueAudioPlayer.PlayDialogue(audioName);
        }
    }
}