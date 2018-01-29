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

	private List<LightRay> illuminatingRays = new List<LightRay>();

	private bool isReceptacleActive;
	public bool IsReceptacleActive {
		get { return isReceptacleActive; }
		private set {
			if (value != isReceptacleActive) {
				isReceptacleActive = value;
				if (ActiveStateChanged != null) {
					ActiveStateChanged(this, EventArgs.Empty);
				}
				Debug.Log("recept active state now: " + value);
                if (value == true)
                {
                    var portal = GameObject.Find("Portal").GetComponent<Portal>();
                    portal.ActivatePortal();
                }
			}
			if(receptacleRenderer) {
				receptacleRenderer.material = value ? receptacleActiveMaterial : receptacleInactiveMaterial;
			}
		}
	}

	// Use this for initialization
	void Start () {
		receptacleRenderer = this.GetTheFuckingComponent<MeshRenderer>();
		LightRayIlluminated(null, false); // trigger initial state
	}

    internal void LightRayIlluminated(LightRay lightRay, bool isIlluminating)
    {
		if (isIlluminating) {
			if(illuminatingRays.Contains(lightRay)) { return; }
			illuminatingRays.Add(lightRay);
		}
		else if (!isIlluminating) { illuminatingRays.Remove(lightRay); }

		IsReceptacleActive = isWantingLight ? illuminatingRays.Count > 0 : illuminatingRays.Count == 0;
    }
}
