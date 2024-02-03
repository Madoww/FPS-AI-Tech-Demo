using System.Collections.Generic;

namespace FPS.UI.Management
{
    public interface IUiManager
    {
        IReadOnlyList<IUiHandler> Handlers { get; }
    }
}