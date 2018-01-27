using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractable : MonoBehaviour {

    public event EventHandler PlayerInteracted;

    public void DoTheInteractThing()
    {
        if(PlayerInteracted != null)
        {
            PlayerInteracted(this, EventArgs.Empty);
        }
    }
}
