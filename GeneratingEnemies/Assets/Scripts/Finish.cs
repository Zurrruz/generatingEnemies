using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private List<Transform> _moveSpots;
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistansSpot;

    private int _spot = 0;
    private int _stepForward = 1;
    private int _stepBack = -1;
    private int _nextSpot;

    private void Awake()
    {
        _nextSpot = _stepForward;
    }

    private void Update()
    {
        Move();
        ChangeSpot();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            _moveSpots[_spot].position, 
            _speed * Time.deltaTime);
    }

    private void ChangeSpot()
    {
        Vector3 offset = _moveSpots[_spot].position - transform.position;
        float sqrLen = offset.sqrMagnitude;

        if (sqrLen < _minDistansSpot * _minDistansSpot)
        {
            if (_spot == _moveSpots.Count - 1)
                _nextSpot = _stepBack;
            if (_spot == 0)
                _nextSpot = _stepForward;

            _spot += _nextSpot;
        }
    }
}
