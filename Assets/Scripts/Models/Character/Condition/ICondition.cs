namespace Character.Condition
{
    public interface ICondition
    {
        float Value { get; }
        bool Full { get; }
        void Change(float value);
    }
}
