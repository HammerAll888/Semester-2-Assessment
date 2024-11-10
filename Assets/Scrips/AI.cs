using UnityEngine;
using UnityEngine.AI; 
 
public class AIController : MonoBehaviour 
{ 
    public Transform player; // Reference to the player 
    public float roamRadius = 10f; // Radius for roaming 
    public float followDistance = 5f; // Distance to start following the player 
    public float stopDistance = 7f; // Distance to stop following the player 
 
    private NavMeshAgent agent; // Reference to NavMeshAgent 
    private Vector3 roamTarget; // Target position for roaming 
 
    void Start() 
    { 
        agent = GetComponent<NavMeshAgent>(); 
        SetRandomRoamTarget(); 
    } 
 
    void Update() 
    { 
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); 
 
        if (distanceToPlayer < followDistance) 
        { 
            // Follow the player 
            agent.SetDestination(player.position); 
        } 
        else if (distanceToPlayer > stopDistance) 
        { 
            // Return to roaming 
            if (!agent.pathPending && agent.remainingDistance < 0.5f) 
            { 
                SetRandomRoamTarget(); 
            } 
            agent.SetDestination(roamTarget); 
        } 
    } 
 
    void SetRandomRoamTarget() 
    { 
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius; 
        randomDirection += transform.position; 
        NavMeshHit hit; 
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1); 
        roamTarget = hit.position; 
    } 
} 