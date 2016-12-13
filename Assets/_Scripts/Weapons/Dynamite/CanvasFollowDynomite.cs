using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollowDynomite : MonoBehaviour {

    private GameObject dynomite;

    [SerializeField]
    private float distance;

    void Update()
    {
        //if you can't find a dynamite
        if (dynomite == null)
        {
            //set the text far away
            this.transform.position = new Vector2(100, 100);
            //look for a dynamite
            dynomite = GameObject.Find("Dynamite");
        }
        else
        {
            this.transform.position = dynomite.transform.position + new Vector3(0, 0, distance);
        }        
    }
}
