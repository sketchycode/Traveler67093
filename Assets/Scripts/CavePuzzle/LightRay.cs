using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class LightRay : MonoBehaviour {
    public LayerMask lightColliders;

    private Transform currentIlluminatedTarget;
    public Transform CurrentIlluminatedTarget {
        get { return currentIlluminatedTarget; }
        set {
            if(value != currentIlluminatedTarget) {
                SetCurrentIlluminatedTarget(false);
                currentIlluminatedTarget = value;
                SetCurrentIlluminatedTarget(true);
            }
        }
    }

    private Transform lightRayModel;

    private void Start() {
        lightRayModel = transform.GetChild(0).transform; // super brittle, bad, don't do this
    }

    private void Update() {
        RaycastHit hitInfo = new RaycastHit();
        Physics.Raycast(transform.position, transform.rotation * Vector3.up, out hitInfo, 100f, lightColliders);

        lightRayModel.localScale = new Vector3(1f, hitInfo.collider != null ? hitInfo.distance * .5f : 100f, 1f);

        CurrentIlluminatedTarget = hitInfo.collider ? hitInfo.collider.transform : null;
    }

    private void OnDisable() {
        CurrentIlluminatedTarget = null;
    }

    private void SetCurrentIlluminatedTarget(bool isIlluminating) {
        if(currentIlluminatedTarget == null) { return; }

        var mount = currentIlluminatedTarget.GetTheFuckingComponent<CrystalMount>();
        if(mount && mount.mountedCrystal != null) {
            mount.mountedCrystal.LightRayIlluminated(this, isIlluminating);
            return;
        }

        var recept = currentIlluminatedTarget.GetTheFuckingComponent<Receptacle>();
        if(recept) {
            recept.LightRayIlluminated(this, isIlluminating);
        }
    }
}
