using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerProximity))]
public class Portal : MonoBehaviour
{
		public bool portal_is_activated = false;

    private void Start()
    {
        PlayerProximity portalInteractive = GetComponent<PlayerProximity>();
        portalInteractive.PlayerProximal += InactivatePortal_PlayerProximal;
		Animator animator = GetComponent<Animator>();
    }

    void Update()
    {
    }

    public void InactivatePortal_PlayerProximal(object sender, System.EventArgs e)
    {
//		portal_is_activated = false;
    }

    public void ActivatePortal_PlayerProximal()
    {
		Debug.Log("hello world!");
//		portal_is_activated = true;
    }
}
