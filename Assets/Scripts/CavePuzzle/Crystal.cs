using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CrystalType { AND, XOR, BLOCKING }

[RequireComponent(typeof(PlayerInteractable))]
public class Crystal : MonoBehaviour {
	public CrystalType crystalType = CrystalType.AND;

	private PlayerInteractable playerInteractable;

	void Start () {
		playerInteractable = GetComponent<PlayerInteractable>();
		playerInteractable.PlayerInteractedAction = (player) => {
			var rb = this.GetTheFuckingComponent<Rigidbody>();
			rb.isKinematic = true;
			player.PickUpCrystal(this);
		};

		playerInteractable.CanPlayerInteract = (player) => {
			Debug.Log("can we interact with this crystal?");
			return player.IsHoldingACrystal == false;
		};

		// TODO: set appropriate material and/or model
	}
}
