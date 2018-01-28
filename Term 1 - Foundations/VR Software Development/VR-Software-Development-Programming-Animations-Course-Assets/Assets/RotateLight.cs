using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour {

	public GameObject directionalLight;
	public Animator sunRotationAnimation;
	bool isPressed = false; // Has the trigger button been pressed at least once?

	float startTime = 0f;
	int number = 42;
	bool flag = true;
	string text = "Cool class";

	// Use this for initialization
	void Start () {
		sunRotationAnimation.StartPlayback ();
	}
	
	// Update is called once per frame
	void Update () {
		// // If the player pressed the cardboard button (or touched the screen) AND it has not already been pressed...
		if (Input.GetMouseButtonDown (0) && !isPressed) {
			// ...then update 'isPressed' to 'true'.
			isPressed = true;
			Debug.Log ("Update: 1");
		}

		// If the player pressed the cardboard button (or touched the screen) at least once...
		if (isPressed) {
			// ...then rotate.
			sunRotationAnimation.StopPlayback ();
			sunRotationAnimation.SetBool ("ChangeColor", true);
			Debug.Log ("Update: 2");
		}
	}

}
