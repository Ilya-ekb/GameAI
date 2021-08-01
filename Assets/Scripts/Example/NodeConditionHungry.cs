using UnityEngine;
using BehaviourTree;
using Character;

public class NodeConditionHungry : NodeCondition
{
    private Student student;

    public void SetStudent(Student student) => this.student = student;
    public override ResultType Execute(ICharacter character) => student.IsHungry ? ResultType.Success : ResultType.Fail;
}
