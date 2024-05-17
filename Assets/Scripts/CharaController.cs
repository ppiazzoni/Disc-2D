using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaController : MonoBehaviour
{
    public float movespeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public Canvas deathCanvas;
    public GameObject Player;
    private float ActiveMoveSpeed;
    public float DashSpeed;

    public float DashLength = .5f, DashCooldown = 1f;

    public float DashCounter;
    public float DashCoolCounter;

    [Header("VFX")]
    [SerializeField] private ParticleSystem m_deathVFX;
    private bool m_isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        ActiveMoveSpeed = movespeed;
    }


    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        
        moveInput.Normalize();
        
        rb2d.velocity = moveInput * ActiveMoveSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DashCoolCounter <= 0 && DashCounter <= 0)
            {
                ActiveMoveSpeed = DashSpeed;
                DashCounter = DashLength;
             
            }
        }

        if (DashCounter > 0)
        {
            DashCounter -= Time.deltaTime;

            if(DashCounter <= 0)
            {
                ActiveMoveSpeed = movespeed;
                DashCoolCounter = DashCooldown;
                
            }
        }

        if(DashCoolCounter > 0)
        {
            DashCoolCounter -= Time.deltaTime;
        }
    }


    public void TakeDamage(DiscController disc)
    {
        KillChara();
    }

    public void KillChara()
    {
        Debug.Log("Player_Killed");
        m_deathVFX.Play();
        m_isAlive = false;
        deathCanvas.gameObject.SetActive(true);
        Player.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Disc"))
        {
            DiscController disc = collision.GetComponentInParent<DiscController>();
            if(disc)
            {
                TakeDamage(disc);
                
            }
        }
        else
        {
            print("test");  
        }
    }
}
