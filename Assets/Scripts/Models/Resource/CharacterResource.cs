using System;
using UnityEngine;

namespace Models.Resources
{
    [Serializable]
    public class Resource : ScriptableObject, IResource
    {
        public ResourceType ResourceType => resourceType;
        public float MaxValue => maxValue;
        public float MinValue => minValue;

        [SerializeField] private ResourceType resourceType;
        [SerializeField] private float maxValue;
        [SerializeField] private float minValue;
    }
}
