using BehaviourTree.Data;
using Models.CharacterModel;
using Models.CharacterModel.Behaviour;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

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
             var result = Action?.Do(character) ?? ResultType.Fail;
             //Debug.Log($"{Action?.Name} for {character.Transform?.name} is {result} [Target: {character.Target?.Transform?.name}]");
             return result;
        }
    }
}
