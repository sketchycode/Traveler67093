using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInteractable))]
[RequireComponent(typeof(Portal))]
public class Coconut : MonoBehaviour
{
    private void Start()
    {
        PlayerInteractable coconutinteractive = GetComponent<PlayerInteractable>();
        coconutinteractive.PlayerInteracted += Coconutinteractive_PlayerInteracted;
        Rigidbody rigidcoconut = GetComponent<Rigidbody>();
        rigidcoconut.isKinematic = true;
    }

    private void Coconutinteractive_PlayerInteracted(object sender, System.EventArgs e)
	{
        Rigidbody bouncycoconut = GetComponent<Rigidbody>();
        bouncycoconut.isKinematic = false;

        Debug.Log("coconut fell");
        var portal = GameObject.Find("Portal").GetComponent<Portal>();
        portal.ActivatePortal();
        //Play coconut fell sound and stop sand mice/beach sound source
        //also play actual coconut fell sound effect.
    }

    void Update()
    {

    }
}
