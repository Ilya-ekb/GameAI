using UnityEngine;
using BehaviourTree;

public class NodeActionEat : NodeAction
{
    private Student student;
    public override ResultType Execute()
    {
        if (student.IsFull)
        {
            return ResultType.Success;
        }

        student.AddEnergy(.5f);
        student.ChangeFood(-.4f);
        return ResultType.Running;
    }

    public void SetStudent(Student student) => this.student = student;
}
