using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public string level;
  

    public PlayerData(GameController player)
    {
        level= SceneManager.GetActiveScene().name;
     
    }
}
