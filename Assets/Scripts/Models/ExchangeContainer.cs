using Models.CharacterModel.Conditions;
using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class ExchangeContainer<T> : VariableContainer<T> where T : BaseVariable
    {
        [SerializeField] private float exchangeCoeficient;
        [SerializeField] private ActionSign actionSign;
        public void GetValue(float incomeValue)
        {
            value = incomeValue * exchangeCoeficient;
            value = actionSign == ActionSign.Add ? value : -value;
        }

        enum ActionSign
        {
            Add,
            Sub,
        }
    }
}
