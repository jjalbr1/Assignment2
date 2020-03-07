using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//code for the brown enemies
//enemy does not patrol
//enter the radius of the enemy --> attack
public class BasicEnemy : MonoBehaviour
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
        //find the player
        player = GameObject.FindGameObjectWithTag("player").transform;

    }
    void Update()
    {
        //get distance
        dist = Vector3.Distance(player.position, transform.position);

        //if in radius look at player, move towards player
        if(dist <= radius)
        {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }

    }
}
