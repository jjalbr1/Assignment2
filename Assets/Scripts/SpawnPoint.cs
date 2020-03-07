using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Spawns the NPCs for 3rd scene
public class SpawnPoint : MonoBehaviour
{

    public GameObject[] spawnLocations;
    public GameObject populationObject;

    public GameObject player;

    private Vector3 respawnLocation;

    int pop;

    void Start()
    {
        //population starts with 3 people
        pop = 3;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Spawn());
    }

    //spawns NPCs. Delayed by two seconds
    private IEnumerator Spawn()
    {
     int cap = populationObject.GetComponent<population>().getCapacity();

        //if we can house more people, spawn them. There will always be 2 extra/homeless people
        if (pop < cap + 2)
        {
            yield return new WaitForSeconds(2);

            if (pop < cap + 2)
            {
                pop++;

                // find the prefab in resources
                player = (GameObject)Resources.Load("person", typeof(GameObject));

                respawnLocation = player.transform.position;

                //spawn NPC at random spawn location
                int spawn = Random.Range(0, spawnLocations.Length);
                //Creat the NPC
                GameObject.Instantiate(player, spawnLocations[spawn].transform.position, Quaternion.identity);
            }
        }
    }

    //return the population
    public int GetPop()
    {
        return pop;
    }
}
