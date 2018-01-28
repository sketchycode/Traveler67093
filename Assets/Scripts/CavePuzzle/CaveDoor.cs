using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveDoor : MonoBehaviour {

	public Receptacle[] receptacles;
	public Vector3 doorOpenedPosition;
	public float doorOpenTime = 10f;

	private bool isDoorOpened = false;
	private Vector3 currentOpenVelocity;
	
	private void Start() {
		for(int i=0; i<receptacles.Length; i++) {
			
			Debug.Log("door subbing");
			receptacles[i].ActiveStateChanged += HandleReceptacleActiveStateChanged;
		}
	}

	private void Update() {
		if(isDoorOpened) {
			transform.position = Vector3.SmoothDamp(transform.position, doorOpenedPosition, ref currentOpenVelocity, doorOpenTime);
		}
	}

	private void HandleReceptacleActiveStateChanged(object sender, EventArgs args) {
		Debug.Log("door got the recept active state change");
		for(int i=0; i<receptacles.Length; i++) {
			if(!receptacles[i].IsReceptacleActive) {
				return;
			}
		}

		OpenDoor();
	}

	public void OpenDoor() {
		if(!isDoorOpened) {
			isDoorOpened = true;
		}
	}
}
