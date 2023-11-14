using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Takki : MonoBehaviour
{
    public TextMeshProUGUI texti;
   
    public void Start()
    {   
        //Ef leikurinn er búinn er tilkynnt lokastig.
        if (SceneManager.GetActiveScene().buildIndex==3)
        {
            texti.text = "Lokastig " + PlayerMovment.count.ToString();
        }
        
    }
    public void Byrja()
    {
        SceneManager.LoadScene(1);
        //Set stig sem 20 ef hann vill spila aftur
        PlayerMovment.count = 20;
    }
    public void Endir()
    {
        SceneManager.LoadScene(0);
        PlayerMovment.count = 0;
    }
    
}
