using UnityEngine;
using System.Collections;

public class DynamiteExplode : MonoBehaviour {
    [SerializeField]
    private GameObject circle;   
    //detonate the dynamyte
    public void detonate()
    {
        
        GameObject destroyGround = Instantiate(circle, this.transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
    }
}