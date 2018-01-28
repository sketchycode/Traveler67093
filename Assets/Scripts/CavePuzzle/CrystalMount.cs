using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInteractable))]
public class CrystalMount : MonoBehaviour {
	public Vector2 activatedRayAngles = Vector2.zero;
	public Vector3 lightRayOriginOffset = Vector3.up;

	[HideInInspector]
	public Crystal mountedCrystal;

	public Vector3 LightRayOrigin { get { return transform.position + lightRayOriginOffset; }}
	public Quaternion LightRayRotation { get { return Quaternion.Euler(activatedRayAngles.x, activatedRayAngles.y, 0); }}
	public Vector3 LightRayDirection { get { return LightRayRotation * Vector3.up; }}

	private LightRay activatedLightRay;

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

		activatedLightRay = GetComponentInChildren<LightRay>(true);
		activatedLightRay.transform.position = LightRayOrigin;
		activatedLightRay.transform.rotation = LightRayRotation;

		activatedLightRay.gameObject.SetActive(false);
	}

	private void Update() {
		if (mountedCrystal) {
			activatedLightRay.gameObject.SetActive(mountedCrystal.IsCrystalActivated);
		}
	}

    internal void AcceptCrystal(Crystal crystal)
    {
		crystal.transform.parent = this.transform;
		crystal.transform.localRotation = Quaternion.identity;
		crystal.transform.localPosition = lightRayOriginOffset;
		mountedCrystal = crystal;
    }

	private void OnDrawGizmos() {
		var mountRayDefaultDirection = Vector3.up;

        RaycastHit hitInfo = new RaycastHit();
        Physics.Raycast(LightRayOrigin, LightRayDirection, out hitInfo, 100f, 1 << LayerMask.NameToLayer("LightRayDetectors"));

		Gizmos.DrawLine(LightRayOrigin,
			LightRayOrigin + LightRayDirection * (hitInfo.collider ? hitInfo.distance : 100f)
		);
	}
}
