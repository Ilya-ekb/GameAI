using BehaviourTree.Data;
using Models.CharacterModel;
using Models.CharacterModel.Behaviour;

namespace BehaviourTree.Core
{
    /// <summary>
    /// Leaf node
    /// </summary>
    public abstract class NodeLeaf : NodeRoot
    {
        public IAction Action { get; set; }

        protected NodeLeaf(NodeType nodeType, NodeData data) : base(nodeType) 
        {
            Action = data.Action;
        }

        public override ResultType Execute(ICharacter character)
        {
            return Action?.Do(character) ?? ResultType.Fail;
        }
    }
}
