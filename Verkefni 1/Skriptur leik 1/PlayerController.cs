using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // skilgreini speed h�rna svo ��gilegra s� a� breyta
    public float speed = 5.0f;
    // Skilgreini beygjuhra�a
    public float turnSpeed;
    //Skilgreini stillingu til a� beygja til h�gri og vinstri.
    public float horizontalInput;
    // S�ki input fyrir hra�a
    public float forwardInput;
    //Ro


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //S�ki input fyrir hra�a
        forwardInput = Input.GetAxis("Vertical");
        // S�ki horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        // F� farart�ki� til a� keyra �fram
        // transform.Translate(0, 0, 1);
        // Skipti (0,0,1) fyrir eftirfarandi Til a� f� "r�ttan" hra�a
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // F� farart�ki� til a� beyjg til h�gri og vinstri.
        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        // Skipti beygjuna �t fyrir Rotate
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);


    }
}
