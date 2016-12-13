using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distance;

    void Update()
    {
        this.transform.position = target.position + new Vector3(0, 0, distance);
    }
}