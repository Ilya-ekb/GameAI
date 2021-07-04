
namespace BehaviourTree
{
    /// <summary>
    /// Behaviour tree node type
    /// </summary>
    public enum NodeType
    {
        /// <summary>
        /// Select node
        /// </summary>
        Select = 0,

        /// <summary>
        /// Sequence node
        /// </summary>
        Sequence = 1,

        /// <summary>
        /// Modification node
        /// </summary>
        Decorator = 2,

        /// <summary>
        /// Random node
        /// </summary>
        Random = 3,

        /// <summary>
        /// Parallel node
        /// </summary>
        Parallel = 4,

        /// <summary>
        /// Condition node
        /// </summary>
        Condition = 5,

        /// <summary>
        /// Behaviour node
        /// </summary>
        Action = 6,
    }
}
