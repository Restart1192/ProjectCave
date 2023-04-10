using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] Transform _player;
    NavMeshAgent _agent;

    private Vector3 pos;
    // Start is called before the first frame update
    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 diff = transform.position - _player.position;
        if (diff.magnitude < _chaseRadius)
        {
            _agent.destination = _player.position;
        }*/
    }

    public void AppChase()
    {
        _agent.destination = _player.position;
    }

    public void BeginChase()
    {
        pos = _player.position;
    }

    public void EndChase()
    {
        _agent.destination = pos;
    }
}
