using Character.Behaviour;
using Character.Condition;
using Character.Condition.Knowlerge;
using Models.Resources;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public abstract class Character : MonoBehaviour, ICharacter
    {
        public List<IResource> Resources => throw new System.NotImplementedException();

        public List<IKnowlerge> Knowlerges => throw new System.NotImplementedException();

        public List<ICondition> Conditions => throw new System.NotImplementedException();

        public List<IAction> Actions => throw new System.NotImplementedException();
    }
}
