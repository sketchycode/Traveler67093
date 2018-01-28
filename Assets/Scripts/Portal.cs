﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInteractable))]
public class Portal : MonoBehaviour
{
    public string portalState = "active";

    private void Start()
    {
        PlayerInteractable portalInteractive = GetComponent<PlayerInteractable>();
        portalInteractive.PlayerInteracted += InactivatePortal_PlayerInteractable;
		Animator animator = GetComponent<Animator>();
        Rigidbody rigidcoconut = GetComponent<Rigidbody>();
        rigidcoconut.isKinematic = true;
        this.portalState = "inactive";
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
        this.portalState = "active";
    }

    public void LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "amelia")
        {
            SceneManager.LoadScene("cave", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("forest", LoadSceneMode.Single);
        }
    }
}
