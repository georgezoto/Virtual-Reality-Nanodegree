using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	public void GoToScene(string SceneName) {
		Debug.Log ("GoToScene() method called");
		SceneManager.LoadScene (SceneName);
	}
}
