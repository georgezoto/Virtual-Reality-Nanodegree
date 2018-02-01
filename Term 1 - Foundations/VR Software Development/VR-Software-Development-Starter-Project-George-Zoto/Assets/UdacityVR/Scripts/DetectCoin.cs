using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCoin : MonoBehaviour {

	//[Tooltip ("The Animator component on this gameobject")]
	//public Animator animator;
	//[Tooltip ("The name of the Animator trigger parameter")]
	//public string triggerName;


	void FixedUpdate()
	{
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		if (Physics.Raycast (transform.position, fwd, 10)) {
			print ("There is something in front of the object!");

			// If the player pressed the cardboard button (or touched the screen), set the trigger parameter to active (until it has been used in a transition)
			//if (Input.GetMouseButtonDown (0)) {
			//	animator.SetTrigger (triggerName);
			//	print ("animator.SetTrigger (triggerName);");
			//}

		}
	}

}
