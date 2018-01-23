using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMaker : MonoBehaviour {

	public GameObject objectToCreate;

	// Use this for initialization
	void Start () {
		// make an object here
		Object.Instantiate(objectToCreate, new Vector3(2, 4, 6), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
