using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrimp : Enemy
{

    public float homingModifier;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float distance = Vector2.Distance(myTransform.position, player.position);
        Vector2 tempVector = new Vector2(player.position.x, myTransform.position.y);
        float distanceForAngle = Vector2.Distance(myTransform.position, tempVector);
        float angle = (Mathf.Pow(Mathf.Cos(distanceForAngle / distance), -1) * 57.2957795f);
  
        if (level >= 2) //starts homing 
        {
            
        


             if (distance <= rangeMax )
            {


                if (myTransform.position.x > player.transform.position.x)
                {

                    myTransform.Rotate(0, 0, angle);


                   

                    Vector2 myVector2 = new Vector2(myTransform.position.x, myTransform.position.y);
                    Vector2 targetVector2 = new Vector2(player.transform.position.x, player.transform.position.y);
                    myTransform.position = Vector2.Lerp(myVector2, targetVector2, homingModifier);
                }
            }         

        }
    }
}
