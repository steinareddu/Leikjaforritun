using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{ 
    public GameObject obstaclePrefab;
    //skilgreinum hvar hluturinn � a� birtast
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    //skilgreinum delay og repeaterate � endurtekningum
    private float startDelay = 2;
    private float repeatRate = 2;
    // s�kjum refrence � annari skriptu 
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        // finnum skriptuna fyrir PlayerController.
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        //Passar a� ef leikurinn h�ttir/game over �� h�ttir hann a� spawna n�jum veggjum
        if (playerControllerScript.gameOver == false) 
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        } 

    }
}
