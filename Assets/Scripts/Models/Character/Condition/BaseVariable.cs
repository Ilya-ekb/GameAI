using System;

using UnityEngine;

namespace Models.CharacterModel.Conditions
{
    [Serializable]
    public abstract class BaseVariable : ScriptableObject, IVariable
    {
        public abstract float MaxValue { get; }
        public abstract float MinValue { get; }

    }

    public enum ConditionAttribyte
    {
        Healty,
        Enegry,
        Sentiment,
        Knowlerge
    }
}
