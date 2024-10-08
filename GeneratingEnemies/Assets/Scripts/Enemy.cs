using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistansSpot;

    private Transform _spot;

    private void Update()
    {
        Move();
        Die();
    }

    public void SetDirectionMove(Transform spot)
    {
        _spot = spot;
    }    

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _spot.position, _speed * Time.deltaTime);
    }

    private void Die()
    {
        if (Vector3.Distance(transform.position, _spot.position) < _minDistansSpot)
            Destroy(gameObject);
    }
}
