//Süha Tanrıverdi 201611689

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuSound : MonoBehaviour
{
	
    public AudioSource hoverFX;
    public AudioSource clickFX;

    // Play Sound when Mouse Hover on Menu Button
    public void hoverSound()
    {
        hoverFX.Play();
    }

    // Play Sound when Mouse Click on Menu Button
    public void clickSound()
    {
        clickFX.Play();
    }
}
