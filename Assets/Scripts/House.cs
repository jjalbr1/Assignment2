using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//House class for 3rd scene
public class House : MonoBehaviour
{
    int capacity;
    int emptySpots;
    bool hasWater;
    bool hasFood;
    int foodTotal = 100;

    void Start()
    {
        //houses start out with no resources
        hasWater = false;
        hasFood = false;
        emptySpots = 0;
        capacity = 0;
    }

    void OnCollisionEnter(Collision collision)
    { 
            //handle collision with an NPC
            if (collision.gameObject.tag == "civilian")
            {
            GameObject theObject = collision.gameObject;

            //if there is room in the house, let NPC in
                if (!isFull())
                {
                    emptySpots--;
                }
                //if they have food and we need food, take food, increase capacity and empty spots available
                else if (theObject.GetComponent<Civilian>().hasFood() && needFood())
                {
                     hasFood = true;
                     capacity = capacity + 2;
                     emptySpots++;
                }

                //if they have water and we need water, take water, increase capacity and empty spots available
                else if (theObject.GetComponent<Civilian>().hasWater() && needWater())
                {
                    hasWater = true;
                    capacity = capacity + 4;
                    emptySpots = emptySpots +3;
                }
            }
    }

    //check if house has water
    public bool needWater()
    {
        return !hasWater;
    }

    //check if house has food
    public bool needFood()
    {
        return !hasFood;
    }

    //check if house has any empty spots
    public bool isFull()
    {
        if (emptySpots > 0)
            return false;
        return true;
    }


    public bool needsWater()
    {
        return !hasWater;
    }
    public bool needsFood()
    {
        return !hasFood;
    }

    //return amount of empty spots
    public int GetEmpty()
    {
        return emptySpots;
    }

    //return capacity of house
    public int GetCapacity()
    {
        return capacity;
    }


}
