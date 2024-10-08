using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistansSpot;

    private Transform _spot;

    private void Update()
    {
        Move();
        completesPath();
    }

    public void SetDirectionMove(Transform spot)
    {
        _spot = spot;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            _spot.position,
            _speed * Time.deltaTime);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void completesPath()
    {
        Vector3 offset = _spot.position - transform.position;
        float sqrLen = offset.sqrMagnitude;

        if (sqrLen < _minDistansSpot * _minDistansSpot)
            Die();
    }
}
