using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset = new Vector3 (0, 5, -7);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Stilla kameruna bakvi� spilarann me� �v� a� b�ta vi� sta�setningu spilarans
        transform.position = player.transform.position + offset;
    }
}
