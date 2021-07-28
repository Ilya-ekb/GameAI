using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.CharacterResources
{
    public interface ICharacterResource
    {
        ResourceType ResourceType { get; }
        float Count { get; }
    }

    public enum ResourceType
    {
        Medicines
    }
}
