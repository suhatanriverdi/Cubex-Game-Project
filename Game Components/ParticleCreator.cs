//Süha Tanrıverdi 201611689

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCreator : MonoBehaviour {
    public GameObject particle;
    // Creates an Audio Source
    public AudioSource audioClip;
    private void OnTriggerEnter(Collider other) {
        audioClip.Play();
        GameObject go = Instantiate(particle) as GameObject;
        go.transform.position = GameObject.FindWithTag("Player").transform.localPosition;
        Destroy(gameObject); // Destroys Current Object
    }
}