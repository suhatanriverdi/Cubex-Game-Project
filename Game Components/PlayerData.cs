using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Büşra Nur Bahadır
// Player's data to Save 
[System.Serializable]
public class PlayerData
{
    // public string level;

    public Hashtable level = new Hashtable(); // declaration

    public PlayerData(Hashtable player)
    {
        // level= SceneManager.GetActiveScene().name;
       // level[SceneManager.GetActiveScene().name] =player[;
    }
}
