using UnityEngine;
using System;
using System.Collections.Generic;

namespace Models.Character.Conditions
{
    [Serializable]
    [CreateAssetMenu(fileName = "Condition", menuName = "Character/Condition")]
    public class Condition : ScriptableObject, ICondition
    {
        public float MaxValue => maxValue;
        public float MinValue => minValue;

        public IEnumerable<ConditionAttribyte> ConditionAttributes => conditionAttribytes;

        [SerializeField] private List<ConditionAttribyte> conditionAttribytes;
        [SerializeField] private float maxValue;
        [SerializeField] private float minValue;
    }
}
