using UnityEngine;
using BehaviourTree;
using Models.Character.Conditions.Knowlerge;

namespace Models.Character.Behaviour
{
    public abstract class Action : ScriptableObject, IAction
    {
        public IKnowlerge[] NeededKnowlerges => neededKnowlerges;

        [SerializeField] protected Knowlerge[] neededKnowlerges;

        public virtual ResultType Do(ICharacter character)
        {
            throw new System.NotImplementedException();
        }
    }
}
