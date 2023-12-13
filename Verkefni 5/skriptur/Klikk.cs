using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Klikk : MonoBehaviour
{
    //Takki til að byrja leik
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
}
