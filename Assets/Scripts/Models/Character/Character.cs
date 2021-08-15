using Models;
using Models.Character;
using Models.Character.Behaviour;
using Models.Character.Conditions;
using Models.Character.Conditions.Knowlerge;
using Models.Resources;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public abstract class Character : MonoBehaviour, ICharacter
    {
        public List<VariableContainer<Resource>> Resources => throw new System.NotImplementedException();
        
        public List<VariableContainer<Knowlerge>> Knowlerges => throw new System.NotImplementedException();

        public List<VariableContainer<Condition>> Conditions => throw new System.NotImplementedException();

        public List<IAction> Actions => throw new System.NotImplementedException();

    }
}
