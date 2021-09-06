using BehaviourTree.Core;
using BehaviourTree.Data;
using Models.CharacterModel;

namespace BehaviourTree.Implementor
{
    public static class BehaviourImplementor
    {
        public static NodeRoot GetBehaviourNode(NodeData data)
        {
            NodeRoot result = null;
            switch (data.NodeType)
            {
                case NodeType.Select:
                    result = new NodeSelect(data);
                    break;
                case NodeType.Sequence:
                    result = new NodeSequence(data);
                    break;
                case NodeType.Decorator:
                    result = new NodeDecorator(data);
                    break;
                case NodeType.Condition:
                    result = new NodeCondition(data);
                    break;
                case NodeType.Parallel:
                    result = new NodeParallel(data);
                    break;
                case NodeType.Random:
                    result = new NodeRandom(data);
                    break;
                case NodeType.Action:
                    result = new NodeAction(data);
                    break;
            }

            return result;
        }
    }
}
