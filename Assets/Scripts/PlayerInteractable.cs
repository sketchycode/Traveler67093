using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(AudioPlay))]
public class PlayerInteractable : MonoBehaviour {

    public event EventHandler PlayerInteracted;
    public Func<PlayerInput, bool> CanPlayerInteract;
    public Action<PlayerInput> PlayerInteractedAction;
    public string Scene;

    public void DoTheInteractThing(PlayerInput player)
    {
        if(CanPlayerInteract == null || CanPlayerInteract(player)) {
            if (PlayerInteracted != null) { PlayerInteracted(this, EventArgs.Empty); }
            if (PlayerInteractedAction != null) { PlayerInteractedAction(player); }
        }
    }
}
