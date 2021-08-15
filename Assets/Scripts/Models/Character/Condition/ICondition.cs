namespace Models.Character.Conditions
{
    public interface ICondition : IVariable
    {
        ConditionType ConditionType { get; }
    }

    public enum ConditionType
    {
        Healty,
        Enegry,
        Sentiment,
        Knowlerge
    }
}
