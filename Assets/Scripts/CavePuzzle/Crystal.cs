using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CrystalType { AND, XOR, BLOCKING }

[RequireComponent(typeof(PlayerInteractable))]
public class Crystal : MonoBehaviour {
	public CrystalType crystalType = CrystalType.AND;

	private PlayerInteractable playerInteractable;
	private List<LightRay> illuminatingRays = new List<LightRay>();

	public bool IsCrystalActivated {
		get {
			switch(crystalType) {
				case CrystalType.AND: return illuminatingRays.Count == 2;
				case CrystalType.XOR: return illuminatingRays.Count == 1;
				case CrystalType.BLOCKING: return false;
				default: return false;
			}
		}
	}

	void Start () {
		playerInteractable = GetComponent<PlayerInteractable>();
		playerInteractable.PlayerInteractedAction = (player) => {
			var rb = this.GetTheFuckingComponent<Rigidbody>();
			rb.isKinematic = true;
			player.PickUpCrystal(this);
		};

		playerInteractable.CanPlayerInteract = (player) => {
			return player.IsHoldingACrystal == false;
		};

		// TODO: set appropriate material and/or model
	}

	public void LightRayIlluminated(LightRay lightRay, bool isIlluminating) {
		if (isIlluminating) {
			if(illuminatingRays.Contains(lightRay)) { return; }
			illuminatingRays.Add(lightRay);
			Debug.Log("crystal getting light, now at " + illuminatingRays.Count + ", isActive: " + IsCrystalActivated);
		}
		else if (!isIlluminating) { illuminatingRays.Remove(lightRay); }
	}
}
