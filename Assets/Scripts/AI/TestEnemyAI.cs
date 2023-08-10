using UnityEngine;
using UnityEngine.AI;

public class TestEnemyAI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Transform target;

    private void Awake()
    {
        agent.SetDestination(target.position);
    }
}
