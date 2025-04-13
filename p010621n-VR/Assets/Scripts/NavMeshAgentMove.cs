using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentMove : MonoBehaviour
{
    NavMeshAgent m_Agent;
    float timerToResetMovement = 3.0f;
    NavMeshHit m_Hit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        ChangeTargetPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerToResetMovement <= 0 )
        {
            ChangeTargetPos();
            timerToResetMovement = 3.0f;
        }

        timerToResetMovement -= Time.deltaTime;
    }

    void ChangeTargetPos()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 3;
        randomDirection += transform.position;

        NavMesh.SamplePosition(randomDirection, out m_Hit, 3, NavMesh.AllAreas);
        m_Agent.SetDestination(m_Hit.position);
    }
}
