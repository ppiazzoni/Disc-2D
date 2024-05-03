using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D m_rb;

    [Header("Values")]
    [SerializeField] private float m_speed = 10;

    [Header("Rotation")]
    [SerializeField] private Transform m_rotationHandler;
    [SerializeField] private float m_rotationSpeed = 25;
    // Start is called before the first frame update
    void Start()
    {
        Launch();
    }
    private void Launch()
    {
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        m_rb.AddForce(randomDir * m_speed, ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        m_rotationHandler.Rotate(Vector3.forward * m_rotationSpeed * Time.deltaTime);

    }
}
