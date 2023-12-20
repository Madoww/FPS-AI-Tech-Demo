using UnityEditor;
using UnityEngine;

namespace FPS.Common
{
    public static class AssetUtility
    {
        public static T GetFirstAsset<T>() where T : ScriptableObject
        {
            T asset = null;
#if UNITY_EDITOR
            var guids = AssetDatabase.FindAssets($"t:{typeof(T).Name}");
            if (guids == null || guids.Length == 0)
            {
                return null;
            }

            var firstGuid = guids[0];
            var path = AssetDatabase.GUIDToAssetPath(firstGuid);
            asset = AssetDatabase.LoadAssetAtPath<T>(path);
#endif
            return asset;
        }
    }
}