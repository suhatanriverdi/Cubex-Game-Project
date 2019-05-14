using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public GameObject deathExplosion;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform RespawnPoint;
    void OnTriggerEnter(Collider other) {
        GameObject go = Instantiate(deathExplosion) as GameObject;
        go.transform.position = GameObject.FindWithTag("Player").transform.localPosition;
        Player.transform.position = RespawnPoint.transform.position; // Teleport Player
    }
}