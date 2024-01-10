using FMOD.Studio;
using FMODUnity;
using FPS.Core.Levels;

namespace FPS.Presentation.Audio.Presenters
{
    public class LevelAudioPresenter : GameEntityAudioPresenter<LevelEntity>
    {
        private EventInstance ambientEventInstance;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            LevelData levelData = Entity.LevelData;
            EventReference ambientEventReference = levelData.ambienceMusic;
            ambientEventInstance = RuntimeManager.CreateInstance(ambientEventReference);
            ambientEventInstance.start();
        }
    }
}