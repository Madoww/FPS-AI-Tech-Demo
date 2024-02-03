using System;

namespace FPS.UI.Views
{
    public interface IUiViewsHandler
    {
        event Action<UiView> OnShowView;
        event Action<UiView> OnHideView;

        void Show<T>() where T : UiView;
        void Show(Type type);
        void Show(UiView view);
        void Hide<T>() where T : UiView;
        void Hide(Type type);
        void Hide(UiView view);
    }
}