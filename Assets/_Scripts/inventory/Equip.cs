using UnityEngine;
using System.Collections;

public class Equip : MonoBehaviour
{
    //private Dequip dequip;
    private CurrentPlayer currentPlayer;
    private void Start()
    {
        //dequip = GetComponent<Dequip>();
        currentPlayer = GetComponent<CurrentPlayer>();
    }

    public void equipWeapon(GameObject weapon)
    {
        GameObject player =  currentPlayer.currentSelectedPlayer();
		GameObject newGameobject =  Instantiate(weapon, player.transform.position, Quaternion.identity) as GameObject;
        newGameobject.transform.parent = player.transform;
        //dequip.dequipLastWapon(newGameobject);      
    }
}
