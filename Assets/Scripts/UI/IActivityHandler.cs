using System;

namespace FPS.UI
{
    public interface IActivityHandler : IDisposable
    {
        bool Shows { get; }
        bool Hides { get; }

        void Show(IActivityTarget target);
        void Hide(IActivityTarget target);
        void Show(IActivityTarget target, bool immediately, Action onFinish = null);
        void Hide(IActivityTarget target, bool immediately, Action onFinish = null);
    }
}