using System.Collections;
using UnityEngine;

namespace FPS.Common
{
    public class CoroutineRunner : MonoBehaviour
    {
        private static bool wasInitialized;
        private static MonoBehaviour holder;

        private static MonoBehaviour Holder
        {
            get
            {
                if (holder == null && !wasInitialized)
                {
                    GameObject holderObject = new GameObject(nameof(CoroutineRunner));
                    DontDestroyOnLoad(holderObject);
                    holderObject.hideFlags = HideFlags.HideInInspector;
                    holder = holderObject.AddComponent<CoroutineRunner>();
                    wasInitialized = true;
                }

                return holder;
            }
        }

        public static new Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return Holder.StartCoroutine(coroutine);
        }

        public static new void StopCoroutine(Coroutine coroutine)
        {
            if (Holder == null)
            {
                return;
            }

            Holder.StopCoroutine(coroutine);
        }

        public static new void StopAllCoroutines()
        {
            Holder.StopAllCoroutines();
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            wasInitialized = false;
        }
    }
}