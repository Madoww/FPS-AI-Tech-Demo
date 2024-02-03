using System;

namespace FPS.UI.Views
{
    [Serializable]
    public class ViewDefinition
    {
        public bool showOnInitialize;
        public bool showImmediately;
        public UiView view;
    }
}