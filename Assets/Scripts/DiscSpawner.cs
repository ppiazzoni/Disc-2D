using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscSpawner : MonoBehaviour
{
    [SerializeField] private DiscController m_discPrefab;
    [SerializeField] private float m_spawnFrequency = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(C.Spawn)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
