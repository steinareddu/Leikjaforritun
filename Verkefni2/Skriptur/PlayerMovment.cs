using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using TMPro;

public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update
    //skilgreini hraða, hliðarhraða og hoppkraft
    public float speed = 0.2f;
    public float sideways = 0.2f;
    public float jump = 0.2f;
    //private Rigidbody leikmadur;
    //Skilgreinir stig 
    public static int count = 20;
    public TextMeshProUGUI countText;

    void Start()
    {
        Debug.Log("byrja");
        //Sýnir stigafjölda
        SetCountText();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //stilli hreyfingar svo hægt sé að færa leikmann með WASD og örvum.
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))//áfram
        {
            transform.position += transform.forward * speed ;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))// til baka
        {
            transform.position += -transform.forward * speed;

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))//hægri
        {
            transform.position += transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))//vinstri
        {
            //hreyfir player um sideways í hvert skipti sem ýtt er á leftArrow
            transform.position += -transform.right * sideways;
        }
        if (Input.GetKey(KeyCode.Space))//hoppa
        {
            transform.position += transform.up * jump;
        }
        //hér rétti ég playerinn við ef hann dettur
        //sný player
        if (Input.GetKey("f"))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("g"))//snúa leikmanni
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }
        if (Input.GetKey("q"))// ef ýtt er á q
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
       
        if (transform.position.y <= -1)
        {
            Endurræsa();
        }
        
    }
   
      void OnCollisionEnter(Collision collision)
     {
         // ef player keyrir á object sem heitir hlutur
         if (collision.collider.tag == "hlutur")
         {
             collision.collider.gameObject.SetActive(false);
             count = count + 1;
            // Debug.Log("Nú er ég komin með " + count);
             SetCountText();//kallar á fallið
         }
         if (collision.collider.tag == "pikk")
         {
             collision.collider.gameObject.SetActive(false);
             count = count + 5;
             //Debug.Log("Nú er ég komin með " + count);
             SetCountText();//kallar á fallið
         }
         if (collision.collider.tag == "hindrun")
         {
             collision.collider.gameObject.SetActive(false);
             count = count -3;
             //Debug.Log("Nú er ég komin með " + count);
             SetCountText();//kallar á fallið
         }
     }

     void SetCountText()
     {
        // Sýnir stigafjölda á canvas
         countText.text = "Stig: " + count.ToString();

        //Ef stig eru undir 0 þá er game over
         if (count <= 0)
         {
             this.enabled = false;//kemur í veg fyrir að playerinn geti hreyfst áfram eftir dauðan
             countText.text = "Dauður " + count.ToString()+" stigum";

             StartCoroutine(Bida());

         }

     }
     IEnumerator Bida()
     {
         yield return new WaitForSeconds(2);
         Endurræsa();
     }

     public void Byrja()
     {
         SceneManager.LoadScene(1);
     }
     public void Endurræsa()
     {
         //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Level_1
         SceneManager.LoadScene(0);
     }
    
}
