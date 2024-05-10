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
        StartCoroutine(C_Spawn());
    }

    private void SpawnDisc()
    {
        DiscController spawnedDisc = Instantiate(m_discPrefab, transform.position, Quaternion.identity);
    }
    private IEnumerator C_Spawn()
    {
        yield return new WaitForSeconds(m_spawnFrequency);
        SpawnDisc();
        StartCoroutine(C_Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
