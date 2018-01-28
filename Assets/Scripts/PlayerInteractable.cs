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
        }
    }
}
