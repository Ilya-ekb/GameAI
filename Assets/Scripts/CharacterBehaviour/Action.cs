using UnityEngine;
using BehaviourTree;
using Character.CharacterIndicator;

namespace Character.CharacterBehaviour
{
    public abstract class Action : ScriptableObject, IAction
    {
        public ICharacter thisCharacter { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public IKnowlerge NeededKnowlegre => throw new System.NotImplementedException();

        public virtual ResultType Do(params object[] vs)
        {
            throw new System.NotImplementedException();
        }
    }
}
