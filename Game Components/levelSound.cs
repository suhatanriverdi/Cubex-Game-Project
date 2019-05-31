using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Süha Tanrıverdi 201611689
public class levelSound : MonoBehaviour
{
    // Adds an audio source for each related object
    public AudioSource audioClip;
    void OnTriggerEnter(Collider collider)
    {
        // Plays Inputted Sound
        audioClip.Play();
    }
}
