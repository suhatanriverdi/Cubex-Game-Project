using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

//Zehra KASAP 201611678,Büşra Nur BAHADIR 201511006
public class loadScreen : MonoBehaviour
{
    
    public Button[] levels;
    public Text[] Score;
    // Start is called before the first frame update
    void Start()
    {
         //disable all buttons 
        for (int i = 0; i < levels.Length; ++i)
            levels[i].interactable = false;
        Hashtable data = SaveSystem.DataLoader();
        if (data != null)
        {
           
            for (int i = 0; i < data.Count; ++i)
            {
                levels[i].interactable = true; //enable played level's buttons
                Score[i].text = "Points:" + data["level_" + (i + 1).ToString()]; //write scores
                
            }
        }
        

    }
    //load selected enabled level
    public void leveltoLoad(int level)
    {
     
        SceneManager.LoadScene("level_"+level);
    }
    // Update is called once per frame
    public void reset()
    {
        SaveSystem.Reset(); //delete player data
        SceneManager.LoadScene("loadScene"); 
    }
    //go to Main Menu
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
}
