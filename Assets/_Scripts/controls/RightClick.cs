using UnityEngine;
using System.Collections;

public class RightClick : MonoBehaviour {

    private OpenWaponMenu openWaponMenu;
	void Start ()
    {
        openWaponMenu = gameObject.GetComponent<OpenWaponMenu>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetMouseButtonDown(1))
        {            
          openWaponMenu.toggleMenu();           
        }               
    }
}
