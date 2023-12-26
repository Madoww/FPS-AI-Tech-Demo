namespace FPS.Core.Cutscenes
{
    public class Cutscene
    {
        private ICutsceneNode rootNode;

        public Cutscene(ICutsceneNode rootNode)
        {
            this.rootNode = rootNode;
        }
    }
}