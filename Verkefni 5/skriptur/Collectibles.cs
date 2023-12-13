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

        //breytir l�fi og ey�ir objecti ef l�f er minna en fullt.
        if (controller != null)
        {
                controller.ChangeCount(1);
                Destroy(gameObject);
                //Spilar audio �egar health er collecta�
                controller.PlaySound(collectedClip);
        }
    }
}
