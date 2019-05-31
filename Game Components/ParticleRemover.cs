//Süha Tanrıverdi 201611689

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRemover : MonoBehaviour {

    public GameObject removedParticle;
	// Update is called once per frame
	void Update () {
        Destroy(GameObject.FindWithTag("destroyed"), 1.1f);
        Destroy(GameObject.FindWithTag("plevelPrintDestroyed"), 2.2f);
    }
}
