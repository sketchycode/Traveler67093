using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour {

    public float speed = 3f;
    public float strafeSpeed = 3f;
    public float rotateSpeed = 3f;

    public float sensitivityX = 10f;

    public Transform lookCamera;

    private List<PlayerInteractable> interactableThings = new List<PlayerInteractable>();
    
    // Cave Stuff
    private Crystal heldCrystal;
    public bool IsHoldingACrystal { get { return heldCrystal != null; }}
    // ///////////
    

    private void Start()
    {
        lookCamera = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);

        Vector3 right = transform.TransformDirection(Vector3.right);
        float curStrafeSpeed = Input.GetAxis("Horizontal") * strafeSpeed;
        controller.SimpleMove(right * curStrafeSpeed);

        float rot = Input.GetAxis("Mouse X") * sensitivityX;

        transform.Rotate(Vector3.up, rot);

        if(Input.GetKeyDown(KeyCode.Space) && interactableThings.Count > 0)
        {
            for(int i=0; i<interactableThings.Count; i++) {
                interactableThings[i].DoTheInteractThing(this);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var interactableThing = other.GetTheFuckingComponent<PlayerInteractable>();
        if (interactableThing != null && interactableThing.tag != "Player")
        {
            interactableThings.Add(interactableThing);

            var portal = interactableThing.GetTheFuckingComponent<Portal>();
            if (portal != null && portal.isPortalActive)
            {
                portal.LoadNextScene();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactableThings.Remove(other.GetTheFuckingComponent<PlayerInteractable>());
    }


    // cave methods
    public void PickUpCrystal(Crystal crystal) {
        if(heldCrystal == null) {
            heldCrystal = crystal;

            crystal.transform.parent = this.transform;
            crystal.transform.localRotation = Quaternion.identity;
            crystal.transform.localPosition = (Vector3.forward * .6f + Vector3.right * .4f);

            interactableThings.Remove(crystal.GetTheFuckingComponent<PlayerInteractable>());
        }
    }

    public void SetCrystalInMount(CrystalMount mount) {
        if(heldCrystal != null) {
            mount.AcceptCrystal(heldCrystal);
            heldCrystal = null;
        }
    }
    // ////////////
}
