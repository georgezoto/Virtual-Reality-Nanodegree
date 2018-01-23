using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move the coconut down every frame until it hits the ground, then stop.
public class FallFromTree : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, -2.5f * Time.deltaTime, 0, Space.World);
	}
}
