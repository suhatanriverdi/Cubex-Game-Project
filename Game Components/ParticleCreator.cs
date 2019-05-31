using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCreator : MonoBehaviour {
    public GameObject particle;
    private void OnTriggerEnter(Collider other) {
        GameObject go = Instantiate(particle) as GameObject;
        go.transform.position = GameObject.FindWithTag("Player").transform.localPosition;
        Destroy(gameObject); // Destroys Current Object
    }
}