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
    //s�kir currenthealth � health 
    public int health { get { return currentHealth; } }
    int currentHealth;
    public static int count = 0;


    //Breyta fyrir hra�a
    public float speed = 3.0f;

    //Breytur til h�n missir ekki allt l�f strax � damageable objects
    bool isInvincible;
    float invincibleTimer;
    public float timeInvincible = 2.0f;

    //Animator og �tt breytur til a� sj� hvert ruby horfir.
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
        //Renderar 10 FPS � sta� 60
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;

        //S�kir rigidbody2d 
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //Gerir currenthealth � maxhealth � byrjun leiks.
        currentHealth = 1;

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //S�kir Horizontal og Vertical st��una og setur � breyturnar
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

        //C b�r til cog
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();

        }


    }

    //Kallar � fixedUpdate � hvert sinn sem � a� vinna me� rigidbody
    void FixedUpdate()
    {
        //Geymir sta�setningu Ruby � rigidbody2d
        Vector2 position = rigidbody2d.position;
        //F�rir Ruby 3 * DeltaTime til h�gri � x upp � y
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        //Setur �a� � position breytuna
        rigidbody2d.MovePosition(position);
    }

    //Fall til a� breyta health
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            //Animatar ef l�f breytist.
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
        //Fall til a� "launcha" projectile
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
