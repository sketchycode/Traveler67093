using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInteractable))]
public class CrystalMount : MonoBehaviour {

	public Crystal mountedCrystal;

	// Use this for initialization
	void Start () {
		PlayerInteractable playerInteractable = GetComponent<PlayerInteractable>();
		
		playerInteractable.PlayerInteractedAction = (player) => {
			if(mountedCrystal != null) {
				player.PickUpCrystal(mountedCrystal);
				mountedCrystal = null;
			}
			else {
				player.SetCrystalInMount(this);
			}
		};

		playerInteractable.CanPlayerInteract = (player) => {
			return (player.IsHoldingACrystal && mountedCrystal == null) || (!player.IsHoldingACrystal && mountedCrystal != null);
		};
	}

    private void HandlePlayerInteracted(object sender, EventArgs e)
    {
		Debug.Log("CrystalMount says: player set a crystal in me");
    }

    internal void AcceptCrystal(Crystal crystal)
    {
		crystal.transform.parent = this.transform;
		crystal.transform.localRotation = Quaternion.identity;
		crystal.transform.localPosition = Vector3.up * 1f;
		mountedCrystal = crystal;
    }
}
