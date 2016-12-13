using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private Transform target;

    void Update()
    {
        this.transform.position = target.position;
    }
}