using System;
using UnityEngine;

namespace Models.CharacterModel.Behaviour.VisionModel
{
    public sealed class Target
    {
        public string Id { get; }

        public Transform Transform { get; private set; }

        public Vector3 Position { get; private set; }

        public Quaternion Rotation { get; private set; }

        public Target(Transform transform)
        {
            Id = transform.GetHashCode().ToString();
            Transform = transform;
            Position = transform.position;
            Rotation = transform.rotation;
        }
        public Target(Vector3 position, Quaternion rotation)
        {
            Id = GetHashCode().ToString();
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
