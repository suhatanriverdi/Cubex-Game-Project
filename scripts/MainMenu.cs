using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGame() {
        PlayerData data = SaveSystem.DataLoader();
        if (data == null)
            SceneManager.LoadScene("level_1");
        else
        {
            int x = data.level[data.level.Length - 1] - '0';
            SceneManager.LoadScene("level_" + (x + 1).ToString());
        }
    }

    public void QuitGame() {
        // We test if it is really working
        //Debug.Log("QUIT!...");
        Application.Quit();
    }

    public void LoadPlayer()
    {
        SceneManager.LoadScene("loadScene");
    }
    
}
