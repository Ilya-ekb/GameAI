using UnityEngine;
using BehaviourTree;
using Models.Resources;
using Character.Condition.Knowlerge;

namespace Character.Behaviour
{
    public abstract class Action : ScriptableObject, IAction
    {
        public IKnowlerge[] NeededKnowlerges => neededKnowlerges;
        public IResource[] NeededResources => neededResources;

        [SerializeField] protected Knowlerge[] neededKnowlerges;
        [SerializeField] protected Resource[] neededResources;

        public virtual ResultType Do(ICharacter character)
        {
            throw new System.NotImplementedException();
        }
    }
}
