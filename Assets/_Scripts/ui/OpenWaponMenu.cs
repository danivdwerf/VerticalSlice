using UnityEngine;
using System.Collections;

public class OpenWaponMenu : MonoBehaviour 
{
    [SerializeField]
    private GameObject waponMenu;
    private bool onOff = false;
	void Start () 
	{
		
	}
	
	public void toggleMenu()
	{
        switch(onOff)
        {
            case false:
                waponMenu.SetActive(true);
                onOff = true;
                break;
            case true:
                waponMenu.SetActive(false);
                onOff = false;
                break;
            
        }
	}
}