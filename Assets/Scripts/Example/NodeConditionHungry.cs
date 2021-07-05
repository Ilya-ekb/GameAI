using UnityEngine;
using BehaviourTree;

public class NodeConditionHungry : NodeCondition
{
    private Student student;

    public override ResultType Execute()
    {
        ResultType result = student.IsHungry ? ResultType.Success : ResultType.Fail;
        return result;
    }
    public void SetStudent(Student student)
    {
        this.student = student;
    }
}
