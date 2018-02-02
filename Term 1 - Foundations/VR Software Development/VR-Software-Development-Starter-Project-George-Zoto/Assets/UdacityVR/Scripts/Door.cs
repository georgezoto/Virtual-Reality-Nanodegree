using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    // Create a boolean value called "opening" that can be checked in Update() 
	private bool Locked = true;
	private bool Opening = false;

	public AudioClip[] soundFiles;
	public AudioSource soundSource;
	private int soundindex;

	void Start() {
		print("Door.cs: Start() "+Locked+": "+Opening);
		Locked = true;
		Opening = false;
		soundindex = 0;
	}

	void Update() {
		print("Door.cs: Update() "+Locked+": "+Opening);
        // If the door is opening and it is not fully raised
            // Animate the door raising up
		if (Opening && transform.position.y < 7) {
			transform.Translate (0f, Time.deltaTime, 0f, Space.World);
		}
    }

    public void OnDoorClicked() {
		print("Door.cs: OnDoorClicked() "+Locked+": "+Opening);
        // If the door is clicked and unlocked
            // Set the "opening" boolean to true
        // (optionally) Else
            // Play a sound to indicate the door is locked
		if (!Locked) {
			print("Door.cs: OnDoorClicked(): Opening = true;");
			Opening = true;
			soundindex = 1;
			soundSource.clip = soundFiles [soundindex];
			soundSource.Play ();
		} else {
			soundindex = 0;
			print("Door.cs: OnDoorClicked(): Play a sound to indicate the door is locked");
			soundSource.clip = soundFiles [soundindex];
			soundSource.Play ();
		}
    }

    public void Unlock()
    {
        // You'll need to set "locked" to false here
		print("Door.cs: Unlock() "+Locked+": "+Opening);
		Locked = false;
    }
}
