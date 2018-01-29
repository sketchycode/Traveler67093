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
        Renderer center = GetComponent<Renderer>();
        center.enabled = true;
    }
}