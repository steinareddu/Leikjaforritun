 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    //skilgreini hoppkraft
    public float jumpForce = 10;
    //skilgreini �yngdarafslstillingu
    public float gravityModifier;
    //skilgreinir breytu sem segir hvort hann s� � j�r�inni e�a ekki
    public bool isOnGround = true;
    //skilgreini breytu sem segir til um hvort leikurinn s� � gangi e�a game over
    public bool gameOver;
    //Skilgreini animatio breytu
    private Animator playerAnim;
    // explosin breyta
    public ParticleSystem explosionParticle;
    // dirtparticle breyta
    public ParticleSystem dirtParticle;
    // breytur fyrir hopphlj�� og crashsound
    public AudioClip jumpSound;
    public AudioClip crashSound;
    //breyta fyrir spilarahlj��
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        //S�ki rigibody spilarans
        playerRb = GetComponent<Rigidbody>();
        //s�ki Animation fyrir spilarann
        playerAnim = GetComponent<Animator>();
        //s�ki Hlj�� fyrir spilarann
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        //if statement sem f�r hann til a� hoppa, hoppar ekki me� gameover != true ef hann er dau�ur/game over
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver != true)
        {
            //Hoppar
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //stilli svo hann s� ekki � j�r�inni � breytunni
            isOnGround = false;
            //s�kir hopp animation
            playerAnim.SetTrigger("Jump_Trig");
            //stoppar dirtparticle
            dirtParticle.Stop();
            //spila hopphlj�� �egar hann spilar og skilgreini hversu h�tt., bara spila� einusinni
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        // Geri if else �ar sem ef hann hittir j�r�ina �� heldur hann �fram en ef hann rekst � "Wall" �� deyr hann.
        if (collision.gameObject.CompareTag("Ground"))
        {
            //er � j�r�inni og spilar dirtparticle �egar hann er � j�r�inni
            isOnGround = true;
            //spila dirtparticle
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Wall"))
        {
            // Game over ef hann klessir � vegg
            Debug.Log("Game Over");
            gameOver = true;
            // Breyti animation �egar hann deyr, stoppar
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            // reykur kemur �egar hann deyr
            explosionParticle.Play();
            //stoppar dirtparticle
            dirtParticle.Stop();
            //spila crashsound �egar hann er dau�ur/gameover, spila einusinni
            playerAudio.PlayOneShot(crashSound, 1.0f);
        } 
    }
}
