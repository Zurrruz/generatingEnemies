using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPositions;
    [SerializeField] private Enemy _enemyPrefab;

    [SerializeField] float _timeSpawn;
    private bool _canGenerate;

    private List<Vector3> _directions;

    private int _minNumberSpawnPoints = 0;

    WaitForSeconds _timeout;

    private void Awake()
    {
        _directions = new() {
            Vector3.forward,
            Vector3.back,
            Vector3.right,
            Vector3.left};

        _canGenerate = true;

        _timeout = new WaitForSeconds(_timeSpawn);
    }

    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        while (_canGenerate)
        {
            int spawnPoint = Random.Range(_minNumberSpawnPoints, _spawnPositions.Count);

            Enemy enemy = Instantiate(_enemyPrefab, _spawnPositions[spawnPoint].position, Quaternion.identity);
            enemy.SetDirectionMove(GetDirection());

            yield return _timeout;
        }
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = _directions[Random.Range(0, _directions.Count)];

        return direction;
    }
}
