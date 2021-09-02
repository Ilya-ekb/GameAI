using UnityEngine;
using BehaviourTree.Core;
using UnityEngine.AI;
using Models.CharacterModel;

public class Student : BaseCharacter
{
    public NavMeshAgent Agent { get; set; }

    public float period;
    private float timer = 0;


    protected override void Update()
    {
        base.Update();
        if(timer <= 0)
        {
            foreach (var condition in Conditions)
            {
                condition.Value -= .2f;
                Debug.Log($"{condition.Variable.name} = {condition.Value}");
            }
            timer = period;
        }
        timer -= Time.deltaTime;
    }
}
