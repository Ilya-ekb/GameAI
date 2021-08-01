using System;
using UnityEngine;

namespace Models.Resources
{
    [Serializable]
    public class Resource : IResource
    {
        public ResourceType ResourceType => resourceType;

        public float Count => count;

        [SerializeField] private ResourceType resourceType;
        [SerializeField] private float count;
    }
}
