using UnityEngine;

namespace Character.CharacterResources
{
    public class CharacterResource : ICharacterResource
    {
        public ResourceType ResourceType => resourceType;

        public float Count => count;

        [SerializeField] private ResourceType resourceType;
        [SerializeField] private float count;
    }
}
