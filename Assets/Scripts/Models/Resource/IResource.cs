namespace Models.Resources
{
    public interface IResource : IVariable
    {
        ResourceType ResourceType { get; }
    }

    public enum ResourceType
    {
        None,
        Food,
        Medicines
    }
}
