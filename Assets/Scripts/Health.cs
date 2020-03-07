using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

//Controlls the health and switches the scene
public class Health : MonoBehaviour
{
    //change these values to change difficulty
    public int playerHealth = 30;
    int damage = 1;

    public Text healthDisplay;

    void Start()
    {
        //display starting health
        healthDisplay.text = "Health = " + playerHealth.ToString();
        print(playerHealth);
    }

    //deal damage when player collides with the enemy
    void OnCollisionEnter(Collision collision){

        //collision into enemy
        if(collision.gameObject.tag == "Enemy")
        {
            //decrease health
            playerHealth -= damage;
            print("damage dealt, player health at: " + playerHealth);
            healthDisplay.text = "Health = " + playerHealth.ToString();

            //if health is 0 game ends
            if(playerHealth == 0)
            {
                Destroy(gameObject);
            }
        }

        //change to scene 2
        if(collision.gameObject.tag == "LevelChange")
        {
            SceneManager.LoadScene(1);
        }

        //change to scene 3
        if (collision.gameObject.tag == "LevelChange2")
        {
            SceneManager.LoadScene(2);
        }
    }
}
