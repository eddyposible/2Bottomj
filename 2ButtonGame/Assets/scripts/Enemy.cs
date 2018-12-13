using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private const string Tag = "Player";
    public Transform myTransform;
    public Transform player;
    public float moveSpeed;
    public float rotationSpeed;
    public float rangeMin;
    public float rangeMax;
    public float stop;
    public int level;
    public bool hasDamagedTail;

    void Awake ()
    {
        //the enemys transform
        myTransform = transform;
        //locating the player
        player = GameObject.FindGameObjectWithTag(tag: "Body").transform;
        hasDamagedTail = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Body")
        {

            if (collision.gameObject.GetComponent<Body_tail_Joints>().tail.Count >= level)
            {
                    player.GetComponentInParent<Body_tail_Joints>().AddJoint();
                    Destroy(this.gameObject);
            }
            else
            {
            collision.gameObject.GetComponent<Body_tail_Joints>().RemoveJoint();
               
            // Destroy(this.gameObject);
            }

             if (collision.tag == "Tail" || collision.tag == "Body" || collision.tag == "Player")
            {
                if(!hasDamagedTail){
                    player.GetComponentInParent<Body_tail_Joints>().RemoveJoint();
                }
            
            }

        }
    }
}

