using BehaviourTree;

using Character;

public class NodeConditionHasFood : NodeCondition
{
    private Student student;

    public void SetStudent(Student student) => this.student = student;
    public override ResultType Execute(ICharacter character) => student.HasFood ? ResultType.Success : ResultType.Fail;
}
