using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInteractable))]
[RequireComponent(typeof(Portal))]
public class Glyph : MonoBehaviour
{
    private void Start()
    {
        PlayerInteractable glyphinteractive = GetComponent<PlayerInteractable>();
        glyphinteractive.PlayerInteracted += Glyphinteractive_PlayerInteracted;
    }

    private void Glyphinteractive_PlayerInteracted(object sender, System.EventArgs e)
    {
        Debug.Log("test glyph");
    }

    void Update()
    {

    }
}
