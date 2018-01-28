using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveDoor : MonoBehaviour {

	public Receptacle[] receptacles;

	private bool isDoorOpened = false;
	
	private void Start() {
		for(int i=0; i<receptacles.Length; i++) {
			receptacles[i].ActiveStateChanged += HandleReceptacleActiveStateChanged;
		}
	}

	private void HandleReceptacleActiveStateChanged(object sender, EventArgs args) {
		for(int i=0; i<receptacles.Length; i++) {
			if(!receptacles[i].IsActive) {
				return;
			}
		}

		OpenDoor();
	}

	public void OpenDoor() {
		if(!isDoorOpened) {
			Debug.Log("door opening");
		}
	}
}
