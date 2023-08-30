using UnityEngine;

namespace FPS.AI.Behaviour
{
    public class BehaviourTreeState
    {
        private SerializedDictionary<string, object> data;

        public BehaviourTreeState()
        {
            data = new SerializedDictionary<string, object>();
        }

        public void SetData(string key, object value)
        {
            if (!data.ContainsKey(key))
            {
                data.Add(key, value);
                return;
            }

            data[key] = value;
        }

        public bool TryGetData<T>(string key, out T value)
        {
            if (data.ContainsKey(key))
            {
                value = (T)data[key];
                return true;
            }

            value = default;
            return false;
        }
    }
}