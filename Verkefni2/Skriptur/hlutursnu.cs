using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hlutursnu : MonoBehaviour
{
    void Update()
    {
        //Fær hlutinn til að snúa
        transform.Rotate(new Vector3(0,80,0) * Time.deltaTime);
    }
}
