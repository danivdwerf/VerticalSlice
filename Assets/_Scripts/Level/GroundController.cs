using UnityEngine;
using System.Collections;
using UnityEditor;
public class GroundController : MonoBehaviour 
{
	private SpriteRenderer sr;
	private PolygonCollider2D col;
	private Color hole; 
	private CreateLevelCollider createCol;
	private float widthWorld, heightWorld;
	private int widthPixel, heightPixel;

	void Start()
	{
		//reference to sprite renderer
		sr = GetComponent<SpriteRenderer>(); 
		createCol = GetComponent<CreateLevelCollider> ();
		//Load in the texture
		string path = "Assets/Sprites/Level/Worms_level.png";
		Texture2D tex = (Texture2D)AssetDatabase.LoadAssetAtPath(path,typeof(Texture2D));
		//Create clone of the texture, so we won't alter(fuck up) the original
		Texture2D tex_clone = (Texture2D) Instantiate(tex);
		//Create a sprite from the cloned texture and set it as texture in the spriterenderer 
		sr.sprite = Sprite.Create(tex_clone, new Rect(0f, 0f, tex_clone.width, tex_clone.height), new Vector2(0.5f, 0.5f), 100f);
		//make a transparant colour(Color.clear would also work, but now you kind of make it yourself)
		hole = new Color(0f, 0f, 0f, 0f);
		//Set the properties according to the sizes of the new sprite 
		SetDimensions(); 
		//let the bullet know what the ground is
		DestroyLevel.groundController = this;
	}

	private void SetDimensions() 
	{
		widthWorld = sr.bounds.size.x;
		heightWorld = sr.bounds.size.y;
		widthPixel = sr.sprite.texture.width;
		heightPixel = sr.sprite.texture.height;
	}

	public void DestroyGround(CircleCollider2D cc)
	{
		V2int c = World2Pixel(cc.bounds.center.x, cc.bounds.center.y);
		int r = Mathf.RoundToInt(cc.bounds.size.x*widthPixel/widthWorld);
		int px, nx, py, ny;
		
		for (int i = 0; i <= r; i++)
		{
			int temp = (int)Mathf.RoundToInt(Mathf.Sqrt(r * r - i * i));
			
			for (int j = 0; j <= temp; j++)
			{
				px = c.x + i;
				nx = c.x - i;
				py = c.y + j;
				ny = c.y - j;

				sr.sprite.texture.SetPixel(px, py, hole);
				sr.sprite.texture.SetPixel(nx, py, hole);
				sr.sprite.texture.SetPixel(px, ny, hole);
				sr.sprite.texture.SetPixel(nx, ny, hole);
			}
		}
		sr.sprite.texture.Apply();
		Destroy(GetComponent<PolygonCollider2D>());
		gameObject.AddComponent<PolygonCollider2D>();
    }

	private V2int World2Pixel(float x, float y) 
	{
		V2int v = new V2int();
		float dx = x-transform.position.x;
		v.x = Mathf.RoundToInt(0.5f*widthPixel+ dx*widthPixel/widthWorld);
		float dy = y - transform.position.y;
		v.y = Mathf.RoundToInt(0.5f * heightPixel + dy * heightPixel / heightWorld);
		
		return v;
	}
}