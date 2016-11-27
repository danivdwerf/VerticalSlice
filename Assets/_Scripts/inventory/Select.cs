using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {
    private Equip equip;
   
    [SerializeField]
    //get al wapons
    private GameObject[] wapons;

    private void Start()
    {
        //get script
        equip = gameObject.GetComponent<Equip>();
    }

    //to select wapon using a number witch represent the posision in a array
    public void selectWapon(int wapon)
    {
        equip.equipWapon(wapons[wapon]);
    }
}
