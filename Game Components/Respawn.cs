//Süha Tanrıverdi 201611689

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    // Creates A Game Object For Death Particle Effect
    public GameObject deathExplosion;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform RespawnPoint;

    // Creates an Audio Source
    public AudioSource audioClip;
    void OnTriggerEnter(Collider other) {
        audioClip.Play();
        GameObject go = Instantiate(deathExplosion) as GameObject;
        go.transform.position = GameObject.FindWithTag("Player").transform.localPosition;
        Player.transform.position = RespawnPoint.transform.position; // Teleport Player
    }
}