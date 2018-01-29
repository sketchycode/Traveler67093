using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandMice : MonoBehaviour
{
    public void Start()
    {

    }

    public void Deactivate_Sandmice() {
        AudioSource activeMusic = GetComponent<AudioSource>();
        activeMusic.Stop();
    }
}