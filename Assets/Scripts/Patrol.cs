using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{

    //list of points to patrol through
    [SerializeField] private Transform[] points;

    //distance in to current point in which enemy locates a new point
    [SerializeField] private float minRemainingDistance = 0.1f;

    private int destinationPoint = 0;
    private NavMeshAgent agent;
    private Transform player;

    //distance to player
    private float dist;

    //speed fleer is fleeing
    public float moveSpeed;

    //radius to player to cause flee
    public float radius;


    void Start()
    {

        //find player and locate first point
        player = GameObject.FindGameObjectWithTag("player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextPoint();
    }

    //finds next point in the list to patrol to
    void GoToNextPoint()
    {
        //set points in inspector
        if (points.Length == 0)
        {
            Debug.LogError("No destination points");
            enabled = false;
            return;
        }
        agent.destination = points[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % points.Length;
    }

    void Update()
    {

        //calculate distance from player
        dist = Vector3.Distance(player.position, transform.position);
        //attack if player is within radius
        if (dist <= radius)
        {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }
       
        //if we are close to our destination point, go to the next point
        if (!agent.pathPending && agent.remainingDistance < minRemainingDistance)
        {
            GoToNextPoint();
        }
    }
}
