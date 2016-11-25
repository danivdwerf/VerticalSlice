using UnityEngine;
using System.Collections;

public class Equip : MonoBehaviour
{
    private Dequip dequip;
    private CurrentPlayer currentPlayer;
    private void Start()
    {
        dequip = GetComponent<Dequip>();
        currentPlayer = GetComponent<CurrentPlayer>();
    }

    public void equipWapon(GameObject weapon)
    {
        GameObject player =  currentPlayer.currentSelectedPlayer();
        GameObject newGameobject =  Instantiate(weapon, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity) as GameObject;
        newGameobject.transform.parent = player.transform;
        dequip.dequipLastWapon(newGameobject);      
    }
}
