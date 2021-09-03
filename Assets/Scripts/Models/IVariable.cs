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

    public enum CompairMode 
    {
        Equals,
        NotEquals,
        Greater,
        Less,
        GreaterOrEquals,
        LessOrEquals
    }

    public static class CompairAction<T> where T : BaseVariable
    {
        public static readonly Dictionary<CompairMode, Func<BaseVariableContainer, VariableContainer<T>, bool>> Compairs =
            new Dictionary<CompairMode, Func<BaseVariableContainer, VariableContainer<T>, bool>>
            {
                {CompairMode.Equals, (a, b) => a.Value == b.Value },
                {CompairMode.Greater, (a, b) => a.Value > b.Value },
                {CompairMode.Less, (a, b) => a.Value < b.Value },
                {CompairMode.NotEquals, (a, b) => a.Value != b.Value },
                {CompairMode.GreaterOrEquals, (a, b) => a.Value >= b.Value },
                {CompairMode.LessOrEquals, (a, b) => a.Value <= b.Value },
            };
    }
}
