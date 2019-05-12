using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GOMenu : MonoBehaviour
{
   

    public void Restart()
    {  
        PlayerData data = SaveSystem.DataLoader();
        if (data != null)
        {
            int x = data.level[data.level.Length - 1] - '0';
            SceneManager.LoadScene("level_" + (x + 1).ToString());
        }
        

    }
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
}
