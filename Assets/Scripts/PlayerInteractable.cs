using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractable : MonoBehaviour {

    public event EventHandler PlayerInteracted;

    public void DoTheInteractThing()
    {
        Debug.Log("interacting a thing");
        if(PlayerInteracted != null)
        {
            PlayerInteracted(this, EventArgs.Empty);
        }
    }
}
