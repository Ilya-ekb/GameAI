using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestBehaviourTree
{

    private Student student;

    [UnityTest]
    public IEnumerator TestBehaviourTreeWithEnumeratorPasses()
    {
        student = 
            MonoBehaviour.Instantiate(
                Resources.Load<GameObject>("Assets/Prefabs/Student"))
                .GetComponent<Student>();
        yield return null;
    }
}
