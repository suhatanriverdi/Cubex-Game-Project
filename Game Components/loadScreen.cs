using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class loadScreen : MonoBehaviour
{
    
    public Button[] levels;
    public Text[] Score;
    // Start is called before the first frame update
    void Start()
    {
        
       
        
        for (int i = 0; i < levels.Length; ++i)
            levels[i].interactable = false;
        Hashtable data = SaveSystem.DataLoader();
        if (data != null)
        {
           
            for (int i = 0; i < data.Count; ++i)
            {
                levels[i].interactable = true;
                Score[i].text = "Points:" + data["level_" + (i + 1).ToString()];
                
            }
        }
        

    }
    public void leveltoLoad(int level)
    {
     
        SceneManager.LoadScene("level_"+level);
    }
    // Update is called once per frame
    public void reset()
    {
        SaveSystem.Reset();
        SceneManager.LoadScene("loadScene");
    }
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
}
