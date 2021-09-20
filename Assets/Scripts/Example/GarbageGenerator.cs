using System.Collections;
using System.Collections.Generic;
using Codice.Client.BaseCommands;
using Models;
using UnityEngine;

public class GarbageGenerator : MonoBehaviour
{
    private GameObject[] garbage;
    [SerializeField] private GameObject garbagePrefab;
    [SerializeField] private int garbageCount;
    [SerializeField] private float instanceAreaHalfScale;
    [SerializeField] private float period;
    private float timer;
    private float x;
    private float z;

    private void Start()
    {

        garbage = new GameObject[garbageCount];
        for(var i = 0; i  < garbage.Length; i++)
        {
            garbage[i] = Instantiate(garbagePrefab);
            var containers = garbage[i].GetComponent<SimpleVariableSubject>().BaseVariableContainer;
            foreach (var container in containers)
            {
                container.Value.Value = Random.Range(10, 101);
            }

            garbage[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (timer <= 0)
        {
            foreach (var gar in garbage)
            {
                if (!gar.activeSelf && timer <= 0)
                {
                    x = Random.Range(-instanceAreaHalfScale, instanceAreaHalfScale);
                    z = Random.Range(-instanceAreaHalfScale, instanceAreaHalfScale);
                    gar.transform.position = new Vector3(transform.position.x + x, gar.transform.position.y,
                        transform.position.z + z);
                    var containers = gar.GetComponent<SimpleVariableSubject>().BaseVariableContainer;
                    foreach (var container in containers)
                    {
                        container.Value.Value = Random.Range(10, 101);
                    }
                    timer = period;

                    gar.SetActive(true);
                    break;
                }
            }
        }

        timer -= Time.deltaTime;
    }
}
