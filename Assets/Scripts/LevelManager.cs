using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public string sceneToLoad = "Forest";

	public void LoadGame()
	{
		SceneManager.LoadScene(sceneToLoad);
	}

	public void SetMap(string scene)
	{
		sceneToLoad = scene;
	}
}
