using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Awake()
    {
        //Sækir rigidbody
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Eyðir gameobject/projectile
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }


    public void Launch(Vector2 direction, float force)//Færir projectile
    {
        rigidbody2d.AddForce(direction * force);
    }

}

