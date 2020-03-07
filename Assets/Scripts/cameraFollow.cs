using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;


//follows player from the third person
public class cameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
   
    //called directly after update method
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }



}