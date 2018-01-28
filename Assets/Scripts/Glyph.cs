using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInteractable))]
[RequireComponent(typeof(Portal))]
public class Glyph : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        PlayerInteractable glyphinteractive = GetComponent<PlayerInteractable>();
        glyphinteractive.PlayerInteracted += Glyphinteractive_PlayerInteracted;
        MeshRenderer visibleTranslation = GetComponent<MeshRenderer>();
        visibleTranslation.enabled = false;
    }

    private void Glyphinteractive_PlayerInteracted(object sender, System.EventArgs e)
    {
        Debug.Log("test stuff");
        MeshRenderer visibleTranslation = GetComponent<MeshRenderer>();
        visibleTranslation.enabled = true;
        transform.LookAt(target);
    }

    void Update()
    {

    }
}
