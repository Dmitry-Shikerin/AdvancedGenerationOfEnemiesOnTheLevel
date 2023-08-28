using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _path;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _path.position, _speed * Time.deltaTime);

        transform.LookAt(_path.position);
    }

    public void Init(Transform target)
    {
        _path = target;
    }
}
