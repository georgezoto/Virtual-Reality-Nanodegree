using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	public void GoToScene(){
		Debug.Log ("GoToScene() method called");
		SceneManager.LoadScene ("00-FallingCoconut");
	}
}
