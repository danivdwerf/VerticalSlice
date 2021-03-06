﻿using UnityEngine;
using System.Collections;

public class EquipWeapon : MonoBehaviour
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

    public void equipWeapon(GameObject weapon)
    {
        //get selected player
        GameObject player = currentPlayer.currentSelectedPlayer();

        //set selected game object on player
		GameObject newGameobject = Instantiate(weapon, player.transform.position, player.transform.rotation) as GameObject; 

		//Point the weapon accoriding to the play
		newGameobject.transform.localScale = player.transform.localScale;

		//make new weapn a child of the player
        newGameobject.transform.parent = player.transform;

        //dequip last wapon
        dequip.dequipLastWapon(newGameobject);           
    }
}
