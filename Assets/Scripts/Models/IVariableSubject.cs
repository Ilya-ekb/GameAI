using System.Collections.Generic;

namespace Models
{
    public interface IVariableSubject 
    {
        IEnumerable<BaseVariableContainer> BaseVariableContainer { get; }
    }
}
