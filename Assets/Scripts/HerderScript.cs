using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Herder does not patrol
//Attacks when player enters radius
//Does not deal damage, only pushes the player
public class HerderScript : MonoBehaviour
{
    private Transform player;

    //distance between player
    private float dist;

    //speed when attacking
    public float moveSpeed;

    //radius to attack within
    public float radius;


    void Start()
    {
        //find player
        player = GameObject.FindGameObjectWithTag("player").transform;

    }
    void Update()
    {
        //get ditance
        dist = Vector3.Distance(player.position, transform.position);

        //if in radius move towards player
        if (dist <= radius)
        {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }

    }
}