using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

//calculates data and displays for the canvas
//Class could probably be combined with SpawnPoint class
public class population : MonoBehaviour
{
    public Text popDisplay;
    public Text capDisplay;
    public Text emptySpots2;
    public SpawnPoint sp;

    public int capacity;
    public int pop;
    public int emptySpots;

    public GameObject house1;
    public GameObject house2;
    public GameObject house3;


    // Start is called before the first frame update
    void Start()
    {
        //initial population is 3
        pop = 3;
        capacity = 1;

        //set initial text boxes
        popDisplay.text = "Population = " + pop.ToString();
        capDisplay.text = "Capacity = " + capacity.ToString();
        emptySpots2.text = "Spots Available = " + emptySpots.ToString();
    }

    void Update()
    {
       //if there is a chenge in data, update text boxes
       popDisplay.text = "Population = " + pop.ToString();
       capDisplay.text = "Capacity = " + capacity.ToString();
       emptySpots2.text = "Spots Available = " + emptySpots.ToString();
        calculatePop();
        calculateCapacity();
        calculateEmptySpots();
    }
    
    //calculate total capacity of houses
    void calculateCapacity()
    {
        capacity = house1.GetComponent<House>().GetCapacity() + house2.GetComponent<House>().GetCapacity() + house3.GetComponent<House>().GetCapacity();
    }

    //calculate total population of scene
    void calculatePop()
    {
        pop = sp.GetComponent<SpawnPoint>().GetPop();
    }

    //calculate all empty spots of houses
    void calculateEmptySpots()
    {
        emptySpots = house1.GetComponent<House>().GetEmpty() + house2.GetComponent<House>().GetEmpty() + house3.GetComponent<House>().GetEmpty();
    }

    //return the capacity
    public int getCapacity()
    {
        return capacity;
    }

    //return the amount of total empty spots
    public int getEmptySpots()
    {
        return emptySpots;
    }
}
