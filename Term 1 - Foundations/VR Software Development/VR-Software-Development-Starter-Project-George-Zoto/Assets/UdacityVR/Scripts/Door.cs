using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    // Create a boolean value called "opening" that can be checked in Update() 
	private bool Locked = true;
	private bool Opening = false;

	void Start() {
		print("Door.cs: Start() "+Locked+": "+Opening);
		Locked = true;
		Opening = false;
	}

	void Update() {
		print("Door.cs: Update() "+Locked+": "+Opening);
        // If the door is opening and it is not fully raised
            // Animate the door raising up
    }

    public void OnDoorClicked() {
		print("Door.cs: OnDoorClicked() "+Locked+": "+Opening);
        // If the door is clicked and unlocked
            // Set the "opening" boolean to true
        // (optionally) Else
            // Play a sound to indicate the door is locked
		if (Locked == false) {
			print("Door.cs: OnDoorClicked(): Opening = true;");
			Opening = true;
		} else {
			print("Door.cs: OnDoorClicked(): Play a sound to indicate the door is locked");
		}
    }

    public void Unlock()
    {
        // You'll need to set "locked" to false here
		print("Door.cs: Unlock() "+Locked+": "+Opening);
		Locked = false;
    }
}
