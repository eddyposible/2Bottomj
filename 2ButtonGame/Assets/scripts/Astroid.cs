using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : Obstacle {
    public bool hasDamagedPlayer;
    public Rigidbody2D asteroidRgb;
    public float speed;

    void Start ()
    {
        asteroidRgb = GetComponent <Rigidbody2D> ();
    }

	void Update () 
    {
		asteroidRgb.velocity = Vector2.left * speed;
	}


    private void Awake()
    {
       
        SetSizeRandom();
        hasDamagedPlayer = false;
      

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Body" )
        {
            other.GetComponent<Body_tail_Joints>().RemoveJoint();            
        }

    }

}

