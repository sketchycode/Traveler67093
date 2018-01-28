using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightRay : MonoBehaviour {
    public float radius;

    private Transform cylinderTransform;
    void Start()
    {
        cylinderTransform = GetComponentInChildren<Transform>();
    }

    void Update()
    {
        cylinderTransform.localScale = new Vector3(radius, radius, radius);
    }
}
