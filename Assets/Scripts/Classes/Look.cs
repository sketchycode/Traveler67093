using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Look {
	public Transform body;
	public Transform camera;
	public float minRot;
	public float maxRot;
	public float cameraRotX;
	public float bodyRotY;
	public float sensitivity;

	public void CopyRotationFromScene () {
		this.cameraRotX = camera.eulerAngles.x;
		this.bodyRotY = body.eulerAngles.y;
	}

	public void updateRotValues() {
		float deltaX = Input.GetAxis ("Mouse Y") * -this.sensitivity;
		float deltaY = Input.GetAxis ("Mouse X") * this.sensitivity;
		Debug.Log (deltaX);
		this.bodyRotY = this.bodyRotY + deltaY;
		this.cameraRotX = Mathf.Clamp(this.cameraRotX + deltaX, this.minRot, this.maxRot);;
	}

	public void updateRotation() {
		this.body.eulerAngles = new Vector3(this.body.eulerAngles.x, this.bodyRotY, this.body.eulerAngles.z);
		this.camera.eulerAngles = new Vector3(this.cameraRotX, this.camera.eulerAngles.y, this.camera.eulerAngles.z);
	}
}