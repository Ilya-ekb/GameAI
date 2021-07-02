using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.CharacterBehaviour
{
    public interface IAction
    {
        ICharacter thisCharacter { get; set; }
        void Do();
    }
}
