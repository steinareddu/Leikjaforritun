using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // skilgreini hra�abreytu
    private float speed = 30;
    //breyta til geyma PlayerController skriptuna
    private PlayerController playerControllerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        //s�ki PlayerController skriptuna
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //ef leikurinn er ekki b�inn �� hleypur hann/allt f�rist til vinstri � hra�anum sem er stilltur
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
