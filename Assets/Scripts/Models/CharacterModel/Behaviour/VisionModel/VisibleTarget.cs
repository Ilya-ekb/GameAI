using System;
using UnityEngine;

namespace Models.CharacterModel.Behaviour.VisionModel
{
    public class VisibleTarget
    {
        public string Id { get; }

        public Vector3 Position { get; }

        public Quaternion Rotation { get; }

        public VisibleTarget(Transform transform)
        {
            Id = Guid.NewGuid().ToString();
            Position = transform.position;
            Rotation = transform.rotation;
        }

        public VisibleTarget(Vector3 position, Quaternion rotation)
        {
            Id = Guid.NewGuid().ToString();
            Position = position;
            Rotation = rotation;
        }
    }
}
