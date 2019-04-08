using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_remover : MonoBehaviour {

    public GameObject dt;
	// Update is called once per frame
	void Update () {
        Destroy(GameObject.FindWithTag("destroyed"), 1.6f);
    }
}
