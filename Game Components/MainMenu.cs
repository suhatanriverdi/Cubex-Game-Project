using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Büşra Nur Bahadır 201511006
//Süha Tanrıverdi 201611689
public class MainMenu : MonoBehaviour {
    // Main Function which plays the game initially
    public void PlayGame() {
        Hashtable data = SaveSystem.DataLoader();
        if (data == null)
            SceneManager.LoadScene("level_1");
        else
        {   // Loads the Last Played Level for Play Again
            if ((data.Count + 1).ToString() == "4")
            {
                SceneManager.LoadScene("level_3");
            }
            else
            {
                SceneManager.LoadScene("level_" + (data.Count + 1).ToString());
            }
        }
    }

    // When the quit button is pressed, this function exits from application (On PC and Android)
    public void QuitGame() {
        Application.Quit();
    }

    // Loads Scene named loadScene
    public void LoadPlayer()
    {
        SceneManager.LoadScene("loadScene");
    }
    
}
