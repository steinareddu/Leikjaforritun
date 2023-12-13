using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RubyController2 : MonoBehaviour
{
    //rigidbody2d breyta, horizontal og vertical
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    //Health breytur
    public int maxHealth = 2;
    //sækir currenthealth í health 
    public int health { get { return currentHealth; } }
    int currentHealth;
    public static int count = 0;


    //Breyta fyrir hraða
    public float speed = 3.0f;

    //Breytur til hún missir ekki allt líf strax í damageable objects
    bool isInvincible;
    float invincibleTimer;
    public float timeInvincible = 2.0f;

    //Animator og átt breytur til að sjá hvert ruby horfir.
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    //Breyta fyrir audio
    AudioSource audioSource;
    public AudioClip cogSound;
    public GameObject kula;
    public AudioClip boxSound;
    private TextMeshProUGUI countText;



    // Start is called before the first frame update
    void Start()
    {
        //Renderar 10 FPS í stað 60
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;

        //Sækir rigidbody2d 
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //Gerir currenthealth í maxhealth í byrjun leiks.
        currentHealth = 1;

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //Sækir Horizontal og Vertical stöðuna og setur í breyturnar
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical"); ;
        Vector2 move = new Vector2(horizontal, vertical);
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);


        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        //C býr til cog
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();

        }


    }

    //Kallar á fixedUpdate í hvert sinn sem á að vinna með rigidbody
    void FixedUpdate()
    {
        //Geymir staðsetningu Ruby í rigidbody2d
        Vector2 position = rigidbody2d.position;
        //Færir Ruby 3 * DeltaTime til hægri á x upp á y
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        //Setur það í position breytuna
        rigidbody2d.MovePosition(position);
    }

    //Fall til að breyta health
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            //Animatar ef líf breytist.
            animator.SetTrigger("Hit");

            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        if (health <= 0)
        {
            SceneManager.LoadScene(2);

        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    void Launch()
    {
        //Fall til að "launcha" projectile
        GameObject projectileObject = Instantiate(kula, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 3000);
        animator.SetTrigger("Launch");
    }

    public void ChangeCount(int amount)
    {
        count = count + 1;

        if (count == 3)
        {
            SceneManager.LoadScene(2);
            count = 0;
            currentHealth = 2;

        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
