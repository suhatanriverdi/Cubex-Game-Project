using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

    [SerializeField] private Transform Cube;
    [SerializeField] private Transform RespawnPoint;
    void OnTriggerEnter(Collider other) {
        Cube.transform.position = RespawnPoint.transform.position;
    }
}
    