using UnityEditor;
using UnityEngine;

namespace Utilities 
{
    public static class Utilities 
    {
        public static T[] GetAllInstances<T>() where T : ScriptableObject
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);  //FindAssets uses tags check documentation for more info
            var a = new T[guids.Length];
            for (var i = 0; i < guids.Length; i++)         //probably could get optimized 
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
            }

            return a;
        }
    }

}
