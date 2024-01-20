namespace FPS.Core.Cutscenes
{
    public interface ICutsceneDataProvider
    {
        string ReferenceGuid { get; }
        bool IsGuidSpecific { get; }
    }
}