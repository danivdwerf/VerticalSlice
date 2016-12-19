using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour 
{
	//a variable to store the progress
	private float percentage{get;set;}
	//Reference to the UIScript
	private LoadUI loadUI{get;set;}
	private void Start()
	{
		//Create the reference to the script
		loadUI = GetComponent<LoadUI>();
	}
	//This is the function you have to call to load
	public void loadScene(int sceneIndex)
	{
		//Set a start value to the percentage
		percentage = 0;
		//start the loading
		StartCoroutine(load(sceneIndex));
	}

	IEnumerator load(int sceneIndex)
	{
		//Create a variable that loads the scene
		AsyncOperation async = SceneManager.LoadSceneAsync(sceneIndex);
		//while loading is not done...
		while (!async.isDone)
		{
			//the progress will be between 0 and 0.9 so we will calculate it to be between 0 and 100
			percentage = Mathf.Floor (async.progress / 0.9f);
			//Update the UI in the UIscript
			loadUI.UpdateUI ();
			//yield return something (Because the IEnumerator requires that)
			yield return null;
		}
	}

	public float GetPercentage
	{
		get
		{ 
			//Make sure the UIscript can access the progress value
			return percentage;
		}
	}
}