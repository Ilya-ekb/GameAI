using System;
using UnityEngine;
using Character.CharacterResources;

namespace Character.CharacterIndicator
{
    [Serializable]
    public class Health : Condition
    {
        public Health(float startValue):base(startValue, ConditionType.Health) { }
    }
}
