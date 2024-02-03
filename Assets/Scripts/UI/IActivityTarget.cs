using System;

namespace FPS.UI
{
    public interface IActivityTarget
    {
        event Action OnShow;
        event Action OnHide;

        bool IsActive { get; }

        void SetActive(bool value);
    }
}