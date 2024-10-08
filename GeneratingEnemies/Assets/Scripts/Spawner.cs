using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _timeSpawn;

    private WaitForSeconds _timeout;

    private void Awake()
    {
        _timeout = new WaitForSeconds(_timeSpawn);
    }

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        while (enabled)
        {            
            foreach (SpawnPoint spawnPoint in _spawnPoints)
                spawnPoint.CreateEnemy();

            yield return _timeout;
        }
    }
}
