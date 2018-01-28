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
		Animator animator = GetComponent<Animator>();
    }

    void Update()
    {
    }

    public void InactivatePortal_PlayerProximal(object sender, System.EventArgs e)
    {
    }

    public void ActivatePortal()
    {
        Debug.Log("portal so active right now");
        MeshRenderer the_portal = GetComponent<MeshRenderer>();
        the_portal.material.color = Color.red;
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
