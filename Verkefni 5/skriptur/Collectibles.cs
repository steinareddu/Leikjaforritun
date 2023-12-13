using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public AudioClip collectedClip;
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController2 controller = other.GetComponent<RubyController2>();

        //breytir lífi og eyðir objecti ef líf er minna en fullt.
        if (controller != null)
        {
                controller.ChangeCount(1);
                Destroy(gameObject);
                //Spilar audio þegar health er collectað
                controller.PlaySound(collectedClip);
        }
    }
}
