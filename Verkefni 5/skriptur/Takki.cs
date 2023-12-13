using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Takki : MonoBehaviour
{
    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Byrja()//Callar á scenu nr 1, sem er leikurinn, þegar ýtt er á takkann
    {
        SceneManager.LoadScene(1);
    }
    public void Endir()
    {
        SceneManager.LoadScene(2);
       
    }
    
}
