using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] private ParticleSystem m_deathVFX;
    private bool m_isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(DiscController disc)
    {
        KillChara();
    }

    public void KillChara()
    {
        Debug.Log("fefd");
        m_deathVFX.Play();
        m_isAlive = false;
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
