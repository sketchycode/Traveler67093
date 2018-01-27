using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInteractable))]
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
    }

    void Update()
    {

    }
}
