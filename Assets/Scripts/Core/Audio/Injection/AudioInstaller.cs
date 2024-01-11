using FPS.Common.Injection;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace FPS.Audio
{
    public class AudioInstaller : ExposableInstaller
    {
        [SerializeField]
        private DialogueAudioPlayer dialogueAudioPlayer;

        protected override void InstallBindings(DiContainer container)
        {
            Assert.IsNotNull(dialogueAudioPlayer);

            container.Bind<IDialogueAudioPlayer>()
                .FromInstance(dialogueAudioPlayer)
                .AsSingle();
        }
    }
}