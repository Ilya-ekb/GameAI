using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestBehaviourTree
{

    private Robot student;

    [UnityTest]
    public IEnumerator TestBehaviourTreeWithEnumeratorPasses()
    {
        student = 
            MonoBehaviour.Instantiate(
                Resources.Load<GameObject>("Assets/Prefabs/Student"))
                .GetComponent<Robot>();
        yield return null;
    }
}
