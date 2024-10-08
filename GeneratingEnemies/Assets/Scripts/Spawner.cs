using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _finish;
    [SerializeField] private Enemy _enemyPrefab;

    [SerializeField] private float _timeSpawn;

    private WaitForSeconds _timeout;

    private void Awake()
    {
        _timeout = new WaitForSeconds(_timeSpawn);
    }

    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        while (enabled)
        {            
            Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            enemy.SetDirectionMove(_finish);

            yield return _timeout;
        }
    }
}
