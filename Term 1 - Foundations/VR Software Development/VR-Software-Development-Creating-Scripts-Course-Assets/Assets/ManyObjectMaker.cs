using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyObjectMaker : MonoBehaviour {

	public GameObject objectToCreate;

	// Use this for initialization
	void Start () {
		// make an object here
		//Object.Instantiate(objectToCreate, new Vector3(2, 4, 6), Quaternion.identity);
		for (int i = 0; i < 20; i++) {
			// do something here
			//Object.Instantiate(objectToCreate, new Vector3(i, 7 + Mathf.Sin(i), 3), Quaternion.identity);

			Object.Instantiate(objectToCreate, new Vector3(5 + Mathf.Cos(i), 4.5f + Mathf.Sin(i), 3), Quaternion.identity);
			Object.Instantiate(objectToCreate, new Vector3(11 + Mathf.Cos(i), 4.5f + Mathf.Sin(i), 3), Quaternion.identity);
			Object.Instantiate(objectToCreate, new Vector3(i, 7 + Mathf.Sin(i), 3), Quaternion.identity);

			//GameObject newSeagull = (GameObject)Object.Instantiate(objectToCreate, new Vector3(i, 0, 0), Quaternion.identity);
			//Renderer objectRenderer = newSeagull.GetComponentInParent<Renderer> ();
			//objectRenderer.material.color = Color.white * Random.value;

		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
