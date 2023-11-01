using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeateBackground : MonoBehaviour
{
    //breytur sem skilgreina byrjun og vídd.
    private Vector3 startPos;
    //skilgreinum breidd þangað til á að repeata og  sem á að repeata
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        // setur startpos svo við vitum hvar það var þegar við byrjum
        startPos = transform.position;
        // sækir breytt box collider svo þegar bakgrunnurinn fer lengra en það þá resettar hann sig 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // ef current position er minna en startpos - breiddin sem á að repeata þá færir hann bakgrunn aftur að byrjun.
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
