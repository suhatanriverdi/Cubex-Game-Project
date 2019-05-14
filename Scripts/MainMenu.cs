using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGame() {
        // Or we can use below code; it is working according to the build number
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("level_1");
    }

    public void QuitGame() {
        // We test if it is really working
        //Debug.Log("QUIT!...");
        Application.Quit();
    }
}
