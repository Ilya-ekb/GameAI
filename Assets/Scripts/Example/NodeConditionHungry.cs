using UnityEngine;
using BehaviourTree;

public class NodeConditionHungry : NodeCondition
{
    private Student student;

    public void SetStudent(Student student) => this.student = student;
    public override ResultType Execute() => student.IsHungry ? ResultType.Success : ResultType.Fail;
}
