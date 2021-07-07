using BehaviourTree;

public class NodeConditionHasFood : NodeCondition
{
    private Student student;

    public void SetStudent(Student student) => this.student = student;
    public override ResultType Execute() => student.HasFood ? ResultType.Success : ResultType.Fail;
}
