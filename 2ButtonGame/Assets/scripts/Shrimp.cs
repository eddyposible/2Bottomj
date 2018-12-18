using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrimp : Enemy
{

    public float homingModifier;
    public GameObject Projectile;
    public Transform Spawn;
    public Animator animator;
    public Body_tail_Joints dragon;
    public bool isShooting = false;
    public AudioManager audioManager;

    void Start()
    {
        animator = GetComponent<Animator> ();
        dragon = GameObject.FindGameObjectWithTag("Body").GetComponent<Body_tail_Joints>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void FixedUpdate()
    {
        
        float distance = Vector2.Distance(myTransform.position, player.position);
        Vector2 tempVector = new Vector2(player.position.x, myTransform.position.y);
        Vector3 difference = transform.position - player.position;

        if (level== 0 || level == 1){
                if (dragon.tail.Count < level)
                {
                    animator.SetBool("Blue", true);
                } else
                {
                animator.SetBool("Blue", false);
                }
        }
  
        if (level == 2) //starts homing 
        {
            
            if (dragon.tail.Count < level)
            {
                animator.SetBool("Blue", true);
            } else
            {
                animator.SetBool("Blue", false);
            }
        


             if (distance <= rangeMax )
            {

                
                if (myTransform.position.x > player.transform.position.x)
                {
                    myTransform.position = Vector2.Lerp(transform.position, player.position, homingModifier);
                }
            }         

        }

        if (level == 3)
        {

            if (dragon.tail.Count < level)
            {
                animator.SetBool("Blue", true);
            } else
            {
                animator.SetBool("Blue", false);
            }

            if(distance <=  rangeMax)
            {
                if(!isShooting)
                {  
                StartCoroutine(ShootingProjectile());
                isShooting = true;
                }
                StartCoroutine(Movement());
                
            }

        }
    }

    IEnumerator Movement()
    {
        yield return new WaitForSeconds(1);
        if (myTransform.position.x > player.transform.position.x )
        {

            myTransform.position = Vector2.Lerp(transform.position, player.position, homingModifier);
        } else
        {
            myTransform.position += Vector3.left * moveSpeed*Time.deltaTime;
        }
    }

    IEnumerator ShootingProjectile(){
        animator.SetBool("Shoot",true);
        Instantiate(Projectile,Spawn.position,Quaternion.identity);

        audioManager.PlayAudioRandom("enemyRangedAttack");

        yield return new WaitForEndOfFrame();
        animator.SetBool("Shoot", false);
        StopCoroutine(ShootingProjectile());
    }
}
