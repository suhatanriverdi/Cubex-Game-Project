using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    ///Büşra Nur BAHADIR 201511006----------------------------------------------------
    public void PlayGame() {
        Hashtable data = SaveSystem.DataLoader();
        if (data == null)
            SceneManager.LoadScene("level_1");
        else
        {
            SceneManager.LoadScene("level_" + (data.Count+1).ToString());
        }
    }
    public void LoadPlayer()
    {
        SceneManager.LoadScene("loadScene");
    }
    //-----------------------------------------------------------------------------------
    public void QuitGame() {
        Application.Quit();
    }

  
    
}
