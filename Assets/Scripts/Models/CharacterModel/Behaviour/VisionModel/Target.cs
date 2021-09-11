using System;
using UnityEngine;

namespace Models.CharacterModel.Behaviour.VisionModel
{
    public class Target
    {
        public string Id { get; }

        public Vector3 Position { get; private set; }

        public Quaternion Rotation { get; private set; }

        public Target(Transform transform)
        {
            Id = transform.GetHashCode().ToString();
            Position = transform.position;
            Rotation = transform.rotation;
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
