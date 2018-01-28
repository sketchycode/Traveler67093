using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptacle : MonoBehaviour {
	public bool isWantingLight = true;
	public Material receptacleActiveMaterial;
	public Material receptacleInactiveMaterial;

	private MeshRenderer receptacleRenderer;

	public event EventHandler ActiveStateChanged;

	private bool isActive;
	public bool IsActive {
		get { return isActive; }
		private set {
			if (value != isActive){
				isActive = value;
				if (ActiveStateChanged != null) {
					ActiveStateChanged(this, EventArgs.Empty);
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		receptacleRenderer = GetComponentInChildren<MeshRenderer>();	
	}
	
	public void SetLightReceiving(bool isGettingLight) {
		IsActive = isGettingLight && isWantingLight;
		receptacleRenderer.material = (isGettingLight && isWantingLight) ? receptacleActiveMaterial : receptacleInactiveMaterial;
	}
}
