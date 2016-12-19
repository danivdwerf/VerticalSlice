using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour 
{
	public void change(int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);
	}
}
