using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth 
{
   float Value { get; }
    void Damage(float value);
    void Recovery(float value);
}
