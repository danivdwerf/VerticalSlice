using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float distance;



    void Update()
    {
        if(target != null)
        {
            this.transform.position = target.transform.position + new Vector3(0, 0, distance);
        }
        else
        {
            Destroy(this.gameObject);
        }       
    }

    public void otherPlayer(GameObject player)
    {
        target = player;
    }
}