using UnityEngine;
using System;

namespace Models.Character.Conditions
{
    [Serializable]
    public class Condition : ScriptableObject, ICondition
    {
        public ConditionType ConditionType => conditionType;
        public float MaxValue => maxValue;
        public float MinValue => minValue;

        [SerializeField] private ConditionType conditionType;
        [SerializeField] private float maxValue;
        [SerializeField] private float minValue;
    }
}
