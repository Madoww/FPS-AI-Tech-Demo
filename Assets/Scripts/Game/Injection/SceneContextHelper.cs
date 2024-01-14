using UnityEngine;
using Zenject;

namespace FPS.Game.Injection
{
    [DefaultExecutionOrder(-10000)]
    [RequireComponent(typeof(SceneContext))]
    public class SceneContextHelper : MonoBehaviour
    {
        [SerializeField]
        private SceneContext sceneContext;

        [SerializeField, ReorderableList]
        private GameObjectContext[] objectsToQueue;

        private void Awake()
        {
            sceneContext.OnPreInstall.AddListener(OnPreInstall);
        }

        private void QueueObjects()
        {
            var container = sceneContext.Container;
            foreach (var target in objectsToQueue)
            {
                if (target == null)
                {
                    continue;
                }

                container.QueueForInject(target);
            }
        }

        private void OnPreInstall()
        {
            QueueObjects();
        }
    }
}
