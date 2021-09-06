using UnityEngine;
using System;
using System.Collections.Generic;

namespace Models.CharacterModel.Conditions
{
    [Serializable]
    [CreateAssetMenu(fileName = "Condition", menuName = "Character/Condition")]
    public class Condition : BaseVariable
    {
        public IEnumerable<ConditionAttribute> ConditionAttributes => conditionAttributes;
        public override float MaxValue => maxValue;
        public override float MinValue => minValue;

        [SerializeField] private List<ConditionAttribute> conditionAttributes;
        [SerializeField] private float maxValue;
        [SerializeField] private float minValue;

    }
}
