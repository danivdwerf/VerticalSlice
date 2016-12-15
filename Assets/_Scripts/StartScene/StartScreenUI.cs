using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class StartScreenUI : MonoBehaviour 
{
	[SerializeField]private Button startButton;
	private Sprite pressedSprite;
	private LoadScene loadingScript;
 
	private void Start()
	{
		loadingScript = GetComponent<LoadScene> ();
		pressedSprite = loadSprite (); 
		startButton.onClick.AddListener (delegate(){loadingScript.loadScene (1);});
	}

	private Sprite loadSprite()
	{
		Sprite sprite = AssetDatabase.LoadAssetAtPath (Paths.pressedButtonPath, typeof(Sprite))as Sprite;
		return sprite;
	}

}
