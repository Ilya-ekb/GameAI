using Models.CharacterModel.Conditions;

using System;
using System.Collections.Generic;

using UnityEngine;

namespace Models
{
    public interface IVariable 
    {
        float MaxValue { get; }
        float MinValue { get; }
    }

    public enum CompareMode 
    {
        Equals,
        NotEquals,
        Greater,
        Less,
        GreaterOrEquals,
        LessOrEquals
    }

    public static class CompareAction<T> where T : BaseVariable
    {
        public static readonly Dictionary<CompareMode, Func<BaseVariableContainer, VariableContainer<T>, bool>> Compares =
            new Dictionary<CompareMode, Func<BaseVariableContainer, VariableContainer<T>, bool>>
            {
                {CompareMode.Equals, (a, b) => a.Value == b.Value },
                {CompareMode.Greater, (a, b) => a.Value > b.Value },
                {CompareMode.Less, (a, b) => a.Value < b.Value },
                {CompareMode.NotEquals, (a, b) => a.Value != b.Value },
                {CompareMode.GreaterOrEquals, (a, b) => a.Value >= b.Value },
                {CompareMode.LessOrEquals, (a, b) => a.Value <= b.Value },
            };
    }
}
