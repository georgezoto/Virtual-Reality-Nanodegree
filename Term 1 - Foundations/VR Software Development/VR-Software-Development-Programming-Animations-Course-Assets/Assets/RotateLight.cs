using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour {

	public GameObject directionalLight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion startRotation = Quaternion.Euler (50f, 30f, 0f);
		Quaternion endRotation = startRotation * Quaternion.Euler (0f, 180f, 0f);
		directionalLight.transform.rotation  = Quaternion.Slerp (startRotation, endRotation, Time.time / 100f);
	}
}
