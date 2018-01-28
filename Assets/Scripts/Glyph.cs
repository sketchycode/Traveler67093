﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInteractable))]
[RequireComponent(typeof(Portal))]
public class Glyph : MonoBehaviour
{
    public Transform target;
    //sdouble[] GlyphAry = { "Translation1", "Translation2", "Translation3" };

    private void Start()
    {
        PlayerInteractable glyphinteractive = GetComponent<PlayerInteractable>();
        glyphinteractive.PlayerInteracted += Glyphinteractive_PlayerInteracted;
        MeshRenderer visibleTranslation = GetComponent<MeshRenderer>();
        visibleTranslation.enabled = false;
        var transformtext = GameObject.Find("Translation2").GetComponent<MeshRenderer>();
        transformtext.enabled = false;
    }

    private void Glyphinteractive_PlayerInteracted(object sender, System.EventArgs e)
    {
        MeshRenderer visibleTranslation = GetComponent<MeshRenderer>();
        var transformtext = GameObject.Find("Translation2").GetComponent<MeshRenderer>();
        visibleTranslation.enabled = true;
        transformtext.enabled = true;
        transform.LookAt(target);
    }

    void Update()
    {

    }
}
