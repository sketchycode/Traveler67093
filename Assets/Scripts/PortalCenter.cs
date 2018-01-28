using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCenter : MonoBehaviour
{
    public void Start() 
    {

    }

    public void Activate_Center() 
    {
        Debug.Log("hello");
        Renderer center = GetComponent<Renderer>();
        center.enabled = true;
    }
}