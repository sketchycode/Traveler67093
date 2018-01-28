using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
	public float speed;
	public Transform[] spinLeft;
	public Transform[] spinRight;

	void Update () {
		this.Rotate (spinRight, false);
		this.Rotate (spinLeft, true);
	}

	private void Rotate(Transform[] array, bool doReverseSpeed) {
		float desiredSpeed = this.speed;
		if (doReverseSpeed) {
			desiredSpeed *= -1;
		}

		foreach (Transform item in array) {
			item.Rotate(new Vector3(0, desiredSpeed, 0));
		}
	}
}
