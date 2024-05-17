using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public Canvas deathCanvas;
    public GameObject player;
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 0.5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    [Header("VFX")]
    [SerializeField] private ParticleSystem deathVFX;
    private bool isAlive = true;
    private bool isInvincible = false; 

    void Start()
    {
        activeMoveSpeed = moveSpeed;
        dashCoolCounter = 0f;
        deathCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isAlive)
        {
            HandleMovement();
            HandleDash();
        }
    }

    private void HandleMovement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        rb2d.velocity = moveInput * activeMoveSpeed;
    }

    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dashCoolCounter <= 0 && dashCounter <= 0)
        {
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;
            isInvincible = true; 
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
                isInvincible = false; 
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    public void TakeDamage(DiscController disc)
    {
        if (!isInvincible) 
        {
            KillChara();
        }
    }

    public void KillChara()
    {
        if (isAlive)
        {
            Debug.Log("Player_Killed");
            deathVFX?.Play();
            isAlive = false;
            StartCoroutine(HandleDeath());
        }
    }

    private IEnumerator HandleDeath()
    {

        yield return new WaitForSeconds(2f);
        deathCanvas.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Disc"))
        {
            DiscController disc = collision.GetComponentInParent<DiscController>();
            if (disc)
            {
                TakeDamage(disc);
            }
        }
    }
}