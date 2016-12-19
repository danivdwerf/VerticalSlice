using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadUI : MonoBehaviour 
{
	//Reference to the laoding script
	private LoadScene loadGame{get;set;}
	//Image\\
	[SerializeField] Image sprite;
	private void Start()
	{
		//Create reference to the loading script
		loadGame = GetComponent<LoadScene>();
		sprite.fillAmount = 0;
	}

	public void UpdateUI()
	{
		//Get the Progress value
		float percentage = loadGame.GetPercentage;
		sprite.fillAmount = percentage;
	}
}