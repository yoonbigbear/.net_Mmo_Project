using System.Collections.Generic;

public static class SceneManager
{
	public static void LoadScene(string sceneName)
	=> UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
	public static void LoadScene(uint sceneId)
	=> UnityEngine.SceneManagement.SceneManager.LoadScene((int)sceneId);
}
