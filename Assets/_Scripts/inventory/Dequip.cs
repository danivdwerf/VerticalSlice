using UnityEngine;
using System.Collections;

public class Dequip : MonoBehaviour {
    //last added weapon
    GameObject previosAdd;

	public void dequipLastWapon(GameObject gameobj)
    {
        //if there is a prevois gameobject
        if(previosAdd != null)
        {
            //destroy the prevois gameobject
            Destroy(previosAdd);
        }
        previosAdd = gameobj;
    }
}
