using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;

    private Vector3 _direction;

    private void Update()
    {
        Move();
    }

    public void SetDirectionMove(Vector3 direction)
    {
        _direction = direction;
    }    

    private void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
