using UnityEngine;
using System;
using System.Collections.Generic;

namespace Models.CharacterModel.Conditions
{
    [Serializable]
    [CreateAssetMenu(fileName = "Condition", menuName = "Character/Condition")]
    public class Condition : BaseVariable
    {
        public IEnumerable<ConditionAttribyte> ConditionAttributes => conditionAttribytes;
        public override float MaxValue => maxValue;
        public override float MinValue => minValue;

        [SerializeField] private List<ConditionAttribyte> conditionAttribytes;
        [SerializeField] private float maxValue;
        [SerializeField] private float minValue;

    }
}
