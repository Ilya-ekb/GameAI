using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models.Resources
{
    public interface IResource
    {
        ResourceType ResourceType { get; }
        float Count { get; }
    }

    public enum ResourceType
    {
        None,
        Food,
        Medicines
    }
}
