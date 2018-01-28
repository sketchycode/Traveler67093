using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioPlay))]
public class PlayerInteractable : MonoBehaviour {

    public event EventHandler PlayerInteracted;
    public string Scene;

    public void DoTheInteractThing()
    {
        Debug.Log("interacting a thing");
        if(PlayerInteracted != null)
        {
            PlayerInteracted(this, EventArgs.Empty);
            LoadNextScene();
        }
    }
    public void LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "amelia"){
            SceneManager.LoadScene("cave", LoadSceneMode.Single);
        }else{
            SceneManager.LoadScene("forest", LoadSceneMode.Single);
        }
    }
}
