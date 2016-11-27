using UnityEngine;
using System.Collections;

public class Dequip : MonoBehaviour 
{
    //last added weapon
    GameObject previosAdd;

	public void dequipLastWapon(GameObject gameobj)
    {
        //if there is a weapon already exists
        if(previosAdd != null)
        {
            //destroy the the weapon
            Destroy(previosAdd);
        }
        previosAdd = gameobj;
    }
}
