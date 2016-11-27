using UnityEngine;
using System.Collections;

public class Equip : MonoBehaviour
{
    //get dequip script
    private Dequip dequip;
    // get current player script
    private CurrentPlayer currentPlayer;

    private void Start()
    {
        // get scripts
        dequip = GetComponent<Dequip>();
        currentPlayer = GetComponent<CurrentPlayer>();
    }
<<<<<<< HEAD
    // fuction for equiping weapon on player
    public void equipWapon(GameObject weapon)
=======

    public void equipWeapon(GameObject weapon)
>>>>>>> 039518da4909043d0d038340be4c0d4a67ac23fc
    {
        //get selected player
        GameObject player =  currentPlayer.currentSelectedPlayer();
<<<<<<< HEAD

        //set selected game object on player
        GameObject newGameobject =  Instantiate(weapon, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity) as GameObject;

        //make new weapn a child of the player;
=======
		GameObject newGameobject =  Instantiate(weapon, player.transform.position, Quaternion.identity) as GameObject;
>>>>>>> 039518da4909043d0d038340be4c0d4a67ac23fc
        newGameobject.transform.parent = player.transform;

        //dequip last wapon
        dequip.dequipLastWapon(newGameobject);      
    }
}
