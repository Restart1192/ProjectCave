using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolControl : MonoBehaviour
{
    [SerializeField] private List<Transform> targets;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float tolerancia;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        ChasePoint();
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(_agent.destination, transform.position);
        if (distancia <= tolerancia)
        {
            ChasePoint();
        }

    }

    void ChasePoint()
    {
        if (index != targets.Count)
        {
            _agent.destination = targets[index].position;
        }
        else if (targets.Count != 0)
        {
            index = 0;
            _agent.destination = targets[index].position;
        }
        index++;
    }
}
