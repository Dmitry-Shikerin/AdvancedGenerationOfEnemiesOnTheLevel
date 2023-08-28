using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private float _delay;
    [SerializeField] private int _enemiesCount;
    [SerializeField] private WaypointMovement _crussader;
    [SerializeField] private WaypointMovement _zombie;

    private List<Transform> _spawners = new List<Transform>();
    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;
    private int _currentEnemieCount;

    void Start()
    {
        foreach (Transform spawner in gameObject.GetComponentsInChildren<Transform>())
        {
            if(spawner != transform)
            {
                _spawners.Add(spawner);
            }
        }

        _waitForSeconds = new WaitForSeconds(_delay);
        _currentEnemieCount = _enemiesCount;
        _coroutine = StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        while (_currentEnemieCount > 0)
        {
            Instanteate(_crussader, _spawners[0], _targets[0]);
            Instanteate(_zombie, _spawners[1], _targets[1]);

            _currentEnemieCount--;

            yield return _waitForSeconds;
        }
    }

    private void Instanteate(WaypointMovement enemie, Transform spawner, Transform target)
    {
        enemie = Instantiate(enemie, spawner.position, Quaternion.identity);

        enemie.Init(target);
    }
}
