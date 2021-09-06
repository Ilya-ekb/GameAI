using Models.CharacterModel;
using Models.CharacterModel.Conditions;
using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class ExchangeContainer<T> : VariableContainer<T> where T : BaseVariable
    {
        [SerializeField] private float exchangeCoefficient;
        [SerializeField] private ActionSign actionSign;
        public float GetValue(float incomeValue)
        {
            var value = incomeValue * exchangeCoefficient;
            return actionSign == ActionSign.Add ? value : -value;
        }

        private enum ActionSign
        {
            Add,
            Sub,
        }
    }
}
