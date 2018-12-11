using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : Obstacle {
    public bool hasDamagedPlayer;


	// Use this for initialization
	void Start () 
    {
		
	}

	
	// Update is called once per frame
	void Update () 
    {
		
	}


    private void Awake()
    {
       
        SetSizeRandom();
        hasDamagedPlayer = false;
      

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tail" || collision.gameObject.tag == "Player" )
        {
            if(!hasDamagedPlayer)
            collision.gameObject.GetComponent<Dragon>().RemoveJoint();
        }

    }

}

