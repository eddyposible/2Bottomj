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

    Transform myTransform;
    public GameObject tailSecionPrefab;
    public GameObject lastSection;
    public List<GameObject> tail;
    Rigidbody2D head;
    //movement values
    [Header("Movement Values.")]
    public float speed;
    public float turnSpeed;
    public float rotationAngle;
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
        lastSection = this.gameObject;
       speedVector = new Vector2(speed, 0);
        turnSpeedVector = new Vector2(0, turnSpeed);

        Boundaries.MaxY = maxY;
        Boundaries.MinY = minY;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Input.GetKeyDown(KeyCode.Plus))
        {
            AddJoint();
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            RemoveJoint();
        }

        Vector3 refVector = myTransform.position += myTransform.right * speed * Time.deltaTime;

        Vector3.SmoothDamp(myTransform.position, myTransform.right * speed * Time.deltaTime, ref velocity, 1f, speed);

    
 

        if(moveUp)
        {
            //this needs to rotate only the sprite
            //myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.Euler(0, 0, rotationAngle), speed*  Time.deltaTime);

            myTransform.Translate(0,turnSpeed,0);
           
           
        }
        else
        {   //this needs to rotate only the sprite
           // myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.Euler(0, 0, -rotationAngle), speed * Time.deltaTime);

            myTransform.Translate(0, -turnSpeed, 0);
      

           
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

        } else if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("FIRE IN THE HOLE...");
        }
    }
   public void AddJoint()
    {

        GameObject temp = GameObject.Instantiate(tailSecionPrefab, lastSection.transform.position, lastSection.transform.rotation);
        Tail tempTail = temp.GetComponent<Tail>();
        tempTail.setTarget(lastSection.transform);
        tail.Add(temp);

        lastSection = temp;

        
    }
    public void RemoveJoint()
    {
        if (tail.Count > 0)
        {
            Destroy(tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);
            if (tail.Count >= 1){
                lastSection = tail[tail.Count - 1];
            }else if (tail.Count <= 0){
                lastSection = this.gameObject;
            }
        }
        else
        {
            //game over, lose life etc.
            Debug.Log("Game over / lose life");
        }
    

    }

       
}
