using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeateBackground : MonoBehaviour
{
    //breytur sem skilgreina byrjun og v�dd.
    private Vector3 startPos;
    //skilgreinum breidd �anga� til � a� repeata og  sem � a� repeata
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        // setur startpos svo vi� vitum hvar �a� var �egar vi� byrjum
        startPos = transform.position;
        // s�kir breytt box collider svo �egar bakgrunnurinn fer lengra en �a� �� resettar hann sig 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // ef current position er minna en startpos - breiddin sem � a� repeata �� f�rir hann bakgrunn aftur a� byrjun.
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
