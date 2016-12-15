using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadUI : MonoBehaviour 
{
	//Reference to the laoding script
	private LoadScene loadGame{get;set;}
	//Reference to the text that will tell the progress
	[SerializeField] private Text loadPercentage;
	private void Start()
	{
		//Create reference to the loading script
		loadGame = GetComponent<LoadScene>();
	}

	public void UpdateUI()
	{
		//Get the Progress value
		float percentage = loadGame.GetPercentage;
		//Set the progress text
		loadPercentage.text = "Loading"+percentage + "%";
	}
}