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
            interactableThings[0].DoTheInteractThing();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("in trigger");
        var interactableThing = other.GetComponent<PlayerInteractable>();
        if (interactableThing != null)
        {
            interactableThings.Add(interactableThing);
            Debug.Log("we found an interactable thing!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactableThings.Remove(other.GetComponent<PlayerInteractable>());
    }
}
