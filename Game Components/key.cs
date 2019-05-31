using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Büşra Nur Bahadır 201511006
//Süha Tanrıverdi 201611689
public class key : MonoBehaviour
{   // Adds an audio source for each related object
    public AudioSource audioClip;
    //public string soundTest;
    void OnTriggerEnter(Collider collider)
    {
        // Plays Inputted Sound
        audioClip.Play();
        GameObject collidedWith = collider.gameObject;
        GameObject[] door=GameObject.FindGameObjectsWithTag(this.tag); //collect all objects on the scene with same tag
            for (int i = 0; i < door.Length; i++)
            {
                Destroy(door[i]); //destroy them
            }
    }
}