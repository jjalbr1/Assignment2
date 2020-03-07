using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//NPC for 
public class Civilian : MonoBehaviour
{
    public GameObject[] houses;
    public float moveSpeed;
    private House houseScript;
    bool hasWaterB;
    bool hasFoodB;
    bool spawnedIn;
    public Transform theHouse;
    public GameObject[] popObject;
    public GameObject[] foodObject;
    public GameObject[] waterObject;

    void Start()
    {
        //NPCs must find everything by tags since they are generated using prefab
        houses = GameObject.FindGameObjectsWithTag("house");
        popObject = GameObject.FindGameObjectsWithTag("population");
        foodObject = GameObject.FindGameObjectsWithTag("food");
        waterObject = GameObject.FindGameObjectsWithTag("water");

        //NPCs initially have no food or water
        hasWaterB = false;
        hasFoodB = false;
    }

    // Update where the NPCs should go
    void Update()
    {
        findDestination();
    }

    void findDestination()
    {

        //Go to a house if there is an empty spot. Check each house
        if (!houses[1].GetComponent<House>().isFull())
        {
            theHouse = houses[1].transform;
            transform.LookAt(theHouse);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }
        else if (!houses[0].GetComponent<House>().isFull())
        {
            theHouse = houses[0].transform;
            transform.LookAt(theHouse);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }
        else if (!houses[2].GetComponent<House>().isFull())
        {
            theHouse = houses[2].transform;
            transform.LookAt(theHouse);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }     
      
       //if a house needs water and we have water, go to that house
       else if (needWater() && hasWaterB)
        {
            if (houses[1].GetComponent<House>().needsWater())
            {
                theHouse = houses[1].transform;
                transform.LookAt(theHouse);
                GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
            }
            else if (houses[0].GetComponent<House>().needsWater())
            {
                theHouse = houses[0].transform;
                transform.LookAt(theHouse);
                GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
            }
            else if (houses[2].GetComponent<House>().needsWater())
            {
                theHouse = houses[2].transform;
                transform.LookAt(theHouse);
                GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
            }
        }

        //if a house needs food and we have food, go to that house
        else if (needFood() && hasFoodB)
        {
            if (houses[0].GetComponent<House>().needsFood())
            {
                theHouse = houses[0].transform;
                transform.LookAt(theHouse);
                GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
            }
            else if (houses[1].GetComponent<House>().needsFood())
            {
                theHouse = houses[1].transform;
                transform.LookAt(theHouse);
                GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
            }
            else if (houses[2].GetComponent<House>().needsFood())
            {
                theHouse = houses[2].transform;
                transform.LookAt(theHouse);
                GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
            }
        }
        //if we dont have food or water check what the houses need
        else if (needWater())
        {
            transform.LookAt(waterObject[0].transform);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }
        else if (needFood())
        {
            transform.LookAt(foodObject[0].transform);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        //NPC reaches house
        if (collision.gameObject.tag == "house")
        {
            GameObject theObject = collision.gameObject;
            bool isFull = theObject.GetComponent<House>().isFull();

            //  collision into enemy
            if (!(isFull))
            {
                Destroy(gameObject);
            }
        }

        //NPC reaches store
        if (collision.gameObject.tag == "food")
        {
            hasFoodB = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

        //NPC reaches well
        if (collision.gameObject.tag == "water")
        {
            hasWaterB = true;
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    //check if NPC has water
    public bool hasWater()
    {
        return hasWaterB;
    }

    //check if NPC has food
    public bool hasFood()
    {
        return hasFoodB;
    }

    //check if any houses need food
    bool needFood()
    {
        if (houses[0].GetComponent<House>().needFood() || houses[1].GetComponent<House>().needFood() || houses[2].GetComponent<House>().needFood())
            return true;
        return false;
    }

    //check if anyu houses need water
    bool needWater()
    {
        if (houses[0].GetComponent<House>().needWater() || houses[1].GetComponent<House>().needWater() || houses[2].GetComponent<House>().needWater())
            return true;
        return false;
    }
}
