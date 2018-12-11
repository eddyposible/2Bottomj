using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1  :  Enemy  {
    
 
  
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () 
    {
        //rotate to look at the player
        float distance =  Vector3.Distance(myTransform.position, player.position);
        if (distance <= rangeMax && distance >= rangeMin)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(player.position - myTransform.position), rotationSpeed * Time.deltaTime);
        }


        else if (distance <= rangeMax && distance > stop)
        {

            //move towards the player
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(player.position - myTransform.position), rotationSpeed * Time.deltaTime);
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        }
        else if (distance <= stop)
        {
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
            Quaternion.LookRotation(player.position - myTransform.position), rotationSpeed * Time.deltaTime);
        }
		
	}
   
   
}
