//Büşra Nur Bahadır 201511006
//Süha Tanrıverdi 201611689

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GOMenu : MonoBehaviour
{
    // Fixes Play Again Problem while passing to next level
    public string levelTest;
    public string bindHandler;
    public void Restart()
    {	
        levelTest = "1";
        //bindHandler = "";
        Hashtable data = SaveSystem.DataLoader();
        if (data != null)
        {   //if(levelTest == 1) levelTest = 0; 
            if((data.Count + 1).ToString() == "4") // If Level_4 Found then Load Level_3
            {
                SceneManager.LoadScene("level_3");
            }
            else
            {
                SceneManager.LoadScene("level_" + (data.Count+1).ToString());
            }  
        }
        else
        {
            SceneManager.LoadScene("level_1");
        }
    }

    public void Menu()
    {
        levelTest = "next";
        SceneManager.LoadScene("menu");
    }
}
