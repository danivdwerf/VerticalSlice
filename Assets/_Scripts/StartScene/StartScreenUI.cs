using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;

public class StartScreenUI : MonoBehaviour 
{
	[SerializeField]private Button startButton;
	[SerializeField]private Text buttonText;
	private Sprite pressedSprite;
	private LoadScene loadingScript;
	EventTrigger.Entry enter;
	EventTrigger.Entry exit;
 
	private void Start()
	{
		loadingScript = GetComponent<LoadScene> ();
		pressedSprite = loadSprite (); 

		buttonListeners ();
		hideText ();
	}

	private void showText()
	{
		buttonText.text = "Play a quick two player game.";
	}

	private void hideText ()
	{
		buttonText.text = "";
	}

	private void buttonListeners()
	{
		startButton.onClick.AddListener (delegate(){loadingScript.loadScene (1);});

		enter = new EventTrigger.Entry();
		enter.eventID = EventTriggerType.PointerEnter;
		enter.callback.AddListener((eventData) => {showText();});	
		startButton.gameObject.AddComponent<EventTrigger> ();
		startButton.GetComponent<EventTrigger> ().triggers.Add (enter);

		exit = new EventTrigger.Entry ();
		exit.eventID = EventTriggerType.PointerExit;
		exit.callback.AddListener ((eventData) =>{hideText ();});
		startButton.GetComponent<EventTrigger> ().triggers.Add (exit);
	}

	private Sprite loadSprite()
	{
		Sprite sprite = AssetDatabase.LoadAssetAtPath (Paths.pressedButtonPath, typeof(Sprite))as Sprite;
		return sprite;
	}

}
