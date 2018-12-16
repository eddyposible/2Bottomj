using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : Obstacle {
    public Rigidbody2D asteroidRgb;
    public float speed;
    public Body_tail_Joints body;

    void Start ()
    {
        asteroidRgb = GetComponent <Rigidbody2D> ();
        body = GameObject.FindGameObjectWithTag("Body").GetComponent<Body_tail_Joints>();
    }

	void Update () 
    {
		asteroidRgb.velocity = Vector2.left * speed;
	}


    private void Awake()
    {
          

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Body" || other.tag == "Player" || other.tag == "Tail")
        {
            if(body.recentlyRemoved == false){
                body.RemoveJoint();
            }           
        }

    }

}

