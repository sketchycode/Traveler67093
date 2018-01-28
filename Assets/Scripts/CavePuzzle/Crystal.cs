using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CrystalType { AND, XOR, BLOCKING }

[RequireComponent(typeof(PlayerInteractable))]
public class Crystal : MonoBehaviour {
	public CrystalType crystalType = CrystalType.AND;

    public Material andMaterial;
    public Material orMaterial;
    public Material blockingMaterial;

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
			player.PickUpCrystal(this);
		};

		playerInteractable.CanPlayerInteract = (player) => {
			return player.IsHoldingACrystal == false;
		};

        var renderer = GetComponentInChildren<Renderer>();
		switch (crystalType)
        {
            case CrystalType.AND: renderer.material = andMaterial; break;
            case CrystalType.XOR: renderer.material = orMaterial; break;
            case CrystalType.BLOCKING: renderer.material = blockingMaterial; break;
        }
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
