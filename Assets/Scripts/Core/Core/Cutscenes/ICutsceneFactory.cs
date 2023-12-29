namespace FPS.Core.Cutscenes
{
    public interface ICutsceneFactory
    {
        Cutscene CreateCutscene(CutsceneDefinition cutsceneDefinition);
    }
}