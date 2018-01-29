using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProximity : MonoBehaviour
{
    public event EventHandler PlayerProximal;

    public void ActivatePortal()
    {
        if (PlayerProximal != null)
        {
            PlayerProximal(this, EventArgs.Empty);
        }
    }
}
