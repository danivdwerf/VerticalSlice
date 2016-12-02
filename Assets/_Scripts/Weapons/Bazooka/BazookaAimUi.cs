using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

public class BazookaAimUi : MonoBehaviour 
{
	private GameObject aimBar;
	private void Start()
	{
		string barPath = "Assets/Sprites/Aim.prefab";
		aimBar = (GameObject)AssetDatabase.LoadAssetAtPath (barPath, typeof(GameObject));
		if (!aimBar)
		{
			Debug.LogError ("Aimbar is null!");
			return;
		}
	}

	public void updateSprite()
	{
		
	}
}
