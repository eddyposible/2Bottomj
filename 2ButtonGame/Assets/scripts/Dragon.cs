﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*[System.Serializable]
public class Boundaries 
{
    [Header("Max and Min Boundaries of movement.")]
    static public float MinY = -16, MaxY = 16;
}*/

public class Dragon : MonoBehaviour {

   /* [Header("Boundaries of movement of player (Y Axis)")]
    public float minY;
    public float maxY;
 */
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
    public GameObject Projectile;
    public Transform spawnP;

    public Body_tail_Joints body;
    public AudioManager audioManager;
    bool meterSoundPlaying;
    public MusicManager musicManager;
    public bool mainMusicIsPlaying;
    // doesnt work with the uhnity joints. need ot make solution without physics.
    public int numberOfObjects;
    bool onCoolDown;


	// Use this for initialization
	void Start () {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        musicManager = GameObject.Find("AudioManager").GetComponent<MusicManager>();
        head = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
       speedVector = new Vector2(attributes.speed, 0);
        turnSpeedVector = new Vector2(0, attributes.turnSpeed);
        attributes = GetComponent<Attributes> ();
        animator = GetComponent <Animator> ();
        body = GameObject.FindGameObjectWithTag("Body").GetComponent<Body_tail_Joints>();

        //Boundaries.MaxY = maxY;
        //Boundaries.MinY = minY;


        musicManager.StopAllMusic();
        musicManager.PlayMainMusicFromStart();
        mainMusicIsPlaying = true;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
       
        Vector3 refVector = myTransform.position += myTransform.right * attributes.speed * Time.deltaTime;

        Vector3.SmoothDamp(myTransform.position, myTransform.right * attributes.speed * Time.deltaTime, ref velocity, 1f, attributes.speed);

        float horizontal = Input.GetAxisRaw("Movement");
        Vector3 movement = new Vector3(0f, horizontal/2, 0f);
        transform.position += movement;
	}

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.A))
        {
            header.rotation = Quaternion.Euler(0f, 0f, 45f);
         

        } else if (Input.GetKeyDown(KeyCode.S))
        {
            header.rotation = Quaternion.Euler(0f, 0f, -45f);

        } else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S)){
            header.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        
        if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.S))
        {
            if(body.meterBar >= 3)
            {
                Instantiate(Projectile,spawnP.position,Quaternion.identity);
                audioManager.PlayAudioRandom("lightningAttack");
                body.meterBar = 0;
            }
        }
        if(body.meterBar >=3)
        {
            if (!meterSoundPlaying)
            {
                audioManager.PlayAudioRandom("meterFull");
                meterSoundPlaying = true;
            }
        }
        else
        {
            meterSoundPlaying = false;
            audioManager.StopAudioPlayer("meterFull");
        }

        if(body.tail.Count <3)
        {
            if (mainMusicIsPlaying)
            {
                if (!onCoolDown)
                {

                    StopAllCoroutines();
                    StartCoroutine(CoolDown());
                    if (musicManager.intensityLevel != 0)
                    {
                        musicManager.SetIntensity(0);
                        print("musicDown");
                    }

                }
            }
        }

        if (body.tail.Count >= 3 && body.tail.Count < 6)
        {
            if (mainMusicIsPlaying)
            {
                if (!onCoolDown)
                {

                    StopAllCoroutines();
                    StartCoroutine(CoolDown());

                    if (musicManager.intensityLevel != 1)
                    {
                        musicManager.SetIntensity(1);
                        print("music up1");
                    }
                }
            }
        }
        if(body.tail.Count > 6)
        {
            if (mainMusicIsPlaying)
            {
                if (!onCoolDown)
                {
                    StopAllCoroutines();
                    StartCoroutine(CoolDown());

                    if (musicManager.intensityLevel != 2)
                    {
                        print("music up2");
                        musicManager.SetIntensity(2);
                    }
                }
            }
        }
    }
   
    IEnumerator CoolDown()
    {
        onCoolDown = true;
        yield return new WaitForSeconds(5);
        onCoolDown = false;
        
    }

}
