using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerProximity))]
public class Portal : MonoBehaviour
{
    private void Start()
    {
        PlayerProximity portalInteractive = GetComponent<PlayerProximity>();
        portalInteractive.PlayerProximal += InactivatePortal_PlayerProximal;
    }

    void Update()
    {
    }

    private void InactivatePortal_PlayerProximal(object sender, System.EventArgs e)
    {
        //SceneManager.LoadScene("cave", LoadSceneMode.Additive);
    }

    private void ActivatePortal_PlayerProximal(object sender, System.EventArgs e)
    {
    }
}
