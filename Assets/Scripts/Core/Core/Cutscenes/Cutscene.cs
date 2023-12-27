namespace FPS.Core.Cutscenes
{
    public class Cutscene
    {
        public ICutsceneNode RootNode { get; private set; }

        public Cutscene(ICutsceneNode rootNode)
        {
            RootNode = rootNode;
        }
    }
}