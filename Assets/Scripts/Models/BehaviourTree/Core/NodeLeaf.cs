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
        public IAction Action { get => action; set => action = value; }
        
        private IAction action;
        
        public NodeLeaf(NodeType nodeType, NodeData data) : base(nodeType) 
        {
            action = data.Action;
        }


        public override ResultType Execute(ICharacter character)
        {
            return action is null ? ResultType.Fail : action.Do(character);
        }

}
}
