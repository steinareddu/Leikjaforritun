using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // skilgreini hraðabreytu
    private float speed = 30;
    //breyta til geyma PlayerController skriptuna
    private PlayerController playerControllerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        //sæki PlayerController skriptuna
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //ef leikurinn er ekki búinn þá hleypur hann/allt færist til vinstri á hraðanum sem er stilltur
        if (playerControllerScript.gameOver == false) 
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        if (transform.position.x < leftBound && gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        
    }
}
