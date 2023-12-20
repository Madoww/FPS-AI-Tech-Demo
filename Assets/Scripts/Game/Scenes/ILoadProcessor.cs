using System;
using UnityEngine;

namespace FPS.Game.Scenes
{
    public interface ILoadProcessor
    {
        event Action OnFinished;

        bool IsLoading { get; }
        float Progress { get; }

        Coroutine LoadDefinition(SceneDefinition sceneDefinition, in SceneDefinitionLoadSettings loadSettings);
    }
}