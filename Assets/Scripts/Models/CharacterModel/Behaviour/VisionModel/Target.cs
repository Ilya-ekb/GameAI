using System.Collections.Generic;
using Codice.CM.Client.Differences;
using UnityEngine;

namespace Models.CharacterModel.Behaviour.VisionModel
{
    public sealed class Target
    {
        public string Id { get; }

        public string Name { get; }
        public Transform Transform { get; }

        public Vector3 Position { get; private set; }

        public Quaternion Rotation { get; private set; }

        public Dictionary<BaseVariable, BaseVariableContainer> BaseVariableContainer { get; }

        public Target(Transform transform)
        {
            Id = transform.GetHashCode().ToString();
            Name = transform.name;
            Transform = transform;
            Position = transform.position;
            Rotation = transform.rotation;
            BaseVariableContainer = transform.GetComponent<IVariableSubject>()?.BaseVariableContainer;
        }

        public Target(Vector3 position, Quaternion rotation)
        {
            Id = GetHashCode().ToString();
            Name = Id;
            Transform = null;
            Position = position;
            Rotation = rotation;
        }

        public void Update(Transform transform)
        {
            if(transform == null)
            {
                return;
            }
            Position = transform.position;
            Rotation = transform.rotation;
        }
    }
}
