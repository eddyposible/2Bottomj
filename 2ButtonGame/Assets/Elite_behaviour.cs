using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elite_behaviour : MonoBehaviour
{


    public GameObject menuVictory;
    public int wichOneIs;
    public float Timer;
    public GameObject Projectile;
    public List<Transform> patrolMovements;
    public int currentPoint = 0;
    public float speed = 8;
    public float accuracy = 0.01f;
    public Transform spawn;
    public Animator animator;
    public Spawner spawner1, spawner2, spawner3, spawner4;
    public float life = 3;
    public GameObject Explotion;
    public GameObject goal;


    public MusicManager musicManager;
    public bool eventHasStarted;
    public bool isDamaged;

    public Dragon dragon;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(shooting());
        musicManager = GameObject.Find("AudioManager").GetComponent<MusicManager>();
        dragon = GameObject.Find("Player").GetComponent<Dragon>();
        isDamaged = false;

    }
        void Update()
        {
            if (Time.timeSinceLevelLoad >= Timer)
            {

                if (!eventHasStarted)
                {
                    musicManager.GoToEliteMusicFromMain();
                    dragon.mainMusicIsPlaying = false;
                    eventHasStarted = true;
                }

                spawner1.frequency = 5;
                spawner2.frequency = 5;
                spawner3.frequency = 5;
                spawner4.frequency = 5;

                float Distance = Vector3.Distance(patrolMovements[currentPoint].position, transform.position);
                transform.position = Vector3.MoveTowards(transform.position, patrolMovements[currentPoint].position, speed * Time.deltaTime);

                if (Distance <= accuracy)
                {
                    transform.position = patrolMovements[currentPoint].position;
                    currentPoint += 1;

                }

                if (currentPoint >= patrolMovements.Count)
                {
                    currentPoint = 1;
                }

                if (life < 3)
                {
                    if (!isDamaged)
                    {

                    musicManager.IntensityUp();
                    print("elite music up");
                        isDamaged = true;
                    }
                }



                if (life <= 0)
                {
                    Dead();
                }
            }


        }
        IEnumerator shooting()
        {
            yield return new WaitForSeconds(Timer + 2);
            StartCoroutine(Shoot());
        }

        IEnumerator Shoot()
        {
            animator.SetBool("Shoot", true);
            Instantiate(Projectile, spawn.position, Quaternion.identity);
            yield return new WaitForSeconds(2);
            animator.SetBool("Shoot", false);
            StartCoroutine(Shoot());
        }

        void Dead()
        {
        musicManager.GoToMainMusicFromElite();
        dragon.mainMusicIsPlaying = true;
        if (wichOneIs == 1)
            {
                Instantiate(Explotion, transform.position, Quaternion.identity);

                Instantiate(goal, new Vector3(Random.Range((transform.position.x - 5), (transform.position.x + 5)),
                Random.Range(transform.position.y - 5, transform.position.y + 5), 0f),
                Quaternion.identity);

                Instantiate(goal, new Vector3(Random.Range((transform.position.x - 5), (transform.position.x + 5)),
                Random.Range(transform.position.y - 5, transform.position.y + 5), 0f),
                Quaternion.identity);

                Instantiate(goal, new Vector3(Random.Range((transform.position.x - 5), (transform.position.x + 5)),
                Random.Range(transform.position.y - 5, transform.position.y + 5), 0f),
                Quaternion.identity);

                Instantiate(goal, new Vector3(Random.Range((transform.position.x - 5), (transform.position.x + 5)),
                Random.Range(transform.position.y - 5, transform.position.y + 5), 0f),
                Quaternion.identity);

                Instantiate(goal, new Vector3(Random.Range((transform.position.x - 5), (transform.position.x + 5)),
                Random.Range(transform.position.y - 5, transform.position.y + 5), 0f),
                Quaternion.identity);

                spawner1.frequency = 1;
                spawner2.frequency = 1.5f;
                spawner3.frequency = 1.5f;
                spawner4.frequency = 3;

         


                Destroy(this.gameObject);
            }
            else
            {
                Instantiate(Explotion, transform.position, Quaternion.identity);
                menuVictory.SetActive(true);
            }


        }
    }