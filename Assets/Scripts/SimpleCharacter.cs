using Character.CharacterBehaviour;
using Character.CharacterIndicator;
using Character.CharacterResources;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class SimpleCharacter : MonoBehaviour, ICharacter
    {
        public Health Health => health;

        public Anxiety Anxiety => anxiety;

        public Angry Angry => angry;

        public IAction Atack => throw new System.NotImplementedException();

        public IAction Hide => throw new System.NotImplementedException();

        public IAction Move => throw new System.NotImplementedException();

        public IAction Find => throw new System.NotImplementedException();

        public float StartHealth { get => startHealth; set => startHealth = value; }
        public float StartAnxiety { get => startAnxiety; set => startAnxiety = value; }
        public float StartAngry { get => startAngry; set => startAngry = value; }

        public List<ICharacterResource> Resources => throw new System.NotImplementedException();

        public List<IKnowlerge> Knowlerges => throw new System.NotImplementedException();

        [SerializeField] private float startHealth = 100.0f;
        [SerializeField] private float startAnxiety = 0.0f;
        [SerializeField] private float startAngry = 10.0f;

        private Health health;
        private Anxiety anxiety;
        private Angry angry;

        void Start()
        {
            health = new Health(100f);
            anxiety = new Anxiety(100f);
            angry = new Angry(100f);
        }

        void Update()
        {

        }
    }
}
