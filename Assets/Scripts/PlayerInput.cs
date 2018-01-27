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
    }
}
