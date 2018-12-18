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
    public GameObject Explotion_dead;
   public AudioManager audioManager;
    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        //the enemys transform
        myTransform = this.transform;
        //locating the player
        player = GameObject.Find("Player").transform;
        hasDamagedTail = false;
        bodyTailJoints = GameObject.Find("DragonBody1").GetComponent<Body_tail_Joints>(); // maybe we should use tag instead idk
        StartCoroutine(DeathTime());
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Body" || collision.gameObject.tag == "Player")
        {
          //  print("collision detected");

            if (collision.gameObject.GetComponent<Dragon>() != null)
            {
           //     print("dragon collision detected");
                if (bodyTailJoints.tail.Count >= level)
                {   
                    if(level >= 2){
                        bodyTailJoints.meterBar +=1;
                    }
                  //  print("addjoint");
                    bodyTailJoints.AddJoint();
                    Instantiate(Explotion_dead, transform.position,Quaternion.identity);
                   // audioManager.PlayAudioRandom("enemyDeath");
                    Destroy(this.gameObject);
                }
                else
                {
                        if (bodyTailJoints.recentlyRemoved == false)
                    {
                        bodyTailJoints.RemoveJoint();

                    }        
                   // Destroy(this.gameObject);
                }

            }
        }
        if (collision.gameObject.tag == "Tail")
        {
            
            if (bodyTailJoints.recentlyRemoved == false)
                    {
                        bodyTailJoints.RemoveJoint();
                    }
        }
        if (collision.gameObject.tag == "Projectile")
        {
            bodyTailJoints.AddJoint();
            Instantiate(Explotion_dead, transform.position,Quaternion.identity);
            audioManager.PlayAudioRandom("enemyDeath");
            Destroy(this.gameObject);
        }
    }

    IEnumerator DeathTime()
    {
        int counter = 10;
        for (int i = counter; i >= 0; i--)
        {
            counter--;
            yield return new WaitForSeconds(10);

            if (counter < 1)
            {
                Destroy(this);
            }
        }
    }
}

