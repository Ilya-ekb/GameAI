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

        public ExchangeContainer(T variable, float value, float exchangeCoefficient = 0.7f, ActionSign actionSign = ActionSign.Add) : base(variable, value) { }

        public float GetValue(float incomeValue)
        {
            var value = incomeValue * exchangeCoefficient;
            return actionSign == ActionSign.Add ? value : -value;
        }

        public enum ActionSign
        {
            Add,
            Sub,
        }
    }
}
