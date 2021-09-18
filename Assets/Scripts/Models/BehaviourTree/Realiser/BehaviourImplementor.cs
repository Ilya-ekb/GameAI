using BehaviourTree.Core;
using BehaviourTree.Data;
using Models.CharacterModel;

namespace BehaviourTree.Implementor
{
    public static class BehaviourImplementor
    {
        public static NodeRoot GetBehaviourNode(NodeData data)
        {
            if (data == null)
            {
                return null;
            }
            NodeRoot result = data.NodeType switch
            {
                NodeType.Select => new NodeSelect(data),
                NodeType.Sequence => new NodeSequence(data),
                NodeType.Decorator => new NodeDecorator(data),
                NodeType.Condition => new NodeCondition(data),
                NodeType.Parallel => new NodeParallel(data),
                NodeType.Random => new NodeRandom(data),
                NodeType.Action => new NodeAction(data),
                _ => null
            };

            return result;
        }
    }
}
