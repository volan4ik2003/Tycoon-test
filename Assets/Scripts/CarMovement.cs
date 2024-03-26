using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarMovement : MonoBehaviour
{
    private GameObject[] Destinations;
    private NavMeshAgent agent;
    int destIndex;

    private void Awake()
    {
        Destinations = GameObject.FindGameObjectsWithTag("Destination");
    }
    void Start()
    {
        destIndex = Random.Range(0, Destinations.Length);
        agent = GetComponent<NavMeshAgent>();
        if (Destinations[destIndex] == null)
        {
            Debug.LogError("Target is not set!");
        }
        else
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        agent.SetDestination(Destinations[destIndex].transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destination"))
        {
            Destroy(this.gameObject);
        }
    }
}
