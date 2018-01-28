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
		Portal portal_activation = new Portal();
		portal_activation.ActivatePortal_PlayerProximal();
        Rigidbody bouncycoconut = GetComponent<Rigidbody>();
        bouncycoconut.isKinematic = false;


    }

    void Update()
    {

    }
}
