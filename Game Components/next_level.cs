//Süha Tanrıverdi 201611689

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next_level : MonoBehaviour
{
	
    [SerializeField] private string loadlevel;

	// Check The Player if Collide With Other Objects
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadlevel);
        }
    }
}
