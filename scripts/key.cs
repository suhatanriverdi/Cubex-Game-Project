using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class key : MonoBehaviour
{
    public bool isSolved = false;
  
    void OnTriggerEnter(Collider collider)
    {
        GameObject collidedWith = collider.gameObject;
        GameObject[] door=GameObject.FindGameObjectsWithTag(this.tag);
   
            for (int i = 0; i < door.Length; i++)
            {
                Destroy(door[i]);
            }

        

    }


}