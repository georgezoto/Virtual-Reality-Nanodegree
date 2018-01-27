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
		directionalLight.transform.Rotate (0f, Time.deltaTime, 0f);
	}
}
