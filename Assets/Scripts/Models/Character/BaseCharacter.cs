using Models;
using Models.CharacterModel.Behaviour;
using Models.CharacterModel.Conditions;
using Models.CharacterModel.KnowlergeModel;
using Models.Resources;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace Models.CharacterModel
{
    public abstract class BaseCharacter : MonoBehaviour, ICharacter
    {
        public List<VariableContainer<GameResource>> Resources => resources;
        public List<VariableContainer<Knowlerge>> Knowlerges => knowlerges;
        public List<VariableContainer<Condition>> Conditions => conditions;
        public Transform Transform => transform;

        [SerializeField] private List<VariableContainer<GameResource>> resources;
        [SerializeField] private List<VariableContainer<Knowlerge>> knowlerges;
        [SerializeField] private List<VariableContainer<Condition>> conditions;

        public VariableContainer<T> FindContainer<T>(T container) where T : BaseVariable
        {
            List<VariableContainer<BaseVariable>> tempList = new List<VariableContainer<BaseVariable>>();
            tempList.AddRange(Resources.Cast<VariableContainer<BaseVariable>>());
            tempList.AddRange(Knowlerges.Cast<VariableContainer<BaseVariable>>());
            tempList.AddRange(Conditions.Cast<VariableContainer<BaseVariable>>());

            var result = tempList.Find(e => e.Variable == container);
            
            return result as VariableContainer<T>; 
        }
    }
}
