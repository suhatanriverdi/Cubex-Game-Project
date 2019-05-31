using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Büşra Nur BAHADIR 201511006
public class GOMenu : MonoBehaviour
{
   
    //Restart the level
    public void Restart()
    {  
        //get last saved level+1
        Hashtable data = SaveSystem.DataLoader();
        if (data != null)
        {
            SceneManager.LoadScene("level_" + (data.Count+1).ToString());
        }
    }

    //go to main menu
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
}
