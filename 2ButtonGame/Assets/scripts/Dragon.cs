using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour {
    Transform myTransform;
    public GameObject tailSecionPrefab;
    public GameObject lastSection;
    public List<GameObject> tail;
    Rigidbody2D head;
    //movement values
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



	}

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveUp = true;
            //tells the spawners to spawn enemies closer to where we think the player is moving
            oS.StartCorrelation(moveUp);
            eS.StartCorrelation(moveUp);
         

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveUp = false;
            //tells the spawners to spawn enemies closer to where we think the player is moving
            oS.StartCorrelation(moveUp);
            eS.StartCorrelation(moveUp);

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
        if (tail.Count > 1)
        {
            Destroy(tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);
            lastSection = tail[tail.Count - 1];
        }
        else
        {
            //game over, lose life etc.
        }
    

    }

       
}
