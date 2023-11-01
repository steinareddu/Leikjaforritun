using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // skilgreini speed hérna svo þægilegra sé að breyta
    public float speed = 5.0f;
    // Skilgreini beygjuhraða
    public float turnSpeed;
    //Skilgreini stillingu til að beygja til hægri og vinstri.
    public float horizontalInput;
    // Sæki input fyrir hraða
    public float forwardInput;
    //Ro


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Sæki input fyrir hraða
        forwardInput = Input.GetAxis("Vertical");
        // Sæki horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        // Fæ farartækið til að keyra áfram
        // transform.Translate(0, 0, 1);
        // Skipti (0,0,1) fyrir eftirfarandi Til að fá "réttan" hraða
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Fæ farartækið til að beyjg til hægri og vinstri.
        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        // Skipti beygjuna út fyrir Rotate
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);


    }
}
