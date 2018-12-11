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

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            if (collision.gameObject.GetComponent<Dragon>() != null)
            {
                if (collision.gameObject.GetComponent<Dragon>().tail.Count >= level*3)
                {
                    collision.gameObject.GetComponent<Dragon>().AddJoint();
                    Destroy(this.gameObject);
                }
                else
                {
                    collision.gameObject.GetComponent<Dragon>().RemoveJoint();
                   
                   // Destroy(this.gameObject);
                }

            }
        }
        if (collision.gameObject.tag == "Tail")
        {
            if(!hasDamagedTail)
            player.GetComponentInParent<Dragon>().RemoveJoint();
        }
    }
}

