using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clouds;

    private GameObject[] spawnedClouds;

    private void Start()
    {
        if(clouds.Length > 0)
        {
            for (int i = 0; i < 20; i++)
            {

               Instantiate(clouds[Random.Range(0,clouds.Length -1)], new Vector3(((Random.value + 0.1f) * 14) -10, ((Random.value + 0.1f) * 4) -1,1), Quaternion.identity);
            }            
        }
        else
        {
            Debug.LogError("No cloud prefabs in the array");
        }
    }
}
