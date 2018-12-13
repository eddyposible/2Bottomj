using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{


    public Transform myTransform;
    public Transform player;
    public float moveSpeed;
    public float rotationSpeed;
    public float rangeMin;
    public float rangeMax;
    public float stop;
    public int level;
    public bool hasDamagedTail;
    public Body_tail_Joints bodyTailJoints;

    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        //the enemys transform
        myTransform = this.transform;
        //locating the player
        player = GameObject.Find("Player").transform;
        hasDamagedTail = false;
        bodyTailJoints = GameObject.Find("DragonBody1").GetComponent<Body_tail_Joints>(); // maybe we should use tag instead idk
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            print("collision detected");

            if (collision.gameObject.GetComponent<Dragon>() != null)
            {
                print("dragon collision detected");
                if (bodyTailJoints.tail.Count >= level*3)
                {
                    print("addjoint");
                    bodyTailJoints.AddJoint();
                    Destroy(this.gameObject);
                }
                else
                {
                    bodyTailJoints.RemoveJoint();
                   
                   // Destroy(this.gameObject);
                }

            }
        }
        if (collision.gameObject.tag == "Tail")
        {
            if (!hasDamagedTail)
                bodyTailJoints.RemoveJoint();
        }
    }
}

