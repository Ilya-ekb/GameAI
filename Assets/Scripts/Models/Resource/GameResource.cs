using Models.CharacterModel.Conditions;

using System;
using System.Collections.Generic;

using UnityEngine;

namespace Models.Resources
{
    [Serializable]
    [CreateAssetMenu(fileName = "Resource", menuName = "Character/Resource")]
    public class GameResource : BaseVariable 
    {
        public override float MaxValue => maxValue;
        public override float MinValue => minValue;

        public IEnumerable<ResourceAttribute> ResoureAttributes => resourceAttributes;

        [SerializeField] private List<ResourceAttribute> resourceAttributes;
        [SerializeField] private float maxValue;
        [SerializeField] private float minValue;
    }
}
