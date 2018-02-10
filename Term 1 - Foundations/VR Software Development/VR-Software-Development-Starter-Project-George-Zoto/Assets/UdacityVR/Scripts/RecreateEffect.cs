using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecreateEffect : MonoBehaviour {

	public GameObject Effect;

	// Use this for initialization
	void Start () {
		//Object.Instantiate(Effect, transform.position, Quaternion.identity);
		//Destroy (Effect);
	}
	
	// Update is called once per frame
	void Update () {
		print ("Update!");
		//transform.Translate (0f, Time.deltaTime*10, 0f, Space.World);
	}
}
