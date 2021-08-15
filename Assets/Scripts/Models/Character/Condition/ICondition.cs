using System.Collections.Generic;

namespace Models.Character.Conditions
{
    public interface ICondition : IVariable
    {
        IEnumerable<ConditionAttribyte> ConditionAttributes { get; }
    }

    public enum ConditionAttribyte
    {
        Healty,
        Enegry,
        Sentiment,
        Knowlerge
    }
}
