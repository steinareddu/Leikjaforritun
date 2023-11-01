 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    //skilgreini hoppkraft
    public float jumpForce = 10;
    //skilgreini þyngdarafslstillingu
    public float gravityModifier;
    //skilgreinir breytu sem segir hvort hann sé á jörðinni eða ekki
    public bool isOnGround = true;
    //skilgreini breytu sem segir til um hvort leikurinn sé í gangi eða game over
    public bool gameOver;
    //Skilgreini animatio breytu
    private Animator playerAnim;
    // explosin breyta
    public ParticleSystem explosionParticle;
    // dirtparticle breyta
    public ParticleSystem dirtParticle;
    // breytur fyrir hopphljóð og crashsound
    public AudioClip jumpSound;
    public AudioClip crashSound;
    //breyta fyrir spilarahljóð
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        //Sæki rigibody spilarans
        playerRb = GetComponent<Rigidbody>();
        //sæki Animation fyrir spilarann
        playerAnim = GetComponent<Animator>();
        //sæki Hljóð fyrir spilarann
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        //if statement sem fær hann til að hoppa, hoppar ekki með gameover != true ef hann er dauður/game over
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver != true)
        {
            //Hoppar
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //stilli svo hann sé ekki á jörðinni í breytunni
            isOnGround = false;
            //sækir hopp animation
            playerAnim.SetTrigger("Jump_Trig");
            //stoppar dirtparticle
            dirtParticle.Stop();
            //spila hopphljóð þegar hann spilar og skilgreini hversu hátt., bara spilað einusinni
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        // Geri if else þar sem ef hann hittir jörðina þá heldur hann áfram en ef hann rekst á "Wall" þá deyr hann.
        if (collision.gameObject.CompareTag("Ground"))
        {
            //er á jörðinni og spilar dirtparticle þegar hann er á jörðinni
            isOnGround = true;
            //spila dirtparticle
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Wall"))
        {
            // Game over ef hann klessir á vegg
            Debug.Log("Game Over");
            gameOver = true;
            // Breyti animation þegar hann deyr, stoppar
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            // reykur kemur þegar hann deyr
            explosionParticle.Play();
            //stoppar dirtparticle
            dirtParticle.Stop();
            //spila crashsound þegar hann er dauður/gameover, spila einusinni
            playerAudio.PlayOneShot(crashSound, 1.0f);
        } 
    }
}
