using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerInput : MonoBehaviour {
	public float speed = 3f;
    public float strafeSpeed = 3f;
    public float rotateSpeed = 3f;
	public float sensitivityX = 10f;
	public Look look;
    
	private List<PlayerInteractable> interactableThings = new List<PlayerInteractable>();
	private CharacterController controller;
	private float inputUpDown;
	private float inputLefRight;
	private bool isInteracting = false;
    
    // Cave Stuff
    private Crystal heldCrystal;
    public bool IsHoldingACrystal { get { return heldCrystal != null; }}
    // ///////////

	void Start() {
		this.controller = GetComponent<CharacterController>();
		look.CopyRotationFromScene ();
	}

    void Update()
    {
		look.updateRotValues ();
		look.updateRotation ();
		this.updateInput ();
		this.MoveCharacter ();
		this.Interact ();
        
    }

	void Interact() {
		if(this.isInteracting && interactableThings.Count > 0)
		{
			for(int i=0; i<interactableThings.Count; i++) {
				interactableThings[i].DoTheInteractThing(this);
			}
		}
	}
		
	void updateInput() {
		this.inputUpDown = Input.GetAxis ("Vertical");
		this.inputLefRight = Input.GetAxis ("Horizontal");
		this.isInteracting = Input.GetKeyDown (KeyCode.Space);
	}

	void MoveCharacter() {
		Vector3 forwardVector = this.inputUpDown * transform.forward;
		Vector3 rightVector = this.inputLefRight * transform.right;

		Vector3 desiredVelocity = forwardVector + rightVector;
		desiredVelocity = Vector3.ClampMagnitude (desiredVelocity, 1);
		desiredVelocity *= speed;

		this.controller.SimpleMove (desiredVelocity);
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
