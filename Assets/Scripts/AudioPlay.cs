using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInteractable))]
public class AudioPlay : MonoBehaviour
{
    public AudioSource sound;

    private void Start()
    {
        PlayerInteractable interactiveSound = GetComponent<PlayerInteractable>();
        interactiveSound.PlayerInteracted += PlaySound_PlayerInteracted;
    }

    private void PlaySound_PlayerInteracted(object sender, System.EventArgs e)
    {
        Debug.Log("Test sound");
        //sound.Play();
    }

    void Update()
    {

    }
}
