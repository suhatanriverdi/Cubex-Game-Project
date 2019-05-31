using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Büşra Nur BAHADIR 201511006
public class OpenDoor : MonoBehaviour
{

 
   //use to remove fences
    void OnTriggerEnter(Collider collider)
    {
        GameObject collidedWith = collider.gameObject;
        GameObject[] door=GameObject.FindGameObjectsWithTag(this.tag); //collect all objects on the scene with same tag
   
            for (int i = 0; i < door.Length; i++)
            {
                Destroy(door[i]); //destroy them
            }

    }


}