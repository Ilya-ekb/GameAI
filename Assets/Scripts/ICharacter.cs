using Character.CharacterBehaviour;
using Character.CharacterIndicator;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public interface ICharacter
    {
        IInternalCondition Health { get; }
        IInternalCondition Anxiety { get; }
        IInternalCondition Angry { get; }

        IAction Atack { get; }
        IAction Hide { get; }
        IAction Move { get; }
        IAction Find { get; }
    }
}
