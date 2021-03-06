﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInteractable))]
[RequireComponent(typeof(PortalCenter))]
public class Portal : MonoBehaviour
{
    public bool isPortalActive = false;
    private void Start()
    {
        PlayerInteractable portalInteractive = GetComponent<PlayerInteractable>();
        portalInteractive.PlayerInteracted += InactivatePortal_PlayerInteractable;
		Animator animator = GetComponent<Animator>();
        Rigidbody rigidcoconut = GetComponent<Rigidbody>();
        rigidcoconut.isKinematic = true;
        this.isPortalActive = false;
    }

    void Update()
    {
    }

    public void InactivatePortal_PlayerInteractable(object sender, System.EventArgs e)
    {
        Debug.Log("portal goes places");
    }

    public void ActivatePortal()
    {
        Debug.Log("portal so active right now");
        AudioSource portalActiveMusic = GetComponent<AudioSource>();
        portalActiveMusic.Play();
        MeshRenderer the_portal = GetComponent<MeshRenderer>();
        the_portal.material.color = Color.red;
        this.isPortalActive = true;
        var portal_center = GameObject.Find("PortalCenter").GetComponent<PortalCenter>();
        portal_center.Activate_Center();

    }

    public void LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "amelia")
        {
            SceneManager.LoadScene("cave", LoadSceneMode.Single);
        }
        else if (scene.name == "forest")
        {
            SceneManager.LoadScene("credits", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("forest", LoadSceneMode.Single);
        }
    }
}
