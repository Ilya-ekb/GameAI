using Character.CharacterBehaviour;
using Character.CharacterIndicator;
using Character.CharacterResources;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public interface ICharacter
    {
        Health Health { get; }
        Anxiety Anxiety { get; }
        Angry Angry { get; }
        List<ICharacterResource> Resources{ get; }
        List<IKnowlerge> Knowlerges { get; }
        IAction Atack { get; }
        IAction Hide { get; }
        IAction Move { get; }
        IAction Find { get; }
    }
}
