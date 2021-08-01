using BehaviourTree;

using Character;

using UnityEngine;

public class NodeActionMove : NodeAction
{
    private Student student;
    private string targetName = string.Empty;

    public override ResultType Execute(ICharacter character)
    {
        GameObject target = GetTarget();
        if (target == null)
        {
            return ResultType.Fail;
        }

        bool arrive = Move(target.transform.position);

        return arrive ? ResultType.Success : ResultType.Running;
    }

    private bool Move(Vector3 targetPosition)
    {
        student.Agent.SetDestination(targetPosition);
        return student.Agent.remainingDistance <= student.Agent.radius && !student.Agent.pathPending;
    }

    private GameObject GetTarget() => GameObject.Find(targetName);
    public void SetTarget(string name) => targetName = name;
    public void SetStudent(Student student) => this.student = student;
}
