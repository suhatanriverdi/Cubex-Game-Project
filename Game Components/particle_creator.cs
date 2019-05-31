//Süha Tanrıverdi 201611689

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_creator : MonoBehaviour
{
    public GameObject deathExplosion;

    private void Update()
    {   //If the player is dead(has a death time)

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject go = Instantiate(deathExplosion) as GameObject;
            go.transform.position = transform.localPosition;
        }
    }
}
