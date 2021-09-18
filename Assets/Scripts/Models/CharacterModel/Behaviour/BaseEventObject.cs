using BehaviourTree.Core;
using UnityEngine;
using System;

namespace Models.CharacterModel.Behaviour
{
    [Serializable]
    public abstract class BaseEventObject : ScriptableObject, IAction
    {
        public virtual string Id
        {
            get
            {
                if (string.IsNullOrEmpty(id))
                {
                    id = Guid.NewGuid().ToString();
                }
                return id;
            }
        }

        public string Name => name;

        [SerializeField] protected string id;

        public abstract ResultType Do(ICharacter character);
    }
}
