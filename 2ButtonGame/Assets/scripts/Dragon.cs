using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundaries 
{
    [Header("Max and Min Boundaries of movement.")]
    static public float MinY = -16, MaxY = 16;
}

public class Dragon : MonoBehaviour {

    [Header("Boundaries of movement of player (Y Axis)")]
    public float minY;
    public float maxY;

    [Space]
    [Header ("Configuration.")]

    Animator animator;
    Transform myTransform;
    public Transform header;
    Rigidbody2D head;
    //movement values
    [Header("Movement Values.")]
    public Attributes attributes;
    Vector2 speedVector;
    Vector2 turnSpeedVector;
    public bool moveUp;
    Vector3 velocity = Vector3.zero;
    public ObjectSpawner oS;
    public ObjectSpawner eS;
    // doesnt work with the uhnity joints. need ot make solution without physics.

	// Use this for initialization
	void Start () {
        head = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
       speedVector = new Vector2(attributes.speed, 0);
        turnSpeedVector = new Vector2(0, attributes.turnSpeed);
        attributes = GetComponent<Attributes> ();
        animator = GetComponent <Animator> ();

        Boundaries.MaxY = maxY;
        Boundaries.MinY = minY;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
       /* if(Input.GetKeyDown(KeyCode.Plus))
        {
            AddJoint();
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            RemoveJoint();
        }*/

        Vector3 refVector = myTransform.position += myTransform.right * attributes.speed * Time.deltaTime;

        Vector3.SmoothDamp(myTransform.position, myTransform.right * attributes.speed * Time.deltaTime, ref velocity, 1f, attributes.speed);

    
 

        if(moveUp)
        {
            //this needs to rotate only the sprite
            //myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.Euler(0, 0, rotationAngle), speed*  Time.deltaTime);

            myTransform.Translate(0,attributes.turnSpeed,0);
            header.rotation = Quaternion.Euler(0f, 0f, 45f);
           
        }
        else
        {   //this needs to rotate only the sprite
           // myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.Euler(0, 0, -rotationAngle), speed * Time.deltaTime);

            myTransform.Translate(0, -attributes.turnSpeed, 0);
            header.rotation = Quaternion.Euler(0f, 0f, -45f);
           
           // head.AddForce(-turnSpeedVector);
        }

            //boundaries Y
        transform.position = new Vector3 
			(transform.position.x,
			Mathf.Clamp(transform.position.y, Boundaries.MinY, Boundaries.MaxY),
			 0.0f);

	}

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.A))
        {
            moveUp = true;
            //tells the spawners to spawn enemies closer to where we think the player is moving
            oS.StartCorrelation(moveUp);
            eS.StartCorrelation(moveUp);
         

        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveUp = false;
            //tells the spawners to spawn enemies closer to where we think the player is moving
            oS.StartCorrelation(moveUp);
            eS.StartCorrelation(moveUp);

        }
        
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("FIRE IN THE HOLE...");
        }
    }
   

       
}
