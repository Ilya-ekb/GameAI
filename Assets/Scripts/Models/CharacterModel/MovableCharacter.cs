using UnityEngine;
using System;
using Unity.VisualScripting;

namespace Models.CharacterModel
{
    public abstract class MovableCharacter : BaseCharacter
    {
        public Vector3 Velocity => MoveBehaviour.Velocity;
        public bool IsReached => target.Equals(transform.position);


        public virtual IMoveBehaviour MoveBehaviour
        {
            get;
            protected set;
        }

        [SerializeField] private float stopDistance = .1f;
        private Vector3 target;

        public void SetTarget(Vector3 selectedTarget)
        {
            if (!target.Equals(selectedTarget))
            {
                target = selectedTarget;
            }
        }

        public virtual void Move()
        {
            MoveBehaviour.SetDestination(target);
        }

        public virtual void Stop()
        {
            MoveBehaviour.StopMove();
        }
    }
}
