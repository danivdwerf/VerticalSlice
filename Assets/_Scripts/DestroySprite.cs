using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroySprite : MonoBehaviour 
{
	[SerializeField]private GameObject sprite;
	private Sprite image;
	private int holeWidth;
	private int holeHeight;
	void Start()
	{
		if (sprite == null)
		{
			Debug.LogError ("Image not set");
			return;
		}
		image = sprite.GetComponent<SpriteRenderer> ().sprite;
		holeWidth = 100;
		holeHeight = 100;
		cutHole (image.texture.width / 2, image.texture.height / 2);
	}

	public void cutHole(float xPos, float yPos)
	{
		Texture2D texture = Instantiate (image.texture)as Texture2D;
		Color[] colors = new Color[holeWidth*holeHeight];
		int x = Mathf.RoundToInt(xPos);
		int y = Mathf.RoundToInt(yPos);
		for (int i = 0; i < colors.Length; i++)
		{
			colors [i] = Color.clear;
		}
		texture.SetPixels (x,y,holeWidth,holeHeight,colors);
		texture.Apply ();
		//image.texture = texture;	
	}
}
